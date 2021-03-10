using RAMDesktopUI.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace RAMDesktopUI.ViewModels
{
    public class ImportManagerViewModel : ModuleBase
    {
        public ICommand SelectCmd { get; private set; }
        public ImportManagerViewModel()
        {

            SelectCmd = new RelayCommand(SelectionChanged, CanSelectItem);
        }

        private bool CanSelectItem(object value)
        {
            return true;
        }


        void SelectionChanged(object value)
        {
        }
    }
}
