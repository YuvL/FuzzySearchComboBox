using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DemoApplication.DemoData
{
    public class DictionariesInstance
    {
        public static List<DCRecord> DCRecords { get; set; }
        public static List<SDCRecord> SDCRecords { get; set; }

        public static Tm_Dictionary CityDictionary { get; set; }
        public static Tm_Dictionary DistrictDictionary { get; set; }
        public static Tm_Dictionary StreetDictionary { get; set; }

        public static bool InitUsingCache()
        {
            try
            {
                
                BasicDictionaries dictionaries = DictionariesCache.GetDictionariesOptimized();
                if (ReferenceEquals(dictionaries, null))
                {
                    DictionariesCache.ReloadOptimized();
                    dictionaries = DictionariesCache.GetDictionariesOptimized();
                }
                Load(dictionaries);
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        private static void Load(BasicDictionaries dictionaries)
        {
            CityDictionary = new Tm_Dictionary(dictionaries.CityDictionary);
            DistrictDictionary = new Tm_Dictionary(dictionaries.DistrictDictionary);
            StreetDictionary = new Tm_Dictionary(dictionaries.StreetDictionary);
            DCRecords = dictionaries.DCRecords;
            SDCRecords = dictionaries.SDCRecords;
        }
    }
}
