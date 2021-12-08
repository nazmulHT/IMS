using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace projectDemo.Models
{
    public class Products
    {
        SqlConnection conn;
        public Products()
        {
            try
            {
                conn = new SqlConnection("Server=DESKTOP-H54F8OU\\SHOKALSQL;Database=projectDemo;integrated security=true;");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

        }
        public void AddProduct(Product product)
        {
            conn.Open();
            try
            {
                string query = "INSERT INTO Products (product_name,units) VALUES('" + product.product_name + "','" + product.units + "')";

                SqlCommand cmd = new SqlCommand(query, conn);
                int result = cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

            conn.Close();
        }
        //public void UpdateProduct(Product product)
        //{
        //    conn.Open();
        //    string query = "UPDATE Products SET product_name ='" + product.product_name + "', units ='" + product.units + "' WHERE Id='" + product.id + "'";
        //    SqlCommand cmd = new SqlCommand(query, conn);
        //    int result = cmd.ExecuteNonQuery();
        //    conn.Close();
        //}


    }
}
