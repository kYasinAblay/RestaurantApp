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
                    new Product { Name = "Pilav", Species="Yemek", Price=21.5m },
                    new Product { Name = "Kurufasulye", Species="Yemek", Price=12.5m },
                    new Product { Name = "Salata", Species="Aperatif", Price=12.5m },
                    new Product { Name = "Sütlaç", Species="Tatlı", Price=25 }
                };
                context.Products.AddRange(products);
                context.SaveChanges();
            }
        }
    }
}
