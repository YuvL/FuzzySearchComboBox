using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controls.FuzzySearchComboBox;
using Controls.FuzzySearchComboBox.GroupRelationships;

namespace DemoApplication.DemoData
{
    public static class MoreLinqHelper
    {
        public static Tm_DictionaryItem GetItemById(this Tm_Dictionary sourceFirs, int Id)
        {
            return sourceFirs.Dictionary.FirstOrDefault(x => x.nId == Id);
        }
    }

    public static class Dictionaries
    {
        public static IEnumerable<T> DistinctBy<T, T1>(this IEnumerable<T> source, Func<T, T1> func)
        {
            return source.GroupBy(func).Select(x => x.First());
        }

        private static List<Tuple<ValueContainer, ValueContainer, ValueContainer>> CreateAddressDictionary()
        {
            //get addresses like country - region - city
            var addresses = new List<Tuple<ValueContainer, ValueContainer, ValueContainer>>();
            //Germany
            var cityEmpty = new ValueContainer(null, null);
            addresses.Add(Tuple.Create(new ValueContainer(1, "Germany"), new ValueContainer(1, "Bavaria"), cityEmpty));
            addresses.Add(Tuple.Create(new ValueContainer(1, "Germany"), new ValueContainer(1, "Bavaria"),
                new ValueContainer(1, "Munich")));
            addresses.Add(Tuple.Create(new ValueContainer(1, "Germany"), new ValueContainer(1, "Bavaria"),
                new ValueContainer(2, "Bamberg")));
            addresses.Add(Tuple.Create(new ValueContainer(1, "Germany"), new ValueContainer(1, "Bavaria"),
                new ValueContainer(3, "Nuremberg")));

            addresses.Add(Tuple.Create(new ValueContainer(1, "Germany"), new ValueContainer(2, "Saxony"), cityEmpty));
            addresses.Add(Tuple.Create(new ValueContainer(1, "Germany"), new ValueContainer(2, "Saxony"),
                new ValueContainer(4, "Drezden")));
            addresses.Add(Tuple.Create(new ValueContainer(1, "Germany"), new ValueContainer(2, "Saxony"),
                new ValueContainer(5, "Leipzig")));
            addresses.Add(Tuple.Create(new ValueContainer(1, "Germany"), new ValueContainer(2, "Saxony"),
                new ValueContainer(6, "Zwickau")));

            addresses.Add(Tuple.Create(new ValueContainer(1, "Germany"), new ValueContainer(3, "Thuringia"), cityEmpty));
            addresses.Add(Tuple.Create(new ValueContainer(1, "Germany"), new ValueContainer(3, "Thuringia"),
                new ValueContainer(7, "Erfurt")));
            addresses.Add(Tuple.Create(new ValueContainer(1, "Germany"), new ValueContainer(3, "Thuringia"),
                new ValueContainer(8, "Jena")));
            addresses.Add(Tuple.Create(new ValueContainer(1, "Germany"), new ValueContainer(3, "Thuringia"),
                new ValueContainer(9, "Gera")));



            //France
            addresses.Add(Tuple.Create(new ValueContainer(2, "France"), new ValueContainer(4, "Burgundy"), cityEmpty));
            addresses.Add(Tuple.Create(new ValueContainer(2, "France"), new ValueContainer(4, "Burgundy"),
                new ValueContainer(10, "Dijon")));
            addresses.Add(Tuple.Create(new ValueContainer(2, "France"), new ValueContainer(4, "Burgundy"),
                new ValueContainer(11, "Beaune")));
            addresses.Add(Tuple.Create(new ValueContainer(2, "France"), new ValueContainer(4, "Burgundy"),
                new ValueContainer(12, "Beze")));

            addresses.Add(Tuple.Create(new ValueContainer(2, "France"), new ValueContainer(5, "Britany"), cityEmpty));
            addresses.Add(Tuple.Create(new ValueContainer(2, "France"), new ValueContainer(5, "Britany"),
                new ValueContainer(13, "Renes")));
            addresses.Add(Tuple.Create(new ValueContainer(2, "France"), new ValueContainer(5, "Britany"),
                new ValueContainer(14, "Brest")));

            addresses.Add(Tuple.Create(new ValueContainer(2, "France"), new ValueContainer(6, "Normandy"), cityEmpty));
            addresses.Add(Tuple.Create(new ValueContainer(2, "France"), new ValueContainer(6, "Normandy"),
                new ValueContainer(15, "Caen")));
            addresses.Add(Tuple.Create(new ValueContainer(2, "France"), new ValueContainer(6, "Normandy"),
                new ValueContainer(16, "Le Havre")));
            addresses.Add(Tuple.Create(new ValueContainer(2, "France"), new ValueContainer(6, "Normandy"),
                new ValueContainer(17, "Rouen")));


            //Spain
            addresses.Add(Tuple.Create(new ValueContainer(3, "Spain"), new ValueContainer(7, "Catalonia"), cityEmpty));
            addresses.Add(Tuple.Create(new ValueContainer(3, "Spain"), new ValueContainer(7, "Catalonia"),
                new ValueContainer(18, "Barcelona")));
            addresses.Add(Tuple.Create(new ValueContainer(3, "Spain"), new ValueContainer(7, "Catalonia"),
                new ValueContainer(19, "Girona")));
            addresses.Add(Tuple.Create(new ValueContainer(3, "Spain"), new ValueContainer(7, "Catalonia"),
                new ValueContainer(20, "Tarragona")));

            addresses.Add(Tuple.Create(new ValueContainer(3, "Spain"), new ValueContainer(8, "Aragon"), cityEmpty));
            addresses.Add(Tuple.Create(new ValueContainer(3, "Spain"), new ValueContainer(8, "Aragon"),
                new ValueContainer(21, "Saragossa")));
            addresses.Add(Tuple.Create(new ValueContainer(3, "Spain"), new ValueContainer(8, "Aragon"),
                new ValueContainer(22, "Teruel")));
            addresses.Add(Tuple.Create(new ValueContainer(3, "Spain"), new ValueContainer(8, "Aragon"),
                new ValueContainer(23, "Huesca")));

            addresses.Add(Tuple.Create(new ValueContainer(3, "Spain"), new ValueContainer(9, "Andalucia"), cityEmpty));
            addresses.Add(Tuple.Create(new ValueContainer(3, "Spain"), new ValueContainer(9, "Andalucia"),
                new ValueContainer(24, "Sevilla")));
            addresses.Add(Tuple.Create(new ValueContainer(3, "Spain"), new ValueContainer(9, "Andalucia"),
                new ValueContainer(25, "Jaen")));
            addresses.Add(Tuple.Create(new ValueContainer(3, "Spain"), new ValueContainer(9, "Andalucia"),
                new ValueContainer(26, "Granada")));

            //Finland
            addresses.Add(Tuple.Create(new ValueContainer(4, "Finland"), new ValueContainer(10, "Uusimaa"), cityEmpty));
            addresses.Add(Tuple.Create(new ValueContainer(4, "Finland"), new ValueContainer(10, "Uusimaa"),
                new ValueContainer(27, "Helsinki")));
            addresses.Add(Tuple.Create(new ValueContainer(4, "Finland"), new ValueContainer(10, "Uusimaa"),
                new ValueContainer(28, "Espoo")));
            addresses.Add(Tuple.Create(new ValueContainer(4, "Finland"), new ValueContainer(10, "Uusimaa"),
                new ValueContainer(29, "Lohja")));
            addresses.Add(Tuple.Create(new ValueContainer(4, "Finland"), new ValueContainer(10, "Uusimaa"),
                new ValueContainer(30, "Vantaa")));
            addresses.Add(Tuple.Create(new ValueContainer(4, "Finland"), new ValueContainer(10, "Uusimaa"),
                new ValueContainer(31, "Kauniainen")));
            addresses.Add(Tuple.Create(new ValueContainer(4, "Finland"), new ValueContainer(10, "Uusimaa"),
                new ValueContainer(32, "Hyvinkаа")));
            addresses.Add(Tuple.Create(new ValueContainer(4, "Finland"), new ValueContainer(10, "Uusimaa"),
                new ValueContainer(33, "Kerava")));
            addresses.Add(Tuple.Create(new ValueContainer(4, "Finland"), new ValueContainer(10, "Uusimaa"),
                new ValueContainer(34, "Karkkila")));
            addresses.Add(Tuple.Create(new ValueContainer(4, "Finland"), new ValueContainer(10, "Uusimaa"),
                new ValueContainer(35, "Kirkkonummi")));
            addresses.Add(Tuple.Create(new ValueContainer(4, "Finland"), new ValueContainer(10, "Uusimaa"),
                new ValueContainer(36, "Pornainen")));
            addresses.Add(Tuple.Create(new ValueContainer(4, "Finland"), new ValueContainer(10, "Uusimaa"),
                new ValueContainer(37, "Siuntio")));
            addresses.Add(Tuple.Create(new ValueContainer(4, "Finland"), new ValueContainer(10, "Uusimaa"),
                new ValueContainer(38, "Tuusula")));
            addresses.Add(Tuple.Create(new ValueContainer(4, "Finland"), new ValueContainer(10, "Uusimaa"),
                new ValueContainer(39, "Karjalohja")));
            addresses.Add(Tuple.Create(new ValueContainer(4, "Finland"), new ValueContainer(10, "Uusimaa"),
                new ValueContainer(40, "Nummi-Pusula")));
            addresses.Add(Tuple.Create(new ValueContainer(4, "Finland"), new ValueContainer(10, "Uusimaa"),
                new ValueContainer(41, "Vihti")));

            addresses.Add(Tuple.Create(new ValueContainer(4, "Finland"), new ValueContainer(11, "Etela-Savo"), cityEmpty));
            addresses.Add(Tuple.Create(new ValueContainer(4, "Finland"), new ValueContainer(11, "Etela-Savo"),
                new ValueContainer(42, "Mikkeli")));
            addresses.Add(Tuple.Create(new ValueContainer(4, "Finland"), new ValueContainer(11, "Etela-Savo"),
                new ValueContainer(43, "Juva")));
            addresses.Add(Tuple.Create(new ValueContainer(4, "Finland"), new ValueContainer(11, "Etela-Savo"),
                new ValueContainer(44, "Otava")));
            addresses.Add(Tuple.Create(new ValueContainer(4, "Finland"), new ValueContainer(11, "Etela-Savo"),
                new ValueContainer(45, "Pieksamaki")));
            addresses.Add(Tuple.Create(new ValueContainer(4, "Finland"), new ValueContainer(11, "Etela-Savo"),
                new ValueContainer(46, "Savonlinna")));
            addresses.Add(Tuple.Create(new ValueContainer(4, "Finland"), new ValueContainer(11, "Etela-Savo"),
                new ValueContainer(47, "Haukivesi")));
            addresses.Add(Tuple.Create(new ValueContainer(4, "Finland"), new ValueContainer(11, "Etela-Savo"),
                new ValueContainer(48, "Kangasniemi")));

            addresses.Add(Tuple.Create(new ValueContainer(4, "Finland"), new ValueContainer(12, "Lappi"), cityEmpty));
            addresses.Add(Tuple.Create(new ValueContainer(4, "Finland"), new ValueContainer(12, "Lappi"),
                new ValueContainer(49, "Rovaniemi")));
            addresses.Add(Tuple.Create(new ValueContainer(4, "Finland"), new ValueContainer(12, "Lappi"),
                new ValueContainer(50, "Kolari")));
            addresses.Add(Tuple.Create(new ValueContainer(4, "Finland"), new ValueContainer(12, "Lappi"),
                new ValueContainer(51, "Inari")));
            addresses.Add(Tuple.Create(new ValueContainer(4, "Finland"), new ValueContainer(12, "Lappi"),
                new ValueContainer(52, "Tornio")));
            addresses.Add(Tuple.Create(new ValueContainer(4, "Finland"), new ValueContainer(12, "Lappi"),
                new ValueContainer(53, "Kemi")));
            addresses.Add(Tuple.Create(new ValueContainer(4, "Finland"), new ValueContainer(12, "Lappi"),
                new ValueContainer(54, "Sodankyla")));
            addresses.Add(Tuple.Create(new ValueContainer(4, "Finland"), new ValueContainer(12, "Lappi"),
                new ValueContainer(55, "Keminmaa")));
            addresses.Add(Tuple.Create(new ValueContainer(4, "Finland"), new ValueContainer(12, "Lappi"),
                new ValueContainer(56, "Ylitornio")));
            addresses.Add(Tuple.Create(new ValueContainer(4, "Finland"), new ValueContainer(12, "Lappi"),
                new ValueContainer(57, "Ranua")));
            addresses.Add(Tuple.Create(new ValueContainer(4, "Finland"), new ValueContainer(12, "Lappi"),
                new ValueContainer(58, "Salla")));
            addresses.Add(Tuple.Create(new ValueContainer(4, "Finland"), new ValueContainer(12, "Lappi"),
                new ValueContainer(59, "Pello")));
            addresses.Add(Tuple.Create(new ValueContainer(4, "Finland"), new ValueContainer(12, "Lappi"),
                new ValueContainer(60, "Posio")));
            addresses.Add(Tuple.Create(new ValueContainer(4, "Finland"), new ValueContainer(12, "Lappi"),
                new ValueContainer(61, "Simo")));
            addresses.Add(Tuple.Create(new ValueContainer(4, "Finland"), new ValueContainer(12, "Lappi"),
                new ValueContainer(62, "Tervola")));
            addresses.Add(Tuple.Create(new ValueContainer(4, "Finland"), new ValueContainer(12, "Lappi"),
                new ValueContainer(63, "Muonio")));
            addresses.Add(Tuple.Create(new ValueContainer(4, "Finland"), new ValueContainer(12, "Lappi"),
                new ValueContainer(64, "Utsjoki")));
            addresses.Add(Tuple.Create(new ValueContainer(4, "Finland"), new ValueContainer(12, "Lappi"),
                new ValueContainer(65, "Savukoski")));
            addresses.Add(Tuple.Create(new ValueContainer(4, "Finland"), new ValueContainer(12, "Lappi"),
                new ValueContainer(66, "Pelkosenniemi")));

            return addresses;
        }

        private static List<Tuple<ValueContainer, ValueContainer, ValueContainer>> CreateAddressDictionaryExt()
        {
            var addresses = CreateAddressDictionary();

            //1 Germany-----------------------------------------
            //1.1 city
            addresses.Add(Tuple.Create(new ValueContainer(1, "Germany"), new ValueContainer(1, "Bavaria"),
                new ValueContainer(1000, "GermanyAndFrance")));

            addresses.Add(Tuple.Create(new ValueContainer(1, "Germany"), new ValueContainer(2, "Saxony"),
                new ValueContainer(100, "SaxonyAndThuringia")));
            addresses.Add(Tuple.Create(new ValueContainer(1, "Germany"), new ValueContainer(3, "Thuringia"),
                new ValueContainer(100, "SaxonyAndThuringia")));


            //2 France------------------------------------------
            //2.1 city
            addresses.Add(Tuple.Create(new ValueContainer(2, "Germany"), new ValueContainer(4, "Burgundy"),
                new ValueContainer(1000, "GermanyAndFrance")));

            addresses.Add(Tuple.Create(new ValueContainer(2, "France"), new ValueContainer(5, "Britany"),
                new ValueContainer(10000, "FranceNormandyBritany_SpainCataloniaAragonAndalucia")));
            addresses.Add(Tuple.Create(new ValueContainer(2, "France"), new ValueContainer(6, "Normandy"),
                new ValueContainer(10000, "FranceNormandyBritany_SpainCataloniaAragonAndalucia")));


            //3 Spain-------------------------------------------
            //3.1 city
            addresses.Add(Tuple.Create(new ValueContainer(3, "Spain"), new ValueContainer(7, "Catalonia"),
                new ValueContainer(10000, "FranceNormandyBritany_SpainCataloniaAragonAndalucia")));
            addresses.Add(Tuple.Create(new ValueContainer(3, "Spain"), new ValueContainer(8, "Aragon"),
                new ValueContainer(10000, "FranceNormandyBritany_SpainCataloniaAragonAndalucia")));
            addresses.Add(Tuple.Create(new ValueContainer(3, "Spain"), new ValueContainer(9, "Andalucia"),
                new ValueContainer(10000, "FranceNormandyBritany_SpainCataloniaAragonAndalucia")));

            return addresses;
        }

        public static Dictionary<int?, ValueContainer> InitAddressDictionary()
        {
            var addresses = CreateAddressDictionary();

            //group by country
            foreach (var countryGrouping in addresses.GroupBy(x => x.Item1))
            {
                var regions = countryGrouping
                    .Select(x => x.Item2)
                    .Distinct()
                    .Where(x => x.ID != null)
                    .ToDictionary(key => key.ID);

                foreach (var country in countryGrouping.Select(x => x.Item1))
                {
                    country.Childs = regions;
                }
            }

            //group by region
            foreach (var regionGrouping in addresses.GroupBy(x => x.Item2))
            {
                var countries = regionGrouping
                    .Select(x => x.Item1)
                    .Distinct()
                    .Where(x => x.ID != null)
                    .ToDictionary(key => key.ID);

                var cities = regionGrouping
                    .Select(x => x.Item3)
                    .Distinct()
                    .Where(x => x.ID != null)
                    .ToDictionary(key => key.ID);

                foreach (var region in regionGrouping.Select(x => x.Item2))
                {
                    region.Parents = countries;
                    region.Childs = cities;
                }
            }

            //group by city
            foreach (var cityGrouping in addresses.GroupBy(x => x.Item3))
            {
                var districts = cityGrouping
                    .Select(x => x.Item2)
                    .Distinct()
                    .Where(x => x.ID != null)
                    .ToDictionary(key => key.ID);

                foreach (var city in cityGrouping.Select(x => x.Item3))
                {
                    city.Parents = districts;
                }
            }

            return addresses.Select(x => x.Item1).DistinctBy(x => x.ID).ToDictionary(x => x.ID);

        }

        public static Dictionary<int?, ValueContainer> InitAddressDictionaryExt()
        {
            var addresses = CreateAddressDictionaryExt();

            //group by country
            foreach (var countryGrouping in addresses.GroupBy(x => x.Item1))
            {
                var regions = countryGrouping
                    .Select(x => x.Item2)
                    .Distinct()
                    .Where(x => x.ID != null)
                    .ToDictionary(key => key.ID);

                foreach (var country in countryGrouping.Select(x => x.Item1))
                {
                    country.Childs = regions;
                }
            }

            //group by region
            foreach (var regionGrouping in addresses.GroupBy(x => x.Item2))
            {
                var countries = regionGrouping
                    .Select(x => x.Item1)
                    .Distinct()
                    .Where(x => x.ID != null)
                    .ToDictionary(key => key.ID);

                var cities = regionGrouping
                    .Select(x => x.Item3)
                    .Distinct()
                    .Where(x => x.ID != null)
                    .ToDictionary(key => key.ID);

                foreach (var region in regionGrouping.Select(x => x.Item2))
                {
                    region.Parents = countries;
                    region.Childs = cities;
                }
            }

            //group by city
            foreach (var cityGrouping in addresses.GroupBy(x => x.Item3))
            {
                var districts = cityGrouping
                    .Select(x => x.Item2)
                    .Distinct()
                    .Where(x => x.ID != null)
                    .ToDictionary(key => key.ID);

                foreach (var city in cityGrouping.Select(x => x.Item3))
                {
                    city.Parents = districts;
                }
            }

            return addresses.Select(x => x.Item1).DistinctBy(x => x.ID).ToDictionary(x => x.ID);

        }

        public static Dictionary<int?, ValueContainer> InitRealAddressDictionary()
        {
            var dcRecords = DictionariesInstance.DCRecords.ToArray();
            var sdcRecords = DictionariesInstance.SDCRecords.ToArray();

            //get addresses like city - district - street
            var addresses = new List<Tuple<ValueContainer, ValueContainer, ValueContainer>>();
            foreach (var dc in dcRecords)
            {
                var c = DictionariesInstance.CityDictionary.GetItemById(dc.cityId);
                var d = DictionariesInstance.DistrictDictionary.GetItemById(dc.districtId);

                var city = new ValueContainer(c.nId, c.strValue, c.deleted);
                var district = new ValueContainer(d.nId, d.strValue, d.deleted);
                var street = new ValueContainer(null, null);

                addresses.Add(Tuple.Create(city, district, street));
            }

            foreach (var sdc in sdcRecords)
            {
                var c = DictionariesInstance.CityDictionary.GetItemById(sdc.cityId);
                var d = DictionariesInstance.DistrictDictionary.GetItemById(sdc.districtId);
                var s = DictionariesInstance.StreetDictionary.GetItemById(sdc.streetId);

                var city = new ValueContainer(c.nId, c.strValue, c.deleted);
                var district = new ValueContainer(d.nId, d.strValue, d.deleted);
                var street = new ValueContainer(s.nId, s.strValue, s.deleted);

                addresses.Add(Tuple.Create(city, district, street));
            }

            // добавим города, к которым не привязано ни улиц, ни районов http://pm/issues/5762
            var cityWithDistricts = dcRecords.Select(x => x.cityId).Concat(sdcRecords.Select(x => x.cityId)).Distinct().ToArray();
            foreach (var c in DictionariesInstance.CityDictionary.Dictionary.Where(x => !cityWithDistricts.Contains(x.nId)))
            {
                var city = new ValueContainer(c.nId, c.strValue, c.deleted);
                var district = new ValueContainer(null, null);
                var street = new ValueContainer(null, null);
                addresses.Add(Tuple.Create(city, district, street));
            }

            //get deleted districts
            var existingDistrictIds = dcRecords.Select(x => x.districtId).Concat(sdcRecords.Select(x => x.districtId)).Distinct().ToArray();
            var deletedDistricts = DictionariesInstance.DistrictDictionary.Dictionary.Where(x => !existingDistrictIds.Contains(x.nId)).Select(x => new ValueContainer(x.nId, x.strValue, isDeleted: true)).ToArray();
            //get deleted streets
            var existingStreetIds = sdcRecords.Select(x => x.streetId).Distinct().ToArray();
            var deletedStreets = DictionariesInstance.StreetDictionary.Dictionary.Where(x => !existingStreetIds.Contains(x.nId)).Select(x => new ValueContainer(x.nId, x.strValue, isDeleted: true)).ToArray();
            // выбираем удаленные города, они должны отображаться в старых карточках
            var deletedCities = DictionariesInstance.CityDictionary.Dictionary.Where(x => x.deleted)
                .Select(x => new ValueContainer(x.nId, x.strValue, true)).ToArray();

            //group by city
            foreach (var cityGrouping in addresses.GroupBy(x => x.Item1))
            {
                var districts = cityGrouping
                    .Select(x => x.Item2)
                    .Concat(deletedDistricts)
                    .Distinct()
                    .Where(x => x.ID != null)
                    .ToDictionary(key => key.ID);

                foreach (var city in cityGrouping.Select(x => x.Item1))
                {
                    city.Childs = districts;
                }
            }

            //group by district
            foreach (var districtGrouping in addresses.GroupBy(x => x.Item2))
            {
                var cities = districtGrouping
                    .Select(x => x.Item1)
                    .Concat(deletedCities)
                    .Distinct()
                    .Where(x => x.ID != null)
                    .ToDictionary(key => key.ID);

                var streets = districtGrouping
                    .Select(x => x.Item3)
                    .Concat(deletedStreets)
                    .Distinct()
                    .Where(x => x.ID != null)
                    .ToDictionary(key => key.ID);

                foreach (var district in districtGrouping.Select(x => x.Item2))
                {
                    district.Parents = cities;
                    district.Childs = streets;
                }
            }

            //group by street
            foreach (var streetGrouping in addresses.GroupBy(x => x.Item3))
            {
                var districts = streetGrouping
                    .Select(x => x.Item2)
                    .Concat(deletedDistricts)
                    .Distinct()
                    .Where(x => x.ID != null)
                    .ToDictionary(key => key.ID);

                foreach (var street in streetGrouping.Select(x => x.Item3))
                {
                    street.Parents = districts;
                }
            }

            var result = addresses.Select(x => x.Item1).DistinctBy(x => x.ID).ToDictionary(x => x.ID);
            return result;
        }

        public static GroupRelationships InitGroupRelationships()
        {
            var dcRecords = DictionariesInstance.DCRecords;
            var sdcRecords = DictionariesInstance.SDCRecords;
            var dc = new List<DCrelation>();
            var sdc = new List<SDCrelation>();

            dcRecords.ForEach(x => dc.Add(new DCrelation(x.cityId, x.districtId, x.deleted)));
            sdcRecords.ForEach(x => sdc.Add(new SDCrelation(x.cityId, x.districtId, x.streetId, x.deleted)));
            return new GroupRelationships(dc, sdc);
        }
    }
}
