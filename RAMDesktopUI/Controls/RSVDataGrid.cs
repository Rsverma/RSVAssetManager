using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace RAMDesktopUI.Controls
{
    public class RSVDataGrid : DataGrid
    {
        private ObservableCollection<DataGridColumn> _columns;
        private List<KeyValuePair<string,bool>> _columnsVisiblityMapping = new List<KeyValuePair<string, bool>>();

        public RSVDataGrid()
            : base()
        {
            Loaded += RSVDataGrid_Loaded;
        }

        private void RSVDataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            var grid = sender as RSVDataGrid;
            _columns = grid.Columns;
            foreach(var col in _columns)
            {
                _columnsVisiblityMapping.Add(new KeyValuePair<string, bool>(col.Header.ToString(), col.Visibility == Visibility.Visible));
            }
            ReplaceSelectAllButton(this);
            Loaded -= RSVDataGrid_Loaded;
        }
        void ReplaceSelectAllButton(DependencyObject dependencyObject)
        {
            if (dependencyObject == null) return;
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(dependencyObject); i++)
            {
                var child = VisualTreeHelper.GetChild(dependencyObject, i);

                if ((child != null) && child is Button)
                {
                    var grid = (Grid)dependencyObject;

                    var button = new Button()
                    {
                        VerticalAlignment = VerticalAlignment.Center,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        Margin = new Thickness(1)
                    };

                    button.Click += OnColumnChooserClicked;
                    grid.Children.RemoveAt(i);
                    grid.Children.Insert(i, button);
                }
                else if (child != null)
                {
                    ReplaceSelectAllButton(child);
                }
            }
        }
        
        //Action when the top left check box checked and unchecked
        void OnColumnChooserClicked(object sender, RoutedEventArgs e)
        { var button = sender as Button;
            RSVColumnChooser win = new RSVColumnChooser
            {
                Owner = Window.GetWindow(this),
                //ColumnsVisiblityMapping = _columnsVisiblityMapping
            };
            win.Show();
        }
    }
}