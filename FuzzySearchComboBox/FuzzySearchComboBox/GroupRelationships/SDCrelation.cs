using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controls.FuzzySearchComboBox.GroupRelationships
{
    public class SDCrelation
    {
        public int CityId { get; private set; }
        public int DistrictId { get; private set; }
        public int StreetId { get; private set; }
        public bool IsDeleted { get; private set; }

        public SDCrelation(int cityId, int districtId, int streetId, bool isDeleted)
        {
            CityId = cityId;
            DistrictId = districtId;
            StreetId = streetId;
            IsDeleted = isDeleted;
        }
    }
}
