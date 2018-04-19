using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controls.FuzzySearchComboBox.GroupRelationships
{
    public class DCrelation
    {
        public int CityId { get; private set; }
        public int DistrictId { get; private set; }
        public bool IsDeleted { get; private set; }

        public DCrelation(int cityId, int districtId, bool isDeleted)
        {
            CityId = cityId;
            DistrictId = districtId;
            IsDeleted = isDeleted;
        }
    }
}
