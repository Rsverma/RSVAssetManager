using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RAMDesktopUI
{
    public abstract class ModuleBase : Screen
    {
        protected WindowState _curWindowState;

        public WindowState CurWindowState
        {
            get { return _curWindowState; }
            set
            {
                _curWindowState = value;
                NotifyOfPropertyChange(() => CurWindowState);
            }
        }
    }
}
