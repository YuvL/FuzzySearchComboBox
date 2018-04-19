using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Xml.Serialization;

namespace DemoApplication.DemoData
{
    public static class DictionariesCache
    {
        private static readonly string CachePathLegacy;
        private static readonly string CachePath;
        static DictionariesCache()
        {
            string directory = AppDomain.CurrentDomain.BaseDirectory;
            CachePathLegacy = AppDomain.CurrentDomain.BaseDirectory + "DemoData\\";
                
            CachePath = CachePathLegacy + "dictionariesCacheOptimized";
        }

        internal static BasicDictionaries GetDictionariesOptimized()
        {
            try
            {
                using (var reader = new StreamReader(CachePath))
                {
                    return (BasicDictionaries)new XmlSerializer(typeof(BasicDictionaries)).Deserialize(reader);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static void ReloadOptimized()
        {
            if (File.Exists(CachePathLegacy))
            {
                using (var reader = new StreamReader(CachePathLegacy, false))
                {
                    using (var writer = new StreamWriter(CachePath, false))
                    {
                        new XmlSerializer(typeof(BasicDictionaries)).Serialize(writer,
                            (BasicDictionaries)XStreamFactory.XStream.FromXml<object>(reader.ReadToEnd()));
                    }
                }
            }
        }

    }
}
