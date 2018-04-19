using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DemoApplication.DemoData
{
    public partial class Tm_DictionaryItem : ICloneable<Tm_DictionaryItem>, IComparable<Tm_DictionaryItem>
    {
        #region Fields

        public int nId;
        public string strValue;
        public string extId;
        public bool deleted;

        #endregion

        #region Constructors

        public Tm_DictionaryItem(int _nId,
            string _strValue,
            string _extId,
            bool _deleted)
        {
            nId = _nId;
            strValue = _strValue;
            extId = _extId;
            deleted = _deleted;

        }

        public Tm_DictionaryItem()
        {
        }

        #endregion

        #region ICloneable<Tm_DictionaryItem> Members

        public Tm_DictionaryItem Clone()
        {
            Tm_DictionaryItem clone = new Tm_DictionaryItem();

            clone.nId = nId;
            clone.strValue = strValue;
            clone.extId = extId;
            clone.deleted = deleted;

            return clone;
        }

        #endregion

        #region ICloneable Members

        object ICloneable.Clone()
        {
            return (this as ICloneable<Tm_DictionaryItem>).Clone();
        }

        #endregion

        #region IComparable<Tm_DictionaryItem> Members

        public int CompareTo(Tm_DictionaryItem other)
        {
            return Equals(other) ? 0 : 1;
        }

        #endregion

        public override int GetHashCode()
        {
            int nHashCode = 0;

            nHashCode ^= (strValue ?? String.Empty).GetHashCode();

            nHashCode ^= (extId ?? String.Empty).GetHashCode();

            nHashCode ^= ((Boolean)deleted).GetHashCode();

            return nHashCode;
        }

        public override bool Equals(object other)
        {
            if (other == null)
                return false;

            if (!(other is Tm_DictionaryItem))
                return false;

            return
                ((Tm_DictionaryItem)other).nId == nId &&
                ((Tm_DictionaryItem)other).strValue == strValue &&
                ((Tm_DictionaryItem)other).extId == extId &&
                ((Tm_DictionaryItem)other).deleted == deleted;

        }

        public static bool operator ==(Tm_DictionaryItem l, Tm_DictionaryItem r)
        {
            if ((object)l == null && (object)r == null)
                return true;
            if ((object)l == null)
                return false;
            return l.Equals(r);
        }

        public static bool operator !=(Tm_DictionaryItem l, Tm_DictionaryItem r)
        {
            if ((object)l == null)
                return false;
            return !l.Equals(r);
        }
    }
}
