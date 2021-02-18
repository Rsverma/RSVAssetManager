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
        public class ColumnVisibility
        {
            public string Name { get; set; }
            public bool IsVisible { get; set; }
        }
        private List<ColumnVisibility> _columnsVisiblityMapping;
        public List<ColumnVisibility> ColumnsVisiblityMapping
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
            ColumnsVisiblityMapping = new List<ColumnVisibility> { new ColumnVisibility { Name = "RSV", IsVisible = true } };
            InitializeComponent();
            DataContext = this;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(String name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
