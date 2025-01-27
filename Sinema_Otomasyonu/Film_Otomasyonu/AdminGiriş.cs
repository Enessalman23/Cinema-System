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
using Microsoft.IdentityModel.Tokens;

namespace Film_otomasyonu
{
    public partial class AdminGiriş : Form
    {
        public AdminGiriş()
        {
            InitializeComponent();
        }



        private void button1_Click(object sender, EventArgs a)
        {
            string email = textBox1.Text;
            string şifre = textBox2.Text;

            if (textBox1.Text.IsNullOrEmpty() || textBox2.Text.IsNullOrEmpty())
            {
                MessageBox.Show("Tüm Bilgileri Doldurunuz.");
            }
            else
            {
                string query = "SELECT COUNT(1) FROM adminBilgi WHERE email=@email AND şifre=@sifre";
                using (SqlConnection conn = new SqlConnection("Data Source=ENESSS\\SQLEXPRESS;Initial Catalog=film_otomasyonu;Integrated Security=True"))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@sifre", şifre);
                        conn.Open();
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        if (count == 1)
                        {
                            MessageBox.Show("Giriş başarılı!");
                            this.Hide();
                            AdminPanel adminPanel = new AdminPanel();
                            adminPanel.Show();

                        }
                        else
                        {
                            MessageBox.Show("Kullanıcı adı veya şifre yanlış!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }


                }


            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            GirişEkranı girişEkranı = new GirişEkranı();
            girişEkranı.Show();
        }

        private void AdminGiriş_Load(object sender, EventArgs e)
        {

        }
    }
}
