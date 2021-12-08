using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using projectDemo.Models;

namespace projectDemo.Controllers
{
    class OrderItemController
    {
        static Database db = new Database();

        public static void AddOrderItems(string o_id, string p_name, string pri, string qty, string tot)
        {
            OrderItem orderItem = new OrderItem();
            orderItem.order_id = o_id;
            orderItem.product_name = p_name;
            orderItem.price = pri;
            orderItem.quantity = qty;
            orderItem.total = tot;

            db.orderItems.AddOrderItems(orderItem);
            //db.Dealers.AddDealer(dealer);
        }
    }
}
