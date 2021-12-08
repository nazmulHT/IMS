using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace projectDemo.Models
{
    public class Purchasing
    {
        SqlConnection conn;
        public Purchasing()
        {
            try
            {
                conn = new SqlConnection("Server=DESKTOP-H54F8OU\\SHOKALSQL;Database=projectDemo;integrated security=true;");
            }
            catch(Exception e)
            {
                MessageBox.Show("Conection Problem, Check your Sql Connection" + e.Message);
            }
 
        }

        public void AddPurchasingInfo(Purchase purchase)
        {
            conn.Open();
            try
            {
                string query = "insert into Purchasing (product_name,quantity,unit,price,total,date,party_name,type,expiry_date,profit) values ('" + purchase.product_name + "','" + purchase.quantity + "','" + purchase.unit + "','" + purchase.price + "','" + purchase.total + "','" + purchase.date + "','" + purchase.party_name + "','" + purchase.type + "','" + purchase.expiry_date + "','" + purchase.profit + "')";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
            catch(Exception e)
            {
                MessageBox.Show("Some problem Ouccured at the time of INSERTING" + e.Message);
            }
            conn.Close();
           
        }

        public void AddStock(Purchase purchase)
        {
            conn.Open();
            try
            {
                string query = "insert into Stocks (product_name,quantity,unit) values ('" + purchase.product_name + "','" + purchase.quantity + "','" + purchase.unit + "')";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show("Some problem Ouccured at the time of INSERTING" + e.Message);
            }
            conn.Close();

        }
    }
}
