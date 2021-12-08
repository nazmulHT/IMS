using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using projectDemo.Models;

namespace projectDemo.Controllers
{
    class PurchaseController
    {
        static Database db = new Database();
        public static void AddPurchasingInfo(string p_name, string qty, string unit, string price, string total, string date, string name, string type, string ex_date, string prof)
        {
            Purchase purchase = new Purchase();

            
            purchase.product_name = p_name;
            purchase.quantity = qty;
            purchase.unit = unit;
            purchase.price = price;
            purchase.total = total;
            purchase.date = date;
            purchase.party_name = name;
            purchase.type = type;
            purchase.expiry_date = ex_date;
            purchase.profit = prof;

            db.Purchasing.AddPurchasingInfo(purchase);

        }
        public static void AddStock(string pname, string qty, string unit)
        {
            Purchase purchase = new Purchase();
            purchase.product_name = pname;
            purchase.quantity = qty;
            purchase.unit = unit;
            db.Purchasing.AddStock(purchase);        }

    }
}
