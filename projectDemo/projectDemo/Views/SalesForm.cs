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
namespace projectDemo.Views
{
    public partial class SalesForm : Form
    {
        SqlConnection conn = new SqlConnection("Server=DESKTOP-H54F8OU\\SHOKALSQL;Database=projectDemo;integrated security=true;");
        DataTable dt = new DataTable();
        int tot = 0;
        public SalesForm()
        {
            InitializeComponent();
        }

        private void SalesForm_Load(object sender, EventArgs e)
        {
            if(conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            conn.Open();
            
            
            dt.Clear();
            dt.Columns.Add("product_name");
            dt.Columns.Add("price");
            dt.Columns.Add("quantity");
            dt.Columns.Add("total");
        }

        private void textBoxProduct_KeyUp(object sender, KeyEventArgs e)
        {
            listBoxSales.Visible = true;

            listBoxSales.Items.Clear();

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Stocks where product_name like ('"+textBoxProduct.Text+"%')";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                listBoxSales.Items.Add(dr["product_name"].ToString());
            }
        }

        private void textBoxProduct_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Down)
            {
                listBoxSales.Focus();
                listBoxSales.SelectedIndex = 0;
            }
        }

        private void listBoxSales_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if(e.KeyCode==Keys.Down)
                {
                    this.listBoxSales.SelectedIndex = this.listBoxSales.SelectedIndex - 0;
                }
                if (e.KeyCode == Keys.Up)
                {
                    this.listBoxSales.SelectedIndex = this.listBoxSales.SelectedIndex - 0 ;
                }
                if (e.KeyCode == Keys.Enter)
                {
                    textBoxProduct.Text = listBoxSales.SelectedItem.ToString();
                    listBoxSales.Visible = false;
                    textBoxPrice.Focus();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("something worng happend at listBox " + ex.Message);
            }
        }

        private void textBoxPrice_Enter(object sender, EventArgs e)
        {
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select top 1 * from Purchasing where product_name = '"+ textBoxProduct.Text +"' order by id desc";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                textBoxPrice.Text = dr["price"].ToString();
            }
        }

        private void textBoxQty_Leave(object sender, EventArgs e)
        {
            try
            {
                textBoxTotal.Text = Convert.ToString(Convert.ToInt32(textBoxPrice.Text) * Convert.ToInt32(textBoxQty.Text));
            }catch(Exception ex)
            {
                MessageBox.Show("some problem occured at the time of multiplying price and qty" + ex.Message);
            }
        }

        private void AddButtonClicked(object sender, EventArgs e)
        {
            int stock = 0;
            SqlCommand cmd1 = conn.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "select * from Stocks where product_name = '"+ textBoxProduct.Text +"' ";
            cmd1.ExecuteNonQuery();
            DataTable dt1 = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd1);
            sda.Fill(dt1);
            foreach(DataRow dr1 in dt1.Rows)
            {
                stock = Convert.ToInt32(dr1["quantity"].ToString());
            }


            if (Convert.ToInt32(textBoxQty.Text)>stock)
            {
                MessageBox.Show("in our stock we don't have that much quantity");
            }
            else
            {
                DataRow dr = dt.NewRow();
                dr["product_name"] = textBoxProduct.Text;
                dr["price"] = textBoxPrice.Text;
                dr["quantity"] = textBoxQty.Text;
                dr["total"] = textBoxTotal.Text;
                dt.Rows.Add(dr);
                dataGridViewSales.DataSource = dt;

                tot = tot + Convert.ToInt32(dr["total"].ToString());

                label0.Text = tot.ToString();
            }

            textBoxProduct.Text = "";
            textBoxPrice.Text = "";
            textBoxQty.Text = "";
            textBoxTotal.Text = "";
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                tot = 0;
                dt.Rows.RemoveAt(Convert.ToInt32(dataGridViewSales.CurrentCell.RowIndex.ToString()));
                foreach (DataRow dr1 in dt.Rows)
                {
                    tot = tot + Convert.ToInt32(dr1["total"].ToString());
                    label0.Text = tot.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("something wrong in Delete Func" + ex.Message);
            }

        }

        private void buttonPrintBill_Click(object sender, EventArgs e)
        {
            string orderid = "";
            if (textBoxF_Name.Text == "")
            {
                MessageBox.Show("Buyer First name is required", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBoxF_Name.Focus();
                return;
            }
            if (textBoxL_Name.Text == "")
            {
                MessageBox.Show("Buyer last name is required", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBoxL_Name.Focus();
                return;
            }
            if (comboBoxBilType.Text == "")
            {
                MessageBox.Show("Bill is required", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                comboBoxBilType.Focus();
                return;
            }
        
            OrderUserController.AddOrder(textBoxF_Name.Text, textBoxL_Name.Text, comboBoxBilType.Text, dateTimePickeBillDate.Value.ToString("dd/mm/yyyy"));

            SqlCommand cmd2 = conn.CreateCommand();
            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = "select top 1 * from OrderUser order by id desc";
            cmd2.ExecuteNonQuery();
            DataTable dt2 = new DataTable();
            SqlDataAdapter sda2 = new SqlDataAdapter(cmd2);
            sda2.Fill(dt2);
            foreach(DataRow dr2 in dt2.Rows)
            {
                orderid = dr2["id"].ToString();
            }


            foreach(DataRow dr in dt.Rows)
            {
                int qty = 0;
                string pname = "";
                string oid = orderid.ToString();
                string proName = dr["product_name"].ToString();
                string pri = dr["price"].ToString();
                string Qty = dr["quantity"].ToString();
                string Total = dr["total"].ToString();
                OrderItemController.AddOrderItems(oid, proName, pri, Qty, Total);

                qty = Convert.ToInt32(dr["quantity"].ToString());
                pname = dr["product_name"].ToString();

                SqlCommand cmd4 = conn.CreateCommand();
                cmd4.CommandType = CommandType.Text;
                cmd4.CommandText = "update Stocks set quantity = quantity -"+ qty + " where product_name = '"+ pname.ToString() +"'";
                cmd4.ExecuteNonQuery();

            }

            textBoxF_Name.Text = "";
            textBoxL_Name.Text = "";
            textBoxProduct.Text = "";
            textBoxPrice.Text = "";
            textBoxQty.Text = "";
            textBoxTotal.Text = "";

            label0.Text = "";

            MessageBox.Show("record inserted successfully");
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
