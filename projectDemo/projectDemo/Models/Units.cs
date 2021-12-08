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
    public class Units
    {
        SqlConnection conn;
        public Units()
        {
            conn = new SqlConnection("Server=DESKTOP-H54F8OU\\SHOKALSQL;Database=projectDemo;integrated security=true;");
        }
        public void AddUnits(Unit units)
        {
            conn.Open();
            try
            {
                string query = "INSERT INTO Units (unit)  VALUES('" + units.unit + "')";

                SqlCommand cmd = new SqlCommand(query, conn);
                int result = cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

            conn.Close();
        }

        public void DeleteUnit(int id)
        {
            conn.Open();
            try
            {

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from Units where id = '" + id + "'";
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
