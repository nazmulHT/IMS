using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using projectDemo.Controllers;

namespace projectDemo
{
    public partial class Products : Form
    {
        SqlConnection conn = new SqlConnection("Server=DESKTOP-H54F8OU\\SHOKALSQL;Database=projectDemo;integrated security=true;");
        public Products()
        {
            InitializeComponent();
        }

        private void Products_Load(object sender, EventArgs e)
        {
            if(conn.State==ConnectionState.Open)
            {
                conn.Close();
            }
            conn.Open();
            fill_dd();
            fill_dg();
        }
        public void fill_dd()
        {
            comboBoxUnit.Items.Clear();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Units";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                comboBoxUnit.Items.Add(dr["unit"].ToString());
            }
        }

      
        public void fill_dg()
        {
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Products";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            dataGridViewProducts.DataSource = dt;
        }

        private void dataGridViewProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            panel2.Visible = true;
            int i = Convert.ToInt32(dataGridViewProducts.SelectedCells[0].Value.ToString());

            comboBoxUni.Items.Clear();
            SqlCommand cmd1 = conn.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "select * from Units";
            cmd1.ExecuteNonQuery();
            DataTable dt1 = new DataTable();
            SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
            sda1.Fill(dt1);
            foreach (DataRow dr1 in dt1.Rows)
            {
                comboBoxUni.Items.Add(dr1["unit"].ToString());
            }


            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Products where id = '" + i + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                textBoxProds.Text = dr["product_name"].ToString();
                comboBoxUni.SelectedText = dr["units"].ToString();
            }

         

        }

        private void dataGridViewProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            panel2.Visible = true;
            int i = Convert.ToInt32(dataGridViewProducts.SelectedCells[0].Value.ToString());

            comboBoxUni.Items.Clear();
            SqlCommand cmd1 = conn.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "select * from Units";
            cmd1.ExecuteNonQuery();
            DataTable dt1 = new DataTable();
            SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
            sda1.Fill(dt1);
            foreach (DataRow dr1 in dt1.Rows)
            {
                comboBoxUni.Items.Add(dr1["unit"].ToString());
            }


            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Products where id = '" + i + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                textBoxProds.Text = dr["product_name"].ToString();
                comboBoxUni.SelectedItem = dr["units"].ToString();
            }

        }

        private void UpdateButtonClicked(object sender, EventArgs e)
        {
            
            int i = Convert.ToInt32(dataGridViewProducts.SelectedCells[0].Value.ToString());

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update Products set product_name = '" + textBoxProds.Text + "', units = '" + comboBoxUni.SelectedItem.ToString() + "' where id = '" + i + "'";
            cmd.ExecuteNonQuery();
            //ProductController.UpdateProduct(pname, uni);
            panel2.Visible = false;
            fill_dg();
        }

        private void buttonAddProd_Click(object sender, EventArgs e)
        {
            if (textBoxProductName.Text == "")
            {
                MessageBox.Show("Product name is required", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBoxProductName.Focus();
                return;
            }
            if (comboBoxUnit.Text == "")
            {
                MessageBox.Show("Unit is required", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                comboBoxUnit.Focus();
                return;
            }
            ProductController.AddProduct(textBoxProductName.Text, comboBoxUnit.Text);

            textBoxProductName.Text = "";
            fill_dg();
            MessageBox.Show("Inserted Successfully");

            
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Close();
            MDIParent md = new MDIParent();
            md.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
