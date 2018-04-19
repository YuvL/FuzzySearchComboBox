using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Controls.FuzzySearchComboBox;
using Controls.FuzzySearchComboBox.GroupRelationships;
using DemoApplication.DemoData;
using Microsoft.Practices.Prism.Commands;

namespace DemoApplication.ViewModels
{
    public class RealAddressViewModel : INotifyPropertyChanged
    {
        private int? _streetId;
        public int? StreetID
        {
            get { return _streetId; }
            set
            {
                if (value != _streetId)
                {
                    _streetId = value;
                    OnPropertyChanged("StreetID");
                }
            }
        }

        private int? _districtId;
        public int? DistrictID
        {
            get { return _districtId; }
            set
            {
                if (value != _districtId)
                {
                    _districtId = value;
                    OnPropertyChanged("DistrictID");
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
                    OnPropertyChanged("CityID");
                }
            }
        }

        private int? _storageStreetId;
        public int? StorageStreetID
        {
            get { return _storageStreetId; }
            set
            {
                if (value != _storageStreetId)
                {
                    _storageStreetId = value;
                    OnPropertyChanged("StorageStreetID");
                }
            }
        }

        private int? _storageDistrictId;
        public int? StorageDistrictID
        {
            get { return _storageDistrictId; }
            set
            {
                if (value != _storageDistrictId)
                {
                    _storageDistrictId = value;
                    OnPropertyChanged("StorageDistrictID");
                }
            }
        }

        private int? _storageCityId;
        public int? StorageCityID
        {
            get { return _storageCityId; }
            set
            {
                if (value != _storageCityId)
                {
                    _storageCityId = value;
                    OnPropertyChanged("StorageCityID");
                }
            }
        }

        public Dictionary<int?, ValueContainer> AddressDictionary { get; private set; }
        public GroupRelationships GroupRelationships { get; private set; }

        public DelegateCommand ClearCommand { get; private set; }
        public DelegateCommand SaveCommand { get; private set; }
        public DelegateCommand ShowCommand { get; private set; }


        public RealAddressViewModel()
        {
            AddressDictionary = Dictionaries.InitRealAddressDictionary();
            GroupRelationships = Dictionaries.InitGroupRelationships();
            ClearCommand = new DelegateCommand(() => 
            {
                StreetID = null;
                DistrictID = null;
                CityID = null;
            });
            SaveCommand = new DelegateCommand(() =>
            {
                StorageStreetID = StreetID ;
                StorageDistrictID = DistrictID;
                StorageCityID = CityID;

            });
            ShowCommand = new DelegateCommand(() =>
            {
                StreetID = StorageStreetID;
                DistrictID = StorageDistrictID;
                CityID = StorageCityID;
            });
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
