using System.Collections.Generic;
using System.ComponentModel;
using Controls.FuzzySearchComboBox;

namespace DemoApplication.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public Dictionary<int?, ValueContainer> AddressDictionary { get; protected set; }

        private int? _countryId;
        public int? CountryID
        {
            get { return _countryId; }
            set
            {
                if (value != _countryId)
                {
                    _countryId = value;
                    OnPropertyChanged("CountryID");
                    OnPropertyChanged("RegionID");
                    OnPropertyChanged("CityID");
                }
            }
        }

        private int? _regionId;
        public int? RegionID
        {
            get { return _regionId; }
            set
            {
                if (value != _regionId)
                {
                    _regionId = value;
                    OnPropertyChanged("CountryID");
                    OnPropertyChanged("RegionID");
                    OnPropertyChanged("CityID");
                }
            }
        }

        private int? _cityId;
        public int? CityID
        {
            get { return _cityId; }
            set
            {
                if (value != _cityId)
                {
                    _cityId = value;
                    OnPropertyChanged("CountryID");
                    OnPropertyChanged("RegionID");
                    OnPropertyChanged("CityID");
                }
            }
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
