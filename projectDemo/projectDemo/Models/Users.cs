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
    public class Users
    {
        SqlConnection conn;

        public Users()
        {
            try
            {
                conn = new SqlConnection("Server=DESKTOP-H54F8OU\\SHOKALSQL;Database=projectDemo;integrated security=true;");
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }

        }
        
        public void AddUser(User user)
        {
            conn.Open();
            try
            {
                string query = "INSERT INTO Users (first_name,last_name,username,password,email,contact) VALUES('" + user.first_name + "','" + user.last_name + "','" + user.username + "','" + user.password + "','" + user.email + "','" + user.contact + "')";

                SqlCommand cmd = new SqlCommand(query, conn);
                int result = cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

            conn.Close();
        }

        public void DeleteUser(int id)
        {
            conn.Open();
            try
            {
                
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from Users where id = '" + id + "'";
                cmd.ExecuteNonQuery();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            conn.Close();
        }
    }
}
