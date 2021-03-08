using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace RAMDesktopUI.Models
{
    public class WatchlistIndexModel : INotifyPropertyChanged
    {
        private string _symbol;

        public string Symbol
        {
            get { return _symbol; }
            set
            {
                _symbol = value;
                NotifyPropertyChanged();
            }
        }

        private string _Name;

        public string Name
        {
            get { return _Name; }
            set
            {
                _Name = value;
                NotifyPropertyChanged();
            }
        }

        private double _price;

        public double Price
        {
            get { return _price; }
            set
            {
                _price = value;
                NotifyPropertyChanged();
            }
        }

        private double _change;

        public double Change
        {
            get { return _change; }
            set
            {
                _change = value;
                NotifyPropertyChanged();
            }
        }

        private string _changeDescript;

        public string ChangeDescript
        {
            get { return _changeDescript; }
            set
            {
                _changeDescript = value;
                NotifyPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
