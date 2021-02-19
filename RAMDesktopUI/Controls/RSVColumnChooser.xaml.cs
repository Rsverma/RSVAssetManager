using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RAMDesktopUI.Controls
{
    /// <summary>
    /// Interaction logic for RSVColumnChooser.xaml
    /// </summary>
    public partial class RSVColumnChooser : Window, INotifyPropertyChanged
    {
        private BindingList<ColumnVisibility> _columnsVisiblityMapping = new BindingList<ColumnVisibility>();
        public BindingList<ColumnVisibility> ColumnsVisiblityMapping
        {
            get
            {
                return _columnsVisiblityMapping;
            }
            set
            {
                _columnsVisiblityMapping = value;
                OnPropertyChanged("ColumnsVisiblityMapping");
            }
        }

        public RSVColumnChooser()
        {
            InitializeComponent();
            DataContext = this;
        }

        public event RoutedEventHandler CheckedUnChecked;

        private void CheckBoxChanged(object sender, RoutedEventArgs e)
        {
            CheckedUnChecked?.Invoke(sender, e);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(String name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        // Close
        private void CommandBinding_Executed_Close(object sender, ExecutedRoutedEventArgs e)
        {
            SystemCommands.CloseWindow(this);
        }
        // Can execute
        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
    }
}
