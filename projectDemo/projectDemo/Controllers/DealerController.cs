using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using projectDemo.Models;

namespace projectDemo.Controllers
{
    class DealerController
    {
        static Database db = new Database();


        public static void AddDealer(string d_name, string c_name, string con, string add, string city)
        {
            Dealer dealer = new Dealer();
            dealer.dealer_name = d_name;
            dealer.comapany_name = c_name;
            dealer.contact = con;
            dealer.address = add;
            dealer.city = city;

            db.Dealers.AddDealer(dealer);
        }

        public static void DeleteDealer(int id)
        {
            db.Dealers.DeleteDealer(id);
        }
    }
}
