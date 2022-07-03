using System;
using System.Collections.Generic;
using System.Linq;

namespace TestAppForSortingCvs
{
    class Program
    {
        static void Main(string[] args)
        {
            var productList = new List<Product>();
            productList.Add(new Product { Id = 1, Country = "US" });
            productList.Add(new Product { Id = 1, Country = "DE" });
            productList.Add(new Product { Id = 2, Country = "NL" });
            productList.Add(new Product { Id = 3, Country = "US" });
            Random rnd = new Random();
            for (int i = 0; i < 10000; i++)
            {
                productList.Add(new Product { Id = rnd.Next(1, 100), Country = GetRandomCountry(rnd.Next(1,10)) });
            }

            var grouped = productList.GroupBy(t => t.Id)
               .OrderBy(grp => grp.Key)
                .Select(grp => new { Key = grp.Key, Items = grp.Select(t => t.Country).ToList() }).ToList();
            Console.WriteLine("Hello World!");
        }

        private static string GetRandomCountry(int rand)
        {
            switch (rand)
            {
                case 1:
                    return "US";
                case 2:
                    return "BG";
                case 3:
                    return "NL";
                case 4:
                    return "GE";
                case 5:
                    return "GB";
                case 6:
                    return "IL";
                case 7:
                    return "RO";
                case 8:
                    return "JP";
                case 9:
                    return "SW";
                case 10:
                    return "SE";
                default:
                    return "BR";
            }
        }

        class Product
        {
            public int Id { get; set; }
            public string Country { get; set; }
        }
    }
}
