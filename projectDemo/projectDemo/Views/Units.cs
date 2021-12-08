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
    public partial class Units : Form
    {
        SqlConnection conn = new SqlConnection("Server=DESKTOP-H54F8OU\\SHOKALSQL;Database=projectDemo;integrated security=true;");

        public Units()
        {
            InitializeComponent();
        }

        private void Units_Load(object sender, EventArgs e)
        {
            if(conn.State==ConnectionState.Open)
            {
                conn.Close();
            }
            conn.Open();
            Display();
        }

        private void AddUnitButtonClicked(object sender, EventArgs e)
        {
            int count = 0;
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Units where unit = '" + textBoxUnit.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt1 = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt1);
            dataGridViewUnit.DataSource = dt1;
            count = Convert.ToInt32(dt1.Rows.Count.ToString());
            if (count == 0)
            {
                UnitController.AddUnits(textBoxUnit.Text);

                Display();
            }
            else
            {
                MessageBox.Show("this unit is already added to the vendor");
            }
        }
        public void Display()
        {
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Units";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            dataGridViewUnit.DataSource = dt;
        }

        private void DeleteButtonClicked(object sender, EventArgs e)
        {
            int id;
            id = Convert.ToInt32(dataGridViewUnit.SelectedCells[0].Value.ToString());
           
            UnitController.DeleteUnit(id);

            Display();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Close();
            MDIParent md = new MDIParent();
            md.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int id1;
            id1 = Convert.ToInt32(dataGridViewUnit.SelectedCells[0].Value.ToString());
            SqlCommand cmd1 = conn.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "update Units set unit = '" + textBoxUnit.Text + "' where id = '" + id1 + "'";
            cmd1.ExecuteNonQuery();
            Display();
            MessageBox.Show("record updated successfully");
            textBoxUnit.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
