using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace projectDemo.Models
{
    public class OrderItems
    {
        SqlConnection conn;
        public OrderItems()
        {
            conn = new SqlConnection("Server=DESKTOP-H54F8OU\\SHOKALSQL;Database=projectDemo;integrated security=true;");
        }
        public void AddOrderItems(OrderItem orderItem)
        {
            conn.Open();
            try
            {
                string query = "INSERT INTO OrderItem (order_id, product_name, price, quantity, total) VALUES('" + orderItem.order_id + "','" + orderItem.product_name + "','" + orderItem.price + "','" + orderItem.quantity + "','" + orderItem.total + "')";

                SqlCommand cmd = new SqlCommand(query, conn);
                int result = cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

            conn.Close();
        }
    }
}
