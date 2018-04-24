using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DemoApplication.DemoData
{
    public class BasicDictionaries : ICloneable<BasicDictionaries>, IComparable<BasicDictionaries>
    {
        #region Fields
        public List<Tm_DictionaryItem> CityDictionary;
        public List<Tm_DictionaryItem> DistrictDictionary;
        public List<Tm_DictionaryItem> StreetDictionary;
        public List<DCRecord> DCRecords;
        public List<SDCRecord> SDCRecords;

        #endregion

        #region Constructors

        public BasicDictionaries(List<Tm_DictionaryItem> _CityDictionary, List<Tm_DictionaryItem> _DistrictDictionary, List<Tm_DictionaryItem> _StreetDictionary,
            List<DCRecord> _DCRecords, List<SDCRecord> _SDCRecords)
        {
            CityDictionary = _CityDictionary;
            DistrictDictionary = _DistrictDictionary;
            StreetDictionary = _StreetDictionary;
            DCRecords = _DCRecords;
            SDCRecords = _SDCRecords;
        }

        public BasicDictionaries()
        {
        }

        #endregion

        #region ICloneable<BasicDictionaries> Members

        public BasicDictionaries Clone()
        {
            BasicDictionaries clone = new BasicDictionaries();
            clone.CityDictionary = new List<Tm_DictionaryItem>();
            if (CityDictionary != null)
                foreach (Tm_DictionaryItem item in CityDictionary)
                    clone.CityDictionary.Add(item);

            clone.DistrictDictionary = new List<Tm_DictionaryItem>();
            if (DistrictDictionary != null)
                foreach (Tm_DictionaryItem item in DistrictDictionary)
                    clone.DistrictDictionary.Add(item);

            clone.StreetDictionary = new List<Tm_DictionaryItem>();
            if (StreetDictionary != null)
                foreach (Tm_DictionaryItem item in StreetDictionary)
                    clone.StreetDictionary.Add(item);
            clone.DCRecords = new List<DCRecord>();
            if (DCRecords != null)
                foreach (DCRecord item in DCRecords)
                    clone.DCRecords.Add(item);

            clone.SDCRecords = new List<SDCRecord>();
            if (SDCRecords != null)
                foreach (SDCRecord item in SDCRecords)
                    clone.SDCRecords.Add(item);
            return clone;
        }

        #endregion

        #region ICloneable Members

        object ICloneable.Clone()
        {
            return (this as ICloneable<BasicDictionaries>).Clone();
        }

        #endregion

        #region IComparable<BasicDictionaries> Members

        public int CompareTo(BasicDictionaries other)
        {
            return Equals(other) ? 0 : 1;
        }

        #endregion

        public override int GetHashCode()
        {
            int nHashCode = 0;
            if (DCRecords != null)
                foreach (DCRecord item in DCRecords)
                    nHashCode ^= item.GetHashCode();

            if (SDCRecords != null)
                foreach (SDCRecord item in SDCRecords)
                    nHashCode ^= item.GetHashCode();
            return nHashCode;
        }

        public override bool Equals(object other)
        {
            if (other == null)
                return false;

            if (!(other is BasicDictionaries))
                return false;
            if (((BasicDictionaries)other).DCRecords != null)
            {
                if (((BasicDictionaries)other).DCRecords.Count != DCRecords.Count)
                    return false;
                for (int i = 0; i < DCRecords.Count; i++)
                    if (((BasicDictionaries)other).DCRecords[i] != DCRecords[i])
                        return false;
            }

            if (((BasicDictionaries)other).SDCRecords != null)
            {
                if (((BasicDictionaries)other).SDCRecords.Count != SDCRecords.Count)
                    return false;
                for (int i = 0; i < SDCRecords.Count; i++)
                    if (((BasicDictionaries)other).SDCRecords[i] != SDCRecords[i])
                        return false;
            }
            return true;
        }

        public static bool operator ==(BasicDictionaries l, BasicDictionaries r)
        {
            if ((object)l == null && (object)r == null)
                return true;
            if ((object)l == null)
                return false;
            return l.Equals(r);
        }

        public static bool operator !=(BasicDictionaries l, BasicDictionaries r)
        {
            if ((object)l == null)
                return false;
            return !l.Equals(r);
        }
    }
}
