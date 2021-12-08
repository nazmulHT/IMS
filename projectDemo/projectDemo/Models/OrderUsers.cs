using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace projectDemo.Models
{
    public class OrderUsers
    {
        SqlConnection conn;
        public OrderUsers()
        {
            conn = new SqlConnection("Server=DESKTOP-H54F8OU\\SHOKALSQL;Database=projectDemo;integrated security=true;");
        }
        public void AddOrder(OrderUser orderUser)
        {
            conn.Open();
            try
            {
                string query = "INSERT INTO OrderUser (first_name, last_name, type, date) VALUES('" + orderUser.first_name + "','" + orderUser.last_name + "', '" + orderUser.type + "', '" + orderUser.date + "')";
                SqlCommand cmd = new SqlCommand(query, conn);
                int result = cmd.ExecuteNonQuery();
            }
            catch(Exception e)
            {
                MessageBox.Show("Problem Occurs at the time of inserting in OrderUser table" + e.Message);
            }
            conn.Close();

        }
    }
}
