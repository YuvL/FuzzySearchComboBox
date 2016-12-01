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

            return addresses;
        }

        private static List<Tuple<ValueContainer, ValueContainer, ValueContainer>> CreateAddressDictionaryExt()
        {
            var addresses = CreateAddressDictionary();

            //Germany
            addresses.Add(Tuple.Create(new ValueContainer(1, "Germany"), new ValueContainer(1, "Bavaria"), new ValueContainer(1000, "GermanyAndFrance")));

            addresses.Add(Tuple.Create(new ValueContainer(1, "Germany"), new ValueContainer(2, "Saxony"), new ValueContainer(100, "SaxonyAndThuringia")));
            addresses.Add(Tuple.Create(new ValueContainer(1, "Germany"), new ValueContainer(3, "Thuringia"), new ValueContainer(100, "SaxonyAndThuringia")));

            //France
            addresses.Add(Tuple.Create(new ValueContainer(2, "Germany"), new ValueContainer(4, "Burgundy"), new ValueContainer(1000, "GermanyAndFrance")));

            addresses.Add(Tuple.Create(new ValueContainer(2, "France"), new ValueContainer(5, "Britany"), new ValueContainer(10000, "FranceNormandyBritany_SpainCataloniaAragonAndalucia")));
            addresses.Add(Tuple.Create(new ValueContainer(2, "France"), new ValueContainer(6, "Normandy"), new ValueContainer(10000, "FranceNormandyBritany_SpainCataloniaAragonAndalucia")));

            //Spain
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
