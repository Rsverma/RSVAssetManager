using Caliburn.Micro;
using RAMDesktopUI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RAMDesktopUI.ViewModels
{
    public class PortfolioMonitorViewModel : ModuleBase
    {
        public PortfolioMonitorViewModel()
        {

        }
        private BindingList<OrderManagerRowModel> _positions = new BindingList<OrderManagerRowModel>();

        public BindingList<OrderManagerRowModel> Positions
        {
            get { return _positions; }
            set
            {
                _positions = value;

                NotifyOfPropertyChange(() => Positions);
            }
        }
    }
}
