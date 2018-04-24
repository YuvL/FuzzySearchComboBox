using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controls.FuzzySearchComboBox.GroupRelationships
{
    public class GroupRelationships
    {
        public List<DCrelation> DC { get; private set; }

        public List<SDCrelation> SDC { get; private set; }

        public int? CurrentCityId { get; private set; }
        public int? CurrentDistrictId { get; private set; }
        public int? CurrentStreetId { get; private set; }

        private GroupRelationships()
        {
            DC = new List<DCrelation>();
            SDC = new List<SDCrelation>();
        }
        public GroupRelationships(List<DCrelation> dc, List<SDCrelation> sdc)
        {
            DC = dc;
            SDC = sdc;
        }

        public void SetCity(int? cityId)
        {
            CurrentCityId = cityId;
        }
        public void SetDistrict(int? districtId)
        {
            CurrentDistrictId = districtId;
        }
        public void SetStreet(int? streetId)
        {
            CurrentStreetId = streetId;
        }

        public GroupRelationships Clone()
        {
            var result = new GroupRelationships();
            foreach (var dc in DC)
            {
                result.DC.Add(new DCrelation(dc.CityId, dc.DistrictId, dc.IsDeleted));
            }
            foreach (var sdc in SDC)
            {
                result.SDC.Add(new SDCrelation(sdc.CityId, sdc.DistrictId, sdc.StreetId, sdc.IsDeleted));
            }
            return result;
        }
    }
}
