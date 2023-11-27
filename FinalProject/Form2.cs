using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject
{
    public partial class Form2 : Form
    {
        
        public Form2()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {


            string constring = "Data Source=(local);Initial Catalog=Store;Integrated Security=True;Encrypt=False";

            SqlConnection conn = new SqlConnection(constring);
            conn.Open();
            try
            {
                string sql = "INSERT INTO [User] (name,age,phno,email,password)  VALUES (@name,@age,@phno,@email,@password)";
                SqlCommand c = new SqlCommand(sql, conn);
                c.Parameters.AddWithValue("@name", textBox1.Text);
                c.Parameters.AddWithValue("@age", textBox2.Text);
                c.Parameters.AddWithValue("@phno", textBox3.Text);
                c.Parameters.AddWithValue("@email", textBox4.Text);
                c.Parameters.AddWithValue("@password", textBox5.Text);
                c.ExecuteNonQuery();
                MessageBox.Show("Added Successfullyy...!!");
            }
            catch {
                MessageBox.Show("Error Occured!!");
            }
            
            finally { conn.Close(); }
        }
    }
}
