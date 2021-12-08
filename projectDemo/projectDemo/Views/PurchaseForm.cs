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
    public partial class PurchaseForm : Form
    {
        SqlConnection conn = new SqlConnection("Server=DESKTOP-H54F8OU\\SHOKALSQL;Database=projectDemo;integrated security=true;");
        public PurchaseForm()
        {
            InitializeComponent();
        }

        private void PurchaseForm_Load(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            conn.Open();
            FillProductName();
            FillDealerName();
        }


        public void FillProductName()
        {
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Products";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                comboBoxProductName.Items.Add(dr["product_name"].ToString());
            }
        }

        private void comboBoxProductName_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Products where product_name = '" + comboBoxProductName.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                labelUnit.Text = dr["units"].ToString();
            }
        }

        public void FillDealerName()
        {
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Dealers";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                comboBoxDealerName.Items.Add(dr["dealer_name"].ToString());
            }
        }

        private void textBoxPrice_Leave(object sender, EventArgs e)
        {
            textBoxTotal.Text = Convert.ToString(Convert.ToInt32(textBoxQuantity.Text) * Convert.ToInt32(textBoxPrice.Text));
        }

        private void PurchaseItemButtonClicked(object sender, EventArgs e)
        {
            int i;
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Stocks where product_name = '" + comboBoxProductName.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            i = Convert.ToInt32(dt.Rows.Count.ToString());
            if (i == 0)
            {
                try
                {
                    if (comboBoxProductName.Text == "")
                    {
                        MessageBox.Show("Product name is required", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        comboBoxProductName.Focus();
                        return;
                    }
                    if (textBoxQuantity.Text == "")
                    {
                        MessageBox.Show("Quantity is required", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBoxQuantity.Focus();
                        return;
                    }
                    if (textBoxPrice.Text == "")
                    {
                        MessageBox.Show("Price is required", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBoxPrice.Focus();
                        return;
                    }
                    if (comboBoxDealerName.Text == "")
                    {
                        MessageBox.Show("Dealer name is required", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        comboBoxDealerName.Focus();
                        return;
                    }
                    if (comboBoxType.Text == "")
                    {
                        MessageBox.Show("Product Type is required", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        comboBoxType.Focus();
                        return;
                    }
                    if (textBoxProfit.Text == "")
                    {
                        MessageBox.Show("Profit should include", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBoxProfit.Focus();
                        return;
                    }
                    PurchaseController.AddPurchasingInfo(comboBoxProductName.Text, textBoxQuantity.Text, labelUnit.Text, textBoxPrice.Text, textBoxTotal.Text, dateTimePickerPurchase.Value.ToString("dd-mm-yyyy"), comboBoxDealerName.Text, comboBoxType.Text, dateTimePickerExpiry.Value.ToString("dd-mm-yyyy"), textBoxProfit.Text);
                }
                catch(Exception ex)
                {
                    MessageBox.Show("NOT inserting in Purchasing Info"+ex.Message);
                }
              

                try
                {
                    if (comboBoxProductName.Text == "")
                    {
                        MessageBox.Show("Product name is required", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        comboBoxProductName.Focus();
                        return;
                    }
                    if (textBoxQuantity.Text == "")
                    {
                        MessageBox.Show("Quantity is required", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBoxQuantity.Focus();
                        return;
                    }
                    PurchaseController.AddStock(comboBoxProductName.Text, textBoxQuantity.Text, labelUnit.Text);
                }
                catch(Exception exp)
                {
                    MessageBox.Show("Problem Occured at the time of inserting in Stock Table" + exp.Message);
                }
                MessageBox.Show("Inserted at stocks Successfully");
                

            }
            else
            {
                try
                {
                    if (comboBoxProductName.Text == "")
                    {
                        MessageBox.Show("Product name is required", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        comboBoxProductName.Focus();
                        return;
                    }
                    if (textBoxQuantity.Text == "")
                    {
                        MessageBox.Show("Quantity is required", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBoxQuantity.Focus();
                        return;
                    }
                    if (textBoxPrice.Text == "")
                    {
                        MessageBox.Show("Price is required", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBoxPrice.Focus();
                        return;
                    }
                    if (comboBoxDealerName.Text == "")
                    {
                        MessageBox.Show("Dealer name is required", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        comboBoxDealerName.Focus();
                        return;
                    }
                    if (comboBoxType.Text == "")
                    {
                        MessageBox.Show("Product Type is required", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        comboBoxType.Focus();
                        return;
                    }
                    if (textBoxProfit.Text == "")
                    {
                        MessageBox.Show("Profit should include", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBoxProfit.Focus();
                        return;
                    }
                    PurchaseController.AddPurchasingInfo(comboBoxProductName.Text, textBoxQuantity.Text, labelUnit.Text, textBoxPrice.Text, textBoxTotal.Text, dateTimePickerPurchase.Value.ToString("dd-mm-yyyy"), comboBoxDealerName.Text, comboBoxType.Text, dateTimePickerExpiry.Value.ToString("dd-mm-yyyy"), textBoxProfit.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("NOT inserting in Purchasing Info" + ex.Message);
                }
               
                SqlCommand cmd2= conn.CreateCommand();
                cmd2.CommandType = CommandType.Text;
                cmd2.CommandText = "update Stocks set quantity = quantity + " + textBoxQuantity.Text + " where product_name = '"+ comboBoxProductName.Text +"'";
                cmd2.ExecuteNonQuery();
                MessageBox.Show("Update Stocks Properly");

            }


            
            MessageBox.Show("inserted suucessfully");
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Close();
            MDIParent md = new MDIParent();
            md.Show();
        }

        private void buttonBack_Click_1(object sender, EventArgs e)
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
