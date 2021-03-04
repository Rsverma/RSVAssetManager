using HandyControl.Tools;
using System;
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
    /// Interaction logic for CreateOrderView.xaml
    /// </summary>
    public partial class CreateOrderView : HandyControl.Controls.Window
    {
        public CreateOrderView()
        {
            ConfigHelper.Instance.SetLang("en-us");
            InitializeComponent();
        }
    }
}
