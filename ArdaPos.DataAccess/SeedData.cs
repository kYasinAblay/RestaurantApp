using ArdaPos.DataAccess.Model;
using System.Collections.Generic;
using System.Linq;

namespace ArdaPos.DataAccess
{
    public class SeedData
    {
        public static void Initialize(DataContext context)
        {
            if (!context.Products.Any())
            {
                var products = new List<Product>()
                {
                    new Product { Name = "Pilav", Species="Yemek", Price=20m },
                    new Product { Name = "Kuru Fasulye", Species="Yemek", Price=15m },
                    new Product { Name = "Salata", Species="Aperatif", Price=7.5m },
                    new Product { Name = "Sütlaç", Species="Tatlı", Price=15 }
                };
                context.Products.AddRange(products);
                context.SaveChanges();
            }
        }
    }
}
