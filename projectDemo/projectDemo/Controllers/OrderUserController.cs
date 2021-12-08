using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using projectDemo.Models;

namespace projectDemo.Controllers
{
    class OrderUserController
    {
        static Database db = new Database();
        public static void AddOrder(string f_name, string l_name, string ty, string d)
        {
            OrderUser orderUser = new OrderUser();

            orderUser.first_name = f_name;
            orderUser.last_name = l_name;
            orderUser.type = ty;
            orderUser.date = d;
            
            db.OrderUsers.AddOrder(orderUser);

        }
    }
}
