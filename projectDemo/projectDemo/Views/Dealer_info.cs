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
    public partial class Dealer_info : Form
    {
        SqlConnection conn = new SqlConnection("Server=DESKTOP-H54F8OU\\SHOKALSQL;Database=projectDemo;integrated security=true;");
        public Dealer_info()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void InsertButtonClicked(object sender, EventArgs e)
        {
            if(textBoxDname.Text == "")
            {
                MessageBox.Show("Dealer name is required", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBoxDname.Focus();
                return;
            }
            if (textBoxCname.Text == "")
            {
                MessageBox.Show("Dealer  Comapany name is required", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBoxCname.Focus();
                return;
            }
            if (textBoxContact.Text == "")
            {
                MessageBox.Show("Dealer Contact is required", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBoxContact.Focus();
                return;
            }
            if (textBoxAddress.Text == "")
            {
                MessageBox.Show("Dealer Address is required", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBoxAddress.Focus();
                return;
            }
            if (textBoxCity.Text == "")
            {
                MessageBox.Show("City name is required", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBoxCity.Focus();
                return;
            }
            DealerController.AddDealer(textBoxDname.Text, textBoxCname.Text, textBoxContact.Text, textBoxAddress.Text, textBoxCity.Text);

            textBoxDname.Text = "";
            textBoxCname.Text = "";
            textBoxContact.Text = "";
            textBoxAddress.Text = "";
            textBoxCity.Text = "";

            Display();
            MessageBox.Show("Record Inserted Successfully");
        }

        private void Dealer_info_Load(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            conn.Open();
            Display();
        }

        public void Display()
        {
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Dealers ";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            dataGridViewDealerInfo.DataSource = dt;

        }

        private void DeleteSelectedButtonClicked(object sender, EventArgs e)
        {
            int id;
            id = Convert.ToInt32(dataGridViewDealerInfo.SelectedCells[0].Value.ToString());
            DealerController.DeleteDealer(id);


            Display();
        }

        private void UpdateSelectedButtonClicked(object sender, EventArgs e)
        {
            panelNew.Visible = true;
            int id;
            id = Convert.ToInt32(dataGridViewDealerInfo.SelectedCells[0].Value.ToString());
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Dealers where id = " + id + " ";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach ( DataRow dr in dt.Rows)
            {
                textBoxName.Text = dr["dealer_name"].ToString();
                textBoxCompanyName.Text = dr["company_name"].ToString();
                textBoxcon.Text = dr["contact"].ToString();
                textBoxadd.Text = dr["address"].ToString();
                textBoxci.Text = dr["city"].ToString();
            }

        }

        private void UpdateButtonClicked(object sender, EventArgs e)
        {
            int id;
            id = Convert.ToInt32(dataGridViewDealerInfo.SelectedCells[0].Value.ToString());
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update Dealers set dealer_name = '"+textBoxName.Text+"', company_name = '"+textBoxCompanyName.Text+"', contact = '"+textBoxcon.Text+"', address = '"+textBoxadd.Text+"', city = '"+textBoxci.Text+ "' where id = '" + id + "'";
            cmd.ExecuteNonQuery();


            panelNew.Visible = false;
            Display();
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
