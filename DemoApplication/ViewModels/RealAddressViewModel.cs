using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Controls.FuzzySearchComboBox;
using Controls.FuzzySearchComboBox.GroupRelationships;
using DemoApplication.DemoData;

namespace DemoApplication.ViewModels
{
    public class RealAddressViewModel : INotifyPropertyChanged
    {
        public Dictionary<int?, ValueContainer> AddressDictionary { get; private set; }
        public GroupRelationships GroupRelationships { get; private set; }

        public RealAddressViewModel()
        {
            AddressDictionary = Dictionaries.InitRealAddressDictionary();
            GroupRelationships = Dictionaries.InitGroupRelationships();
        }

        #region INotifyPropertyChanged members

        public virtual event PropertyChangedEventHandler PropertyChanged;


        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
