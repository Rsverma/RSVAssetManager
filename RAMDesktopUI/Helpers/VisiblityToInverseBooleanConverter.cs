using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RAMDesktopUI.Helpers
{
    public sealed class VisiblityToInverseBooleanConverter : BooleanConverter<Visibility>
    {
        public VisiblityToInverseBooleanConverter() :
            base(Visibility.Visible, Visibility.Collapsed)
        { }

    }
}
