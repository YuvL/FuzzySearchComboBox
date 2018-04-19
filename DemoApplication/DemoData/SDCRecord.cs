using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DemoApplication.DemoData
{
    public class SDCRecord : ICloneable<SDCRecord>, IComparable<SDCRecord>
    {
        #region Fields

        public int streetId;
        public int districtId;
        public int cityId;
        public bool deleted;

        #endregion

        #region Constructors

        public SDCRecord(int _streetId,
            int _districtId,
            int _cityId,
            bool _deleted)
        {
            streetId = _streetId;
            districtId = _districtId;
            cityId = _cityId;
            deleted = _deleted;

        }

        public SDCRecord()
        {
        }

        #endregion

        #region ICloneable<SDCRecord> Members

        public SDCRecord Clone()
        {
            SDCRecord clone = new SDCRecord();

            clone.streetId = streetId;
            clone.districtId = districtId;
            clone.cityId = cityId;
            clone.deleted = deleted;

            return clone;
        }

        #endregion

        #region ICloneable Members

        object ICloneable.Clone()
        {
            return (this as ICloneable<SDCRecord>).Clone();
        }

        #endregion

        #region IComparable<SDCRecord> Members

        public int CompareTo(SDCRecord other)
        {
            return Equals(other) ? 0 : 1;
        }

        #endregion

        public override int GetHashCode()
        {
            int nHashCode = 0;

            nHashCode ^= ((Boolean)deleted).GetHashCode();

            return nHashCode;
        }

        public override bool Equals(object other)
        {
            if (other == null)
                return false;

            if (!(other is SDCRecord))
                return false;

            return
                ((SDCRecord)other).streetId == streetId &&
                ((SDCRecord)other).districtId == districtId &&
                ((SDCRecord)other).cityId == cityId &&
                ((SDCRecord)other).deleted == deleted;

        }

        public static bool operator ==(SDCRecord l, SDCRecord r)
        {
            if ((object)l == null && (object)r == null)
                return true;
            if ((object)l == null)
                return false;
            return l.Equals(r);
        }

        public static bool operator !=(SDCRecord l, SDCRecord r)
        {
            if ((object)l == null)
                return false;
            return !l.Equals(r);
        }
    }
}
