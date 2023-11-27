using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject
{
    public partial class Home : Form
    {
        public string Email { get; set; }
        public string TtlUsers { get; set; }
        public string TtlProd { get; set; }

        public static string constring = "Data Source=(local);Initial Catalog=Store;Integrated Security=True;Encrypt=False";

        SqlConnection conn = new SqlConnection(constring);
        public Home()
        {
            InitializeComponent();
            //User.Text = Email;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Home_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'storeDataSet21.User' table. You can move, or remove it, as needed.
            this.userTableAdapter1.Fill(this.storeDataSet21.User);

            // TODO: This line of code loads data into the 'storeDataSet1.Products' table. You can move, or remove it, as needed.
            this.productsTableAdapter.Fill(this.storeDataSet1.Products);
            // TODO: This line of code loads data into the 'storeDataSet.Products' table. You can move, or remove it, as needed.
            this.productsTableAdapter.Fill(this.storeDataSet.Products);
            User.Text = Email;
            label4.Text = TtlUsers;
            label6.Text = TtlProd;

            combo1();
            display_datagrid();

        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Home_Load_1(object sender, EventArgs e)
        {

        }

        private void Users_Click(object sender, EventArgs e)
        {

        }

        private void Products_Click(object sender, EventArgs e)
        {

        }

        public void label3_Click(object sender, EventArgs e)
        {

        }

        private void Email_Click(object sender, EventArgs e)
        {
            
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string constring = "Data Source=(local);Initial Catalog=Store;Integrated Security=True;Encrypt=False";

            SqlConnection conn = new SqlConnection(constring);
            conn.Open();
            byte[] image = ConvertImgToBytes(pictureBox1.Image);
            try
            {
                String sql = "INSERT INTO [Products] (p_id,name,quantity,price,category,p_img) VALUES (@pid,@name,@qty,@price,@category,@img)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@pid", int.Parse(textBox1.Text));
                cmd.Parameters.AddWithValue("@name", textBox2.Text);
                cmd.Parameters.AddWithValue("@qty", int.Parse(textBox4.Text));
                cmd.Parameters.AddWithValue("@price", int.Parse(textBox5.Text));
                cmd.Parameters.AddWithValue("@category", textBox3.Text);
                cmd.Parameters.AddWithValue("@img", image);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Added Successfully!!");
                
            }
            catch(Exception ex) { 
                MessageBox.Show("ERRORRRRR!!");
            }
            finally { conn.Close(); }



        }

        byte[] ConvertImgToBytes(Image img)
        {
            using(MemoryStream ms = new MemoryStream()) {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
        }

        public Image ConvertByteToImage(byte[] data)
        {
            using(MemoryStream ms = new MemoryStream(data))
            {
                return Image.FromStream(ms);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                if(ofd.ShowDialog()== DialogResult.OK)
                {
                    pictureBox1.Image = Image.FromFile(ofd.FileName);  
                }
            }

            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Close();
            Form1 f = new Form1();
            f.Show();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Products", conn);
            SqlDataAdapter da2 = new SqlDataAdapter();
            DataTable dt2 = new DataTable();
            da2.SelectCommand = cmd;
            dt2.Clear();
            da2.Fill(dt2);
            dataGridView1.DataSource = dt2;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            timer1.Start();
        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.productsTableAdapter.FillBy(this.storeDataSet.Products);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void fillToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.productsTableAdapter.Fill(this.storeDataSet.Products);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            display_datagrid();

        }
        private void combo1()
        {
            

            string query = "SELECT DISTINCT category FROM Products";

            SqlDataAdapter da = new SqlDataAdapter(query,conn);
            conn.Open();

            DataSet dt = new DataSet();
            da.Fill(dt, "category");
            comboBox1.DisplayMember = "category";
            comboBox1.ValueMember = "category";
            comboBox1.DataSource = dt.Tables["category"];
            conn.Close();

            if (comboBox1.Items.Count > 1 ) { 
                comboBox1.SelectedIndex =  -1;
            }
        }

        private void display_datagrid()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Products WHERE category LIKE '%" + comboBox1.Text+"'",conn);
            SqlDataAdapter da2 = new SqlDataAdapter();
            DataTable dt2 = new DataTable();
            da2.SelectCommand = cmd;
            dt2.Clear();
            da2.Fill(dt2);
            dataGridView2.DataSource = dt2;

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timer2.Start();
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM User", conn);
            SqlDataAdapter da2 = new SqlDataAdapter();
            DataTable dt2 = new DataTable();
            da2.SelectCommand = cmd;
            dt2.Clear();
            da2.Fill(dt2);
            dataGridView3.DataSource = dt2;
        }

        
    }
}
