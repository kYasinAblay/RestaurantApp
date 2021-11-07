using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ArdaPos.DataAccess.Model
{
    public class Product
    {
        public int Id { get; set; }
        [DisplayName("Yemek Adı")]
        public string Name { get; set; }
        [DisplayName("Türü")]
        public string Species { get; set; }
        [DisplayName("Fiyat")]
        public decimal Price { get; set; }
    }
}
