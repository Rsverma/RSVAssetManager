using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAMDesktopUI.EventModels
{
    public class LaunchModuleEvent
    {
        public LaunchModuleEvent(string moduleName)
        {
            ModuleName = moduleName;
        }
        public string ModuleName { get; private set; }
    }
}
