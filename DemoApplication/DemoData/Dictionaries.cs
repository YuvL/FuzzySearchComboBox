using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controls.FuzzySearchComboBox;

namespace DemoApplication.DemoData
{
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
            addresses.Add(Tuple.Create(new ValueContainer(1, "Germany"), new ValueContainer(1, "Bavaria"), new ValueContainer(1, "Munich")));
            addresses.Add(Tuple.Create(new ValueContainer(1, "Germany"), new ValueContainer(1, "Bavaria"), new ValueContainer(2, "Bamberg")));
            addresses.Add(Tuple.Create(new ValueContainer(1, "Germany"), new ValueContainer(1, "Bavaria"), new ValueContainer(3, "Nuremberg")));

            addresses.Add(Tuple.Create(new ValueContainer(1, "Germany"), new ValueContainer(2, "Saxony"), cityEmpty));
            addresses.Add(Tuple.Create(new ValueContainer(1, "Germany"), new ValueContainer(2, "Saxony"), new ValueContainer(4, "Drezden")));
            addresses.Add(Tuple.Create(new ValueContainer(1, "Germany"), new ValueContainer(2, "Saxony"), new ValueContainer(5, "Leipzig")));
            addresses.Add(Tuple.Create(new ValueContainer(1, "Germany"), new ValueContainer(2, "Saxony"), new ValueContainer(6, "Zwickau")));

            addresses.Add(Tuple.Create(new ValueContainer(1, "Germany"), new ValueContainer(3, "Thuringia"), cityEmpty));
            addresses.Add(Tuple.Create(new ValueContainer(1, "Germany"), new ValueContainer(3, "Thuringia"), new ValueContainer(7, "Erfurt")));
            addresses.Add(Tuple.Create(new ValueContainer(1, "Germany"), new ValueContainer(3, "Thuringia"), new ValueContainer(8, "Jena")));
            addresses.Add(Tuple.Create(new ValueContainer(1, "Germany"), new ValueContainer(3, "Thuringia"), new ValueContainer(9, "Gera")));



            //France
            addresses.Add(Tuple.Create(new ValueContainer(2, "France"), new ValueContainer(4, "Burgundy"), cityEmpty));
            addresses.Add(Tuple.Create(new ValueContainer(2, "France"), new ValueContainer(4, "Burgundy"), new ValueContainer(10, "Dijon")));
            addresses.Add(Tuple.Create(new ValueContainer(2, "France"), new ValueContainer(4, "Burgundy"), new ValueContainer(11, "Beaune")));
            addresses.Add(Tuple.Create(new ValueContainer(2, "France"), new ValueContainer(4, "Burgundy"), new ValueContainer(12, "Beze")));

            addresses.Add(Tuple.Create(new ValueContainer(2, "France"), new ValueContainer(5, "Britany"), cityEmpty));
            addresses.Add(Tuple.Create(new ValueContainer(2, "France"), new ValueContainer(5, "Britany"), new ValueContainer(13, "Renes")));
            addresses.Add(Tuple.Create(new ValueContainer(2, "France"), new ValueContainer(5, "Britany"), new ValueContainer(14, "Brest")));

            addresses.Add(Tuple.Create(new ValueContainer(2, "France"), new ValueContainer(6, "Normandy"), cityEmpty));
            addresses.Add(Tuple.Create(new ValueContainer(2, "France"), new ValueContainer(6, "Normandy"), new ValueContainer(15, "Caen")));
            addresses.Add(Tuple.Create(new ValueContainer(2, "France"), new ValueContainer(6, "Normandy"), new ValueContainer(16, "Le Havre")));
            addresses.Add(Tuple.Create(new ValueContainer(2, "France"), new ValueContainer(6, "Normandy"), new ValueContainer(17, "Rouen")));


            //Spain
            addresses.Add(Tuple.Create(new ValueContainer(3, "Spain"), new ValueContainer(7, "Catalonia"), cityEmpty));
            addresses.Add(Tuple.Create(new ValueContainer(3, "Spain"), new ValueContainer(7, "Catalonia"), new ValueContainer(18, "Barcelona")));
            addresses.Add(Tuple.Create(new ValueContainer(3, "Spain"), new ValueContainer(7, "Catalonia"), new ValueContainer(19, "Girona")));
            addresses.Add(Tuple.Create(new ValueContainer(3, "Spain"), new ValueContainer(7, "Catalonia"), new ValueContainer(20, "Tarragona")));

            addresses.Add(Tuple.Create(new ValueContainer(3, "Spain"), new ValueContainer(8, "Aragon"), cityEmpty));
            addresses.Add(Tuple.Create(new ValueContainer(3, "Spain"), new ValueContainer(8, "Aragon"), new ValueContainer(21, "Saragossa")));
            addresses.Add(Tuple.Create(new ValueContainer(3, "Spain"), new ValueContainer(8, "Aragon"), new ValueContainer(22, "Teruel")));
            addresses.Add(Tuple.Create(new ValueContainer(3, "Spain"), new ValueContainer(8, "Aragon"), new ValueContainer(23, "Huesca")));

            addresses.Add(Tuple.Create(new ValueContainer(3, "Spain"), new ValueContainer(9, "Andalucia"), cityEmpty));
            addresses.Add(Tuple.Create(new ValueContainer(3, "Spain"), new ValueContainer(9, "Andalucia"), new ValueContainer(24, "Sevilla")));
            addresses.Add(Tuple.Create(new ValueContainer(3, "Spain"), new ValueContainer(9, "Andalucia"), new ValueContainer(25, "Jaen")));
            addresses.Add(Tuple.Create(new ValueContainer(3, "Spain"), new ValueContainer(9, "Andalucia"), new ValueContainer(26, "Granada")));

            //Finland
            addresses.Add(Tuple.Create(new ValueContainer(4, "Finland"), new ValueContainer(10, "Uusimaa"), cityEmpty));
            addresses.Add(Tuple.Create(new ValueContainer(4, "Finland"), new ValueContainer(10, "Uusimaa"), new ValueContainer(27, "Helsinki")));
            addresses.Add(Tuple.Create(new ValueContainer(4, "Finland"), new ValueContainer(10, "Uusimaa"), new ValueContainer(28, "Espoo")));
            addresses.Add(Tuple.Create(new ValueContainer(4, "Finland"), new ValueContainer(10, "Uusimaa"), new ValueContainer(29, "Lohja")));
            addresses.Add(Tuple.Create(new ValueContainer(4, "Finland"), new ValueContainer(10, "Uusimaa"), new ValueContainer(30, "Vantaa")));
            addresses.Add(Tuple.Create(new ValueContainer(4, "Finland"), new ValueContainer(10, "Uusimaa"), new ValueContainer(31, "Kauniainen")));
            addresses.Add(Tuple.Create(new ValueContainer(4, "Finland"), new ValueContainer(10, "Uusimaa"), new ValueContainer(32, "Hyvinkаа")));
            addresses.Add(Tuple.Create(new ValueContainer(4, "Finland"), new ValueContainer(10, "Uusimaa"), new ValueContainer(33, "Kerava")));
            addresses.Add(Tuple.Create(new ValueContainer(4, "Finland"), new ValueContainer(10, "Uusimaa"), new ValueContainer(34, "Karkkila")));
            addresses.Add(Tuple.Create(new ValueContainer(4, "Finland"), new ValueContainer(10, "Uusimaa"), new ValueContainer(35, "Kirkkonummi")));
            addresses.Add(Tuple.Create(new ValueContainer(4, "Finland"), new ValueContainer(10, "Uusimaa"), new ValueContainer(36, "Pornainen")));
            addresses.Add(Tuple.Create(new ValueContainer(4, "Finland"), new ValueContainer(10, "Uusimaa"), new ValueContainer(37, "Siuntio")));
            addresses.Add(Tuple.Create(new ValueContainer(4, "Finland"), new ValueContainer(10, "Uusimaa"), new ValueContainer(38, "Tuusula")));
            addresses.Add(Tuple.Create(new ValueContainer(4, "Finland"), new ValueContainer(10, "Uusimaa"), new ValueContainer(39, "Karjalohja")));
            addresses.Add(Tuple.Create(new ValueContainer(4, "Finland"), new ValueContainer(10, "Uusimaa"), new ValueContainer(40, "Nummi-Pusula")));
            addresses.Add(Tuple.Create(new ValueContainer(4, "Finland"), new ValueContainer(10, "Uusimaa"), new ValueContainer(41, "Vihti")));

            addresses.Add(Tuple.Create(new ValueContainer(4, "Finland"), new ValueContainer(11, "Etela-Savo"), cityEmpty));
            addresses.Add(Tuple.Create(new ValueContainer(4, "Finland"), new ValueContainer(11, "Etela-Savo"), new ValueContainer(42, "Mikkeli")));
            addresses.Add(Tuple.Create(new ValueContainer(4, "Finland"), new ValueContainer(11, "Etela-Savo"), new ValueContainer(43, "Juva")));
            addresses.Add(Tuple.Create(new ValueContainer(4, "Finland"), new ValueContainer(11, "Etela-Savo"), new ValueContainer(44, "Otava")));
            addresses.Add(Tuple.Create(new ValueContainer(4, "Finland"), new ValueContainer(11, "Etela-Savo"), new ValueContainer(45, "Pieksamaki")));
            addresses.Add(Tuple.Create(new ValueContainer(4, "Finland"), new ValueContainer(11, "Etela-Savo"), new ValueContainer(46, "Savonlinna")));
            addresses.Add(Tuple.Create(new ValueContainer(4, "Finland"), new ValueContainer(11, "Etela-Savo"), new ValueContainer(47, "Haukivesi")));
            addresses.Add(Tuple.Create(new ValueContainer(4, "Finland"), new ValueContainer(11, "Etela-Savo"), new ValueContainer(48, "Kangasniemi")));

            addresses.Add(Tuple.Create(new ValueContainer(4, "Finland"), new ValueContainer(12, "Lappi"), cityEmpty));
            addresses.Add(Tuple.Create(new ValueContainer(4, "Finland"), new ValueContainer(12, "Lappi"), new ValueContainer(49, "Rovaniemi")));
            addresses.Add(Tuple.Create(new ValueContainer(4, "Finland"), new ValueContainer(12, "Lappi"), new ValueContainer(50, "Kolari")));
            addresses.Add(Tuple.Create(new ValueContainer(4, "Finland"), new ValueContainer(12, "Lappi"), new ValueContainer(51, "Inari")));
            addresses.Add(Tuple.Create(new ValueContainer(4, "Finland"), new ValueContainer(12, "Lappi"), new ValueContainer(52, "Tornio")));
            addresses.Add(Tuple.Create(new ValueContainer(4, "Finland"), new ValueContainer(12, "Lappi"), new ValueContainer(53, "Kemi")));
            addresses.Add(Tuple.Create(new ValueContainer(4, "Finland"), new ValueContainer(12, "Lappi"), new ValueContainer(54, "Sodankyla")));
            addresses.Add(Tuple.Create(new ValueContainer(4, "Finland"), new ValueContainer(12, "Lappi"), new ValueContainer(55, "Keminmaa")));
            addresses.Add(Tuple.Create(new ValueContainer(4, "Finland"), new ValueContainer(12, "Lappi"), new ValueContainer(56, "Ylitornio")));
            addresses.Add(Tuple.Create(new ValueContainer(4, "Finland"), new ValueContainer(12, "Lappi"), new ValueContainer(57, "Ranua")));
            addresses.Add(Tuple.Create(new ValueContainer(4, "Finland"), new ValueContainer(12, "Lappi"), new ValueContainer(58, "Salla")));
            addresses.Add(Tuple.Create(new ValueContainer(4, "Finland"), new ValueContainer(12, "Lappi"), new ValueContainer(59, "Pello")));
            addresses.Add(Tuple.Create(new ValueContainer(4, "Finland"), new ValueContainer(12, "Lappi"), new ValueContainer(60, "Posio")));
            addresses.Add(Tuple.Create(new ValueContainer(4, "Finland"), new ValueContainer(12, "Lappi"), new ValueContainer(61, "Simo")));
            addresses.Add(Tuple.Create(new ValueContainer(4, "Finland"), new ValueContainer(12, "Lappi"), new ValueContainer(62, "Tervola")));
            addresses.Add(Tuple.Create(new ValueContainer(4, "Finland"), new ValueContainer(12, "Lappi"), new ValueContainer(63, "Muonio")));
            addresses.Add(Tuple.Create(new ValueContainer(4, "Finland"), new ValueContainer(12, "Lappi"), new ValueContainer(64, "Utsjoki")));
            addresses.Add(Tuple.Create(new ValueContainer(4, "Finland"), new ValueContainer(12, "Lappi"), new ValueContainer(65, "Savukoski")));
            addresses.Add(Tuple.Create(new ValueContainer(4, "Finland"), new ValueContainer(12, "Lappi"), new ValueContainer(66, "Pelkosenniemi")));

            return addresses;
        }

        private static List<Tuple<ValueContainer, ValueContainer, ValueContainer>> CreateAddressDictionaryExt()
        {
            var addresses = CreateAddressDictionary();

            //1 Germany-----------------------------------------
            //1.1 city
            addresses.Add(Tuple.Create(new ValueContainer(1, "Germany"), new ValueContainer(1, "Bavaria"), new ValueContainer(1000, "GermanyAndFrance")));

            addresses.Add(Tuple.Create(new ValueContainer(1, "Germany"), new ValueContainer(2, "Saxony"), new ValueContainer(100, "SaxonyAndThuringia")));
            addresses.Add(Tuple.Create(new ValueContainer(1, "Germany"), new ValueContainer(3, "Thuringia"), new ValueContainer(100, "SaxonyAndThuringia")));


            //2 France------------------------------------------
            //2.1 city
            addresses.Add(Tuple.Create(new ValueContainer(2, "Germany"), new ValueContainer(4, "Burgundy"), new ValueContainer(1000, "GermanyAndFrance")));

            addresses.Add(Tuple.Create(new ValueContainer(2, "France"), new ValueContainer(5, "Britany"), new ValueContainer(10000, "FranceNormandyBritany_SpainCataloniaAragonAndalucia")));
            addresses.Add(Tuple.Create(new ValueContainer(2, "France"), new ValueContainer(6, "Normandy"), new ValueContainer(10000, "FranceNormandyBritany_SpainCataloniaAragonAndalucia")));

            
            //3 Spain-------------------------------------------
            //3.1 city
            addresses.Add(Tuple.Create(new ValueContainer(3, "Spain"), new ValueContainer(7, "Catalonia"), new ValueContainer(10000, "FranceNormandyBritany_SpainCataloniaAragonAndalucia")));
            addresses.Add(Tuple.Create(new ValueContainer(3, "Spain"), new ValueContainer(8, "Aragon"), new ValueContainer(10000, "FranceNormandyBritany_SpainCataloniaAragonAndalucia")));
            addresses.Add(Tuple.Create(new ValueContainer(3, "Spain"), new ValueContainer(9, "Andalucia"), new ValueContainer(10000, "FranceNormandyBritany_SpainCataloniaAragonAndalucia")));

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


    }
}
