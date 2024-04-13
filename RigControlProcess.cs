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
        public bool syncRigToSDROption { get; set; }
        public bool syncSDRToRigOption { get; set; }
    }
    public class RigControlProcess
    {
        private OmniRigX omniRig;
        private IRigX rig = null;
        ISharpControl _control;
        private Timer timer;
        public RigInfo rigInfo;

        public event Action rigStatus;

        public RigControlProcess()
        {
        }
        public RigControlProcess(ISharpControl control)
        {
            _control = control;

            omniRig = new OmniRigX();
            //rig = omniRig.Rig2;

            timer = new Timer();
            timer.Interval = 500;
            timer.Elapsed += Timer_Elapsed;

            rigInfo = new RigInfo();

        }

        public void OmniRigConfig()
        {
            omniRig.DialogVisible = true;
        }

        public void connectRig(string rigSelect) // Start omniRig
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

        public void disConnectRig() // Stop Omnirig
        {
            timer.Stop();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            // Update Parameters for display control
            rigInfo.status = rig.StatusStr;
            rigInfo.frequency = rig.FreqA;
            rigInfo.mode = Convert.ToString(translateModeRigToSDR(rig.Mode));
            rigInfo.rigName = rig.RigType;
            
            // Rig to SDR sync
            if (rigInfo.syncRigToSDROption == true)
            {
                //Sync Frequency
                long setFrequency;
                bool syncFreqStatus = syncRigToSDR(_control.Frequency, rig.FreqA, RigPrevFreq, out setFrequency);
                if (syncFreqStatus == true) // check SDR frequency chang
                {
                    _control.Frequency = setFrequency;
                }

                // Sync Mode
                Radio.DetectorType setMode;
                bool syncModeStatus = syncModeRigToSdr(_control.DetectorType, rig.Mode, RigPrevMode, out setMode);
                if (syncModeStatus == true)
                {
                    _control.DetectorType = setMode;
                }

                
                
            }

            // SDR to Radio sync
            if (rigInfo.syncSDRToRigOption == true)
            {

                // Sync Frequency
                long setFrequency;
                bool syncFreqStatus = syncSDRToRig(_control.Frequency, rig.FreqA, SdrPrevFreq, out setFrequency);
                if (syncFreqStatus == true)
                {
                    rig.FreqA = Convert.ToInt32(setFrequency);
                    
                }

                // Sync Mode
                RigParamX setMode;
                bool syncModeStatus = syncModeSDRtoRig(_control.DetectorType, rig.Mode, SdrPrevMode, out setMode);
                if (syncModeStatus == true)
                {
                    rig.Mode = setMode;
                }

                
                

                
                
            }

            //  save frequency for next round caculate
            RigPrevFreq = rig.FreqA;
            SdrPrevFreq = _control.Frequency;

            RigPrevMode = rig.Mode;
            SdrPrevMode = _control.DetectorType;


            rigStatus?.Invoke();
        }




        // ==========================================================================//
        // Internal Function compare frequen and mde change between SDR and Rig

        private static long RigPrevFreq;
        private static long SdrPrevFreq;
        private static RigParamX RigPrevMode;
        private static Radio.DetectorType SdrPrevMode;



        // sync frequency from RIG to SDR
        public bool syncRigToSDR(long sdrFrequency, long rigFrequency, long prevRigFrequrncy, out long setFrequency)
        {
            bool retStatus = false;
            long retFreq = sdrFrequency;

            // Not do any sync if everything fine
            if (sdrFrequency == rigFrequency)
            {
                retStatus = false;
            }
            else if (rigFrequency != prevRigFrequrncy) // Detect frequency change at RIG
            {
                retStatus = true;
                retFreq = rigFrequency;
            }

            setFrequency = retFreq;
            return retStatus;
        }

        // Sync Mode from Rig to SDR
        public bool syncModeRigToSdr(Radio.DetectorType sdrMode, RigParamX rigMode, RigParamX prevRigMode, out Radio.DetectorType setMode)
        {
            bool retStatus = false;
            Radio.DetectorType retMode = sdrMode;

            // Translate RigMode to SDR Mode
            Radio.DetectorType rigModeConv = translateModeRigToSDR(rigMode);
            Radio.DetectorType prevRigModeConv = translateModeRigToSDR(prevRigMode);

            if (sdrMode == rigModeConv)
            {
                retStatus = false;
            }
            else if (rigModeConv != prevRigModeConv)
            {
                retStatus = true;
                retMode = rigModeConv;
            }

            setMode = retMode;
            return retStatus;
        }


        // synce frequency from SDR to Rig
        public bool syncSDRToRig(long sdrFrequency, long rigFrequency, long prevSdrFrequrncy, out long setFrequency)
        {
            bool retStatus = false;
            long retFreq = sdrFrequency;

            // Not do any sync if everything fine
            if (sdrFrequency == rigFrequency)
            {
                retStatus = false;
            }
            else if (sdrFrequency != prevSdrFrequrncy)  // Detect frequency change at SDR
            {
                retStatus = true;
                retFreq = sdrFrequency;
            }
            setFrequency = retFreq;
            return retStatus;
        }


        // Sync mode from SDR to Rig
        public bool syncModeSDRtoRig(Radio.DetectorType sdrMode, RigParamX rigMode, Radio.DetectorType SdrPrevMode, out RigParamX setMode)
        {
            bool retStatus = false;
            RigParamX retMode = rigMode;

            // Translate RigMode to SDR Mode
            RigParamX sdrModeConv = translateModeSDRToRig(sdrMode);
            RigParamX prevSdrModeConv = translateModeSDRToRig(SdrPrevMode);

            if (sdrModeConv == rigMode)
            {
                retStatus = false;
            }
            else if (sdrModeConv != rigMode)
            {
                retStatus = true;
                retMode = sdrModeConv;
            }

            setMode = retMode;
            return retStatus;
        }


        // Translate RigMode from Rig to SDR mode
        private Radio.DetectorType translateModeRigToSDR(RigParamX mode)
        {
            Radio.DetectorType  ret= Radio.DetectorType.USB; // default mode
            switch (mode)
            {
                case RigParamX.PM_AM:
                    ret = Radio.DetectorType.AM; break;
                case RigParamX.PM_CW_L:
                    ret = Radio.DetectorType.CW; break;
                case RigParamX.PM_CW_U:
                    ret = Radio.DetectorType.CW; break;
                case RigParamX.PM_SSB_L:
                    ret = Radio.DetectorType.LSB; break;
                case RigParamX.PM_SSB_U:
                    ret = Radio.DetectorType.USB; break;
                case RigParamX.PM_FM:
                    ret = Radio.DetectorType.NFM; break;
                case RigParamX.PM_DIG_U:
                    ret = Radio.DetectorType.USB; break;
                case RigParamX.PM_DIG_L:
                    ret = Radio.DetectorType.LSB; break;
            }

            return ret;
        }


        // Translate RigMode from Rig to SDR mode
        private RigParamX translateModeSDRToRig(Radio.DetectorType mode)
        {
            RigParamX ret = RigParamX.PM_SSB_U; // default mode
            switch (mode)
            {
                case Radio.DetectorType.AM:
                    ret = RigParamX.PM_AM; break;
                case Radio.DetectorType.CW:
                    ret = RigParamX.PM_CW_U; break;
                case Radio.DetectorType.LSB:
                    ret = RigParamX.PM_SSB_L; break;
                case Radio.DetectorType.USB:
                    ret = RigParamX.PM_SSB_U; break;
                case Radio.DetectorType.NFM:
                    ret = RigParamX.PM_FM; break;
                case Radio.DetectorType.WFM:
                    ret = RigParamX.PM_FM; break;
            }

            return ret;
        }

    }
}
