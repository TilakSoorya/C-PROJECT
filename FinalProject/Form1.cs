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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string constring = "Data Source=(local);Initial Catalog=Store;Integrated Security=True;Encrypt=False";

            SqlConnection conn = new SqlConnection(constring);
            try
            {
                string checkUserSql = "SELECT COUNT(*) FROM [User] WHERE email = @email and @password = @password";
                SqlCommand checkUserCmd = new SqlCommand(checkUserSql, conn);
                checkUserCmd.Parameters.AddWithValue("@email", textBox1.Text);
                checkUserCmd.Parameters.AddWithValue("@password", textBox2.Text);

                conn.Open();

                int existingUserCount = (int)checkUserCmd.ExecuteScalar();

                if (existingUserCount > 0)
                {
                    this.Hide();
                    Home h = new Home();
                    string user = "SELECT COUNT(*) FROM [User]";
                    string prod = "SELECT COUNT(*) FROM [Products]";
                    SqlCommand usercmd = new SqlCommand(user, conn);
                    SqlCommand prodcmd = new SqlCommand(prod, conn);
                    int userCount = (int)usercmd.ExecuteScalar();
                    int prodCount = (int)prodcmd.ExecuteScalar();
                    h.Email = textBox1.Text;
                    h.TtlUsers = userCount.ToString();
                    h.TtlProd = prodCount.ToString();
                    h.Show();
                    
                }
                
                else
                {
                    MessageBox.Show("Invalid Credentials");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:404");
            }
            finally
            {
                //Step 7: Close Connection
                conn.Close();
            }
        }
    }
}
