using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RAMDesktopUI.Library.Helpers.AppConstants;

namespace RAMDesktopUI.EventModels
{
    public class LaunchModuleEvent
    {
        public LaunchModuleEvent(ModuleTypes moduleType)
        {
            ModuleType = moduleType;
        }
        public ModuleTypes ModuleType { get; private set; }
    }
}
