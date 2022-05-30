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

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection dobavlenie = new SqlConnection(Connection.connectionStr);
            try
            {
                dobavlenie.Open();
                string sqlExp = "insert into [dbo].[Authors] ([SurName],[Name],[MiddleName],[NickName]) values (@SurName,@Name,@MiddleName,@NickName)";
                SqlCommand cmd = new SqlCommand(sqlExp, dobavlenie);
                cmd.Parameters.AddWithValue("@SurName", textBox1.Text);
                cmd.Parameters.AddWithValue("@Name", textBox2.Text);
                cmd.Parameters.AddWithValue("@MiddleName", textBox3.Text);
                cmd.Parameters.AddWithValue("@NickName", textBox4.Text);
                int y = cmd.ExecuteNonQuery();
                MessageBox.Show("Данные добавились");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 newForm = new Form1();
            newForm.Show();
            this.Hide();
        }
    }
}
