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
    public partial class AddNewUser : Form
    {
        SqlConnection conn = new SqlConnection("Server=DESKTOP-H54F8OU\\SHOKALSQL;Database=projectDemo;integrated security=true;");
        public AddNewUser()
        {
            InitializeComponent();
        }

        private void AddButtonClicked(object sender, EventArgs e)
        {
            int i = 0;
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM Users WHERE username='" + textBoxuname.Text + "' ";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            i = Convert.ToInt32(dt.Rows.Count.ToString());
            if (i == 0)
            {
                if (textBoxfname.Text == "")
                {
                    MessageBox.Show("first name is required", "Validation error",MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBoxfname.Focus();
                    return;
                }
                if (textBoxlname.Text == "")
                {
                    MessageBox.Show("Last name is required", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBoxlname.Focus();
                    return;
                }
                if (textBoxuname.Text == "")
                {
                    MessageBox.Show("User Name name is required", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBoxuname.Focus();
                    return;
                }
                if (textBoxPass.Text == "")
                {
                    MessageBox.Show("Password name is required", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBoxPass.Focus();
                    return;
                }
                if (textBoxemail.Text == "")
                {
                    MessageBox.Show("Email is required", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBoxemail.Focus();
                    return;
                }
                if (textBoxcon.Text == "")
                {
                    MessageBox.Show("Contact is required", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBoxcon.Focus();
                    return;
                }

                UserController.AddUser(textBoxfname.Text, textBoxlname.Text, textBoxuname.Text, textBoxPass.Text, textBoxemail.Text, textBoxcon.Text);
                
                
                textBoxfname.Text = ""; textBoxlname.Text = ""; textBoxuname.Text = "";
                textBoxPass.Text = ""; textBoxemail.Text = ""; textBoxcon.Text = "";
                Display();
                MessageBox.Show("User record inserted successfully");
            }
            else
            {
                MessageBox.Show("this username is already taken");
            }

        }


      

        public void Display()
        {
            
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM Users";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            dataGridViewUser.DataSource = dt;
        }

        private void DeleteButtonClicked(object sender, EventArgs e)
        {
            int id;
            id = Convert.ToInt32(dataGridViewUser.SelectedCells[0].Value.ToString());
            UserController.DeleteUser(id);

            Display();
        }

        private void AddNewUser_Load(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            conn.Open();
            Display();
        }


       
        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            //int id;
            //id = Convert.ToInt32(dataGridViewUser.SelectedCells[0].Value.ToString());
            //SqlCommand cmd = conn.CreateCommand();
            //cmd.CommandType = CommandType.Text;
            //cmd.CommandText = "select * from Users where id = " + id + " ";
            //cmd.ExecuteNonQuery();
            //DataTable dt = new DataTable();
            //SqlDataAdapter sda = new SqlDataAdapter(cmd);
            //sda.Fill(dt);
            //foreach (DataRow dr in dt.Rows)
            //{
            //    textBoxfname.Text = dr["first_name"].ToString();
            //    textBoxlname.Text = dr["last_name"].ToString();
            //    textBoxuname.Text = dr["uname"].ToString();
            //    textBoxPass.Text = dr["password"].ToString();
            //    textBoxemail.Text = dr["email"].ToString();
            //    textBoxcon.Text = dr["contact"].ToString();

            //}
         
            int id;
            id = Convert.ToInt32(dataGridViewUser.SelectedCells[0].Value.ToString());
            
            SqlCommand cmd1 = conn.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "update Users set first_name = '" + textBoxfname.Text + "', last_name = '" + textBoxlname.Text + "', username = '" + textBoxuname.Text + "', password = '" + textBoxPass.Text + "', email = '" + textBoxemail.Text + "', contact = '" + textBoxcon.Text + "' where id = '" + id + "'";
            cmd1.ExecuteNonQuery();
            Display();
            MessageBox.Show("record updated successfully");
            textBoxfname.Text = "";
            textBoxlname.Text = "";
            textBoxuname.Text = "";
            textBoxPass.Text = "";
            textBoxemail.Text = "";
            textBoxcon.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            MDIParent md = new MDIParent();
            md.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        

        private void dataGridViewUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int id;
            id = Convert.ToInt32(dataGridViewUser.SelectedCells[0].Value.ToString());
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Users where id = " + id + " ";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                textBoxfname.Text = dr["first_name"].ToString();
                textBoxlname.Text = dr["last_name"].ToString();
                textBoxuname.Text = dr["username"].ToString();
                textBoxPass.Text = dr["password"].ToString();
                textBoxemail.Text = dr["email"].ToString();
                textBoxcon.Text = dr["contact"].ToString();
            }
        }
    }
}
