# SDRSharp.Plugin.RigControl
Plugin to connect SDRSharp to Control Radio frequency and Mode

![Screenshot](https://github.com/chokelive/SDRSharp.Plugin.Rigcontrol/assets/17312564/0de3a343-0874-4f75-bc73-29f07e8e3ad6)

## download
* lastest compiled version is available on github 
* https://github.com/chokelive/SDRSharp.Plugin.Rigcontrol/releases
## install
* Require SDRSharp v1.0.0.1822 or above and .NET 5 Desktop x86 Runtime
* Require Omninirig Libary and Radio config http://dxatlas.com/omnirig/
* For old SDR# versions:
  * copy the SDRSharp.Plugin.RigControl.dll into SDRSharp Plugins directory
  * add the "magic line" to your plugins.xml file

         <add key="Rig Control" value="SDRSharp.Plugin.RigControl.RigControlPlugin,SDRSharp.Plugin.RigControl" />

* For newer SDR# versions with automatic plugins discovery:
  * create RigControl subdirectory inside SDRSharp Plugins directory
  * place SDRSharp.Plugin.RigControl.dll there

73 E29AHU
