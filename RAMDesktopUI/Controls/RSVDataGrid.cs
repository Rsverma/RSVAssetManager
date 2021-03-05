using RAMDesktopUI.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RAMDesktopUI.Controls
{
    /// <summary>
    /// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
    ///
    /// Step 1a) Using this custom control in a XAML file that exists in the current project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:RAMDesktopUI.Controls"
    ///
    ///
    /// Step 1b) Using this custom control in a XAML file that exists in a different project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:RAMDesktopUI.Controls;assembly=RAMDesktopUI.Controls"
    ///
    /// You will also need to add a project reference from the project where the XAML file lives
    /// to this project and Rebuild to avoid compilation errors:
    ///
    ///     Right click on the target project in the Solution Explorer and
    ///     "Add Reference"->"Projects"->[Browse to and select this project]
    ///
    ///
    /// Step 2)
    /// Go ahead and use your control in the XAML file.
    ///
    ///     <MyNamespace:RSVDataGrid/>
    ///
    /// </summary>
    public class RSVDataGrid : DataGrid
    {
        static RSVDataGrid()
        {
            //DefaultStyleKeyProperty.OverrideMetadata(typeof(RSVDataGrid), new FrameworkPropertyMetadata(typeof(DataGrid)));

        }
        private ObservableCollection<DataGridColumn> _columns;

        public RSVDataGrid()
            : base()
        {
            Style = FindResource("RSVDataGridStyle") as Style;
            Loaded += RSVDataGrid_Loaded;
            ColumnChooserClicked = new RelayCommand(OnColumnChooserClicked, CanChooseColumns);
        }

        private void RSVDataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            var grid = sender as RSVDataGrid;
            _columns = grid.Columns;
            //ReplaceSelectAllButton(this);
            Loaded -= RSVDataGrid_Loaded;
        }

        void ReplaceSelectAllButton(DependencyObject dependencyObject)
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(dependencyObject); i++)
            {
                var child = VisualTreeHelper.GetChild(dependencyObject, i);
                if(child!=null)
                {

                    if (child is Button button && button.Name.Equals("SelectAll"))
                    {
                        button.Command = ColumnChooserClicked;
                    }
                    else
                    {
                        ReplaceSelectAllButton(child);
                    }
                }
            }
        }
        public static ICommand ColumnChooserClicked { get; set; }
        private RSVColumnChooser columnChooser;
        private bool CanChooseColumns(object value)
        {
            return true;
        }


        void OnColumnChooserClicked(object value)
        {
            if (columnChooser == null)
            {
                BindingList<ColumnVisibility> columnsVisiblityMapping = new BindingList<ColumnVisibility>();
                foreach (var col in _columns)
                {
                    columnsVisiblityMapping.Add(new ColumnVisibility { Name = col.Header.ToString(), IsVisible = col.Visibility == Visibility.Visible });
                }
                columnChooser = new RSVColumnChooser
                {
                    Owner = Window.GetWindow(this),
                    ColumnsVisiblityMapping = columnsVisiblityMapping
                };

                columnChooser.CheckedUnChecked += Win_CheckedUnChecked;
                columnChooser.Closing += Win_Closing;
                columnChooser.Show();
            }
            else
            {
                columnChooser.Activate();
            }
        }

        private void Win_Closing(object sender, CancelEventArgs e)
        {
            columnChooser.CheckedUnChecked -= Win_CheckedUnChecked;
            columnChooser.Closing -= Win_Closing;
            columnChooser = null;
        }

        private void Win_CheckedUnChecked(object sender, RoutedEventArgs e)
        {
            var chkBox = sender as CheckBox;
            string columnName = chkBox.Content.ToString();

            DataGridColumn changedColumn = _columns.FirstOrDefault(c => c.Header.ToString().Equals(columnName));
            if (changedColumn != null)
            {
                Visibility visibility = e.RoutedEvent.Name.Equals("Checked") ? Visibility.Visible : Visibility.Collapsed;
                changedColumn.Visibility = visibility;
            }
        }
    }
}
