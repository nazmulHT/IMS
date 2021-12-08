using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectDemo.Models
{
    class Database
    {
        public Users Users { get; set; }
        public Products Products { get; set; }
        public Units Units { get; set; }
        public Dealers Dealers { get; set; }
        public Purchasing Purchasing { get; set; }
        public OrderUsers OrderUsers { get; set; }
        public OrderItems orderItems { get; set; }
        public Database()
        {
            Users = new Users();
            Units = new Units();
            Products = new Products();
            Dealers = new Dealers();
            Purchasing = new Purchasing();
            OrderUsers = new OrderUsers();
            orderItems = new OrderItems();
        }

       

    }
}
