﻿using System;
using System.Collections.Generic;
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

namespace RAMDesktopUI.Views
{
    /// <summary>
    /// Interaction logic for ImportManagerView.xaml
    /// </summary>
    public partial class ImportManagerView : HandyControl.Controls.Window
    {
        public ImportManagerView()
        {
            InitializeComponent();
        }

        private void SideMenu_SelectionChanged(object sender, HandyControl.Data.FunctionEventArgs<object> e)
        {

        }

        private void SideMenu_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
