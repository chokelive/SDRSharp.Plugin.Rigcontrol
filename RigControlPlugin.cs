using SDRSharp.Common;
using SDRSharp.Plugin.RigControl;
using SDRSharp.Radio;
using System.Windows.Forms;

namespace SDRSharp.Plugin.NoiseBlanker
{
    public class RigControlPlugin : ISharpPlugin, ICanLazyLoadGui
    {
        private const string _displayName = "Rig Control";
        private ISharpControl _control;

        private RigControlPanel _configGui;
        private RigControlProcess _process;

        public string DisplayName
        {
            get { return _displayName; }
        }

        public UserControl Gui
        {
            get
            {
                LoadGui();
                return _configGui;
            }
        }

   
        public void Initialize(ISharpControl control)
        {
            _control = control;
            _process = new RigControlProcess(_control); // load Rig Control Plugin

            
        }

        public void Close()
        {

        }

        public void LoadGui()
        {
            if (_configGui == null)
            {
                _configGui = new RigControlPanel(_process);
            }
        }
    }
    
}
