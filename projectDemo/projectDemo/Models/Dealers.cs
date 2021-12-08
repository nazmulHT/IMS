using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace projectDemo.Models
{
    public class Dealers
    {
        SqlConnection conn;
        
        public Dealers()
        {
            try
            {
                conn = new SqlConnection("Server=DESKTOP-H54F8OU\\SHOKALSQL;Database=projectDemo;integrated security=true;");
            }
            catch(Exception e)
            {
                MessageBox.Show("Connection problem" + e.Message);
            }
           
        }
        public void AddDealer(Dealer dealer)
        {
            conn.Open();
            try
            {
                string query = "insert into Dealers (dealer_name, company_name, contact, address, city) values ('" + dealer.dealer_name + "','" + dealer.comapany_name + "','" + dealer.contact + "', '" + dealer.address + "', '" + dealer.city + "')";
                SqlCommand cmd = new SqlCommand(query, conn);
                int result = cmd.ExecuteNonQuery();
            }
            catch(Exception e)
            {
                MessageBox.Show("Something Wrong Happend" + e.Message);
            }
            conn.Close();
            
        }

        public void DeleteDealer(int id)
        {
            conn.Open();
            try
            {

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from Dealers where id = '" + id + "'";
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            conn.Close();
        }

    }
}
