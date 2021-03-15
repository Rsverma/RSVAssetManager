using Microsoft.Win32;
using RAMDesktopUI.Controls;
using RAMDesktopUI.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
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

        private DataTable _importableRows = new();

        public DataTable ImportableRows
        {
            get { return _importableRows; }
            set
            {
                _importableRows = value;
                NotifyOfPropertyChange(() => ImportableRows);
            }
        }


        public void ImportFile()
        {
            OpenFileDialog openFileDialog = new();
            openFileDialog.Filter = "Excel or CSV Files|*.csv;*.xls;*.xlsx;*.xlsb";
            bool? result = openFileDialog.ShowDialog();
            if (result == true)
            {
                DataSet data = ExcelCSVHelper.GetDataSetFromFile(openFileDialog.FileName);
                if (data != null && data.Tables.Count > 0 && data.Tables[0].Columns.Count > 0)
                {
                    ImportableRows = data.Tables[0];
                }
            }
        }
    }
}
