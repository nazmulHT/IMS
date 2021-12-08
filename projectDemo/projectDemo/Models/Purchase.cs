using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectDemo.Models
{
    public class Purchase
    {
        public int id { get; set; }
        public string product_name  { get; set; }
        public string quantity { get; set; }
        public string unit { get; set; }
        public string price { get; set; }
        public string total { get; set; }
        public string date { get; set; }
        public string party_name { get; set; }
        public string type { get; set; }
        public string expiry_date { get; set; }
        public string profit { get; set; }


    }
}
