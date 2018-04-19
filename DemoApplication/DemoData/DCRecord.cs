using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DemoApplication.DemoData
{
    public interface ICloneable<T> : ICloneable
    {
        new T Clone();
    }

    public class DCRecord : ICloneable<DCRecord>, IComparable<DCRecord>
    {
        #region Fields

        public int districtId;
        public int cityId;
        public bool deleted;

        #endregion

        #region Constructors

        public DCRecord(int _districtId,
            int _cityId,
            bool _deleted)
        {
            districtId = _districtId;
            cityId = _cityId;
            deleted = _deleted;

        }

        public DCRecord()
        {
        }

        #endregion

        #region ICloneable<DCRecord> Members

        public DCRecord Clone()
        {
            DCRecord clone = new DCRecord();

            clone.districtId = districtId;
            clone.cityId = cityId;
            clone.deleted = deleted;

            return clone;
        }

        #endregion

        #region ICloneable Members

        object ICloneable.Clone()
        {
            return (this as ICloneable<DCRecord>).Clone();
        }

        #endregion

        #region IComparable<DCRecord> Members

        public int CompareTo(DCRecord other)
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

            if (!(other is DCRecord))
                return false;

            return
                ((DCRecord)other).districtId == districtId &&
                ((DCRecord)other).cityId == cityId &&
                ((DCRecord)other).deleted == deleted;

        }

        public static bool operator ==(DCRecord l, DCRecord r)
        {
            if ((object)l == null && (object)r == null)
                return true;
            if ((object)l == null)
                return false;
            return l.Equals(r);
        }

        public static bool operator !=(DCRecord l, DCRecord r)
        {
            if ((object)l == null)
                return false;
            return !l.Equals(r);
        }
    }
}
