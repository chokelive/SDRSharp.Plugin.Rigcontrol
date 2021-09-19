using SDRSharp.Radio;
using System;

namespace SDRSharp.Plugin.RigControl
{
    public unsafe class NoiseBlankerProcessor : IIQProcessor, IRealProcessor
    {
        private const int CircularBufferSize = 4;

        private double _sampleRate;
        private double _pulseWidth;
        private double _lookupWindow;
        private double _threshold;
        private bool _enabled;
        private bool _needConfigure = true;
        private int _blankingWindowLength;
        private int _index;
        private float _ratio;
        private float _avg;
        private float _alpha;
        private UnsafeBuffer _delay;
        private Complex* _delayPtr;

        public double SampleRate
        {
            get { return _sampleRate; }
            set
            {
                _sampleRate = value;
                _avg = 1.0f;
                _needConfigure = true;
            }
        }

        public bool Enabled
        {
            get { return _enabled; }
            set { _enabled = value; }
        }

        public double NoiseThreshold
        {
            get { return _threshold; }
            set
            {
                _threshold = value;
                _ratio = Fourier.DecibelToRatio((float)_threshold);
            }
        }

        public double PulseWidth
        {
            get { return _pulseWidth; }
            set
            {
                _pulseWidth = value;
                _needConfigure = true;
            }
        }

        public double LookupWindow
        {
            get { return _lookupWindow; }
            set
            {
                _lookupWindow = value;
                _needConfigure = true;
            }
        }

        private void Configure()
        {
            _alpha = (float)(1.0 - Math.Exp(-1.0 / (_sampleRate * _lookupWindow * 1e-3)));
            _blankingWindowLength = (int)Math.Max(_pulseWidth * 1e-6 * _sampleRate, 3) | 1;

            var bufferSize = _blankingWindowLength * CircularBufferSize;
            if (_delay == null || _delay.Length < bufferSize)
            {
                _delay = UnsafeBuffer.Create(bufferSize, sizeof(Complex));
                _delayPtr = (Complex*)_delay;
            }
        }

        public void Process(float* buffer, int length)
        {
            if (_needConfigure)
            {
                Configure();
                _needConfigure = false;
            }

            for (var i = 0; i < length; i++)
            {
                var delay = _delayPtr + _index;

                delay[0] = buffer[i];

                var mag = Math.Abs(delay[_blankingWindowLength / 2].Real);

                if (mag > _ratio * _avg)
                {
                    _delay.Clear();
                }

                _avg += _alpha * (Math.Abs(buffer[i]) - _avg);

                buffer[i] = delay[_blankingWindowLength - 1].Real;

                if (--_index < 0)
                {
                    _index = _blankingWindowLength * (CircularBufferSize - 1);
                    Utils.Memcpy(_delayPtr + _index + 1, _delayPtr, (_blankingWindowLength - 1) * sizeof(Complex));
                }
            }
        }

        public void Process(Complex* buffer, int length)
        {
            if (_needConfigure)
            {
                Configure();
                _needConfigure = false;
            }

            for (var i = 0; i < length; i++)
            {
                var delay = _delayPtr + _index;

                delay[0] = buffer[i];

                var mag = delay[_blankingWindowLength / 2].FastMagnitude();

                if (mag > _ratio * _avg)
                {
                    _delay.Clear();
                }

                _avg += _alpha * (buffer[i].FastMagnitude() - _avg);

                buffer[i] = delay[_blankingWindowLength - 1];

                if (--_index < 0)
                {
                    _index = _blankingWindowLength * (CircularBufferSize - 1);
                    Utils.Memcpy(_delayPtr + _index + 1, _delayPtr, (_blankingWindowLength - 1) * sizeof(Complex));
                }
            }
        }
    }

    static class ComplexHelper
    {
        public static float FastMagnitude(this Complex c)
        {
            var r = Math.Abs(c.Real);
            var i = Math.Abs(c.Imag);
            return Math.Max(r, i);
        }
    }
}