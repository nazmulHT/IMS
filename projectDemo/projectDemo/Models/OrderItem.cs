using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectDemo.Models
{
    public class OrderItem
    {
        public int id { get; set; }
        public string order_id { get; set; }
        public string product_name { get; set; }
        public string price { get; set; }
        public string quantity { get; set; }
        public string total { get; set; }
    }
}
