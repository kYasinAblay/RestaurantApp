using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArdaPos.DataAccess.Model
{
    public class Order
    {
        [DisplayName("No.")]
        public int Id { get; set; }
        [DisplayName("Yemek Adı")]
        public string TableNo { get; set; }
        [DisplayName("Siparişler")]
        public string Orders { get; set; }
        [DisplayName("Tutar")]
        public decimal Amount { get; set; }
        [DisplayName("Açıklama")]
        public string Description { get; set; }
    }
}
