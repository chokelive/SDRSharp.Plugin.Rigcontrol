using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OmniRig;
using System.Timers;
using SDRSharp.Common;

namespace SDRSharp.Plugin.RigControl
{
    public class RigInfo
    {
        public int frequency { get; set; }
        public string mode { get; set; }
        public string  status { get; set; }
        public string rigName { get; set; }
    }
    public class RigControlProcess
    {
        private OmniRigX omniRig;
        private IRigX rig = null;
        ISharpControl _control;
        private Timer timer;
        public RigInfo rigInfo;

        public event Action rigStatus;
        public RigControlProcess(ISharpControl control)
        {
            _control = control;

            omniRig = new OmniRigX();
            rig = omniRig.Rig1;

            timer = new Timer();
            timer.Interval = 1000;
            timer.Elapsed += Timer_Elapsed;

            rigInfo = new RigInfo();

        }

        public void OmniRigConfig()
        {
            omniRig.DialogVisible = true;
        }

        public void connectRig(string rigSelect)
        {
            if (rigSelect == "Rig1")
            {
                rig = omniRig.Rig1;
            }
            else if(rigSelect == "Rig2")
            {
                rig = omniRig.Rig2;
            }

            timer.Start();

        }

        public void disConnectRig()
        {
            timer.Stop();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {

            rigInfo.status = rig.StatusStr;
            rigInfo.frequency = rig.FreqA;

            switch (rig.Mode)
            {
                case RigParamX.PM_AM:
                    rigInfo.mode = "AM"; break;
                case RigParamX.PM_CW_L:
                    rigInfo.mode = "CW-L"; break;
                case RigParamX.PM_CW_U:
                    rigInfo.mode = "CW-U"; break;
                case RigParamX.PM_SSB_L:
                    rigInfo.mode = "LSB"; break;
                case RigParamX.PM_SSB_U:
                    rigInfo.mode = "USB"; break;
                case RigParamX.PM_FM:
                    rigInfo.mode = "FM"; break;
            }
            rigInfo.rigName = rig.RigType;

            var change = checkWhatChange();
            if(change==whatRigOrSdr.RIG)
            {
                SetToRadio();
            }
            else if(change == whatRigOrSdr.SDR)
            {
                SetToSDR();
            }
            rigStatus?.Invoke();
        }


        private static long RigPrevFreq;
        private static long SdrPrevFreq;
        private static RigParamX RigPrevMode;
        private static Radio.DetectorType SdrPrevMode;
        enum whatRigOrSdr
        {
            RIG,
            SDR
        }
        private whatRigOrSdr checkWhatChange()
        {
            whatRigOrSdr ret=whatRigOrSdr.SDR;
            if (_control.Frequency != SdrPrevFreq)
            {
                ret = whatRigOrSdr.RIG; 
            }
            else if(_control.DetectorType != SdrPrevMode)
            {
                ret = whatRigOrSdr.RIG;
            }
            else if (rig.FreqA != RigPrevFreq)
            {
                ret = whatRigOrSdr.SDR;
            }
            else if (rig.Mode != RigPrevMode)
            {
                ret = whatRigOrSdr.SDR;
            }

            SdrPrevFreq = _control.Frequency;
            SdrPrevMode = _control.DetectorType;
            RigPrevFreq = rig.FreqA;
            RigPrevMode = rig.Mode;

            return ret;
        }

        private void SetToRadio()
        {
            rig.FreqA = Convert.ToInt32(_control.Frequency);

            switch(_control.DetectorType)
            {
                case Radio.DetectorType.AM:
                    rig.Mode = RigParamX.PM_AM; break;
                case Radio.DetectorType.NFM:
                    rig.Mode = RigParamX.PM_FM; break;
                case Radio.DetectorType.USB:
                    rig.Mode = RigParamX.PM_SSB_U; break;
                case Radio.DetectorType.LSB:
                    rig.Mode = RigParamX.PM_SSB_L; break;
                case Radio.DetectorType.CW:
                    rig.Mode = RigParamX.PM_CW_L; break;
            }
        }

        private void SetToSDR()
        {
            _control.Frequency = rig.FreqA;

            switch (rig.Mode)
            {
                case RigParamX.PM_AM:
                    _control.DetectorType = Radio.DetectorType.AM; break;
                case RigParamX.PM_CW_L:
                    _control.DetectorType = Radio.DetectorType.CW; break;
                case RigParamX.PM_CW_U:
                    _control.DetectorType = Radio.DetectorType.CW; break;
                case RigParamX.PM_SSB_L:
                    _control.DetectorType = Radio.DetectorType.LSB; break;
                case RigParamX.PM_SSB_U:
                    _control.DetectorType = Radio.DetectorType.USB; break;
                case RigParamX.PM_FM:
                    _control.DetectorType = Radio.DetectorType.NFM; break;
            }
        }



    }
}
