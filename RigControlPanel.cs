using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SDRSharp.Plugin.RigControl
{
    public partial class RigControlPanel : UserControl
    {
        private RigControlProcess _process;
        public RigControlPanel(RigControlProcess process)
        {
            InitializeComponent();

            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            lblVersion.Text = "v" + fvi.FileMajorPart + "." + fvi.FileMinorPart;

            _process = process;
            _process.rigStatus += _process_rigStatus;

            cbRig.Items.Add("Rig1");
            cbRig.Items.Add("Rig2");
            cbRig.SelectedIndex = 0;

            lblRigName.Text = "";
            lblStatus.Text = "";
            lblFrequency.Text = "";
            lblMode.Text = "";
        }

        private void bb_omniRigConfig_Click(object sender, EventArgs e)
        {
            _process.OmniRigConfig();
            
        }

        private void _process_rigStatus()
        {
            lblStatus.Text = _process.rigInfo.status;
            lblFrequency.Text = Convert.ToString(_process.rigInfo.frequency);
            lblMode.Text = _process.rigInfo.mode;
            lblRigName.Text = _process.rigInfo.rigName;
        }

        private void chkEnable_CheckedChanged(object sender, EventArgs e)
        {
            if(chkEnable.Checked)
            {
                _process.connectRig(cbRig.Text);
            }
            else
            {
                _process.disConnectRig();
            }
        }

        


        
    }
}
