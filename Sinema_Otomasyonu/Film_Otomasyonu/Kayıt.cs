using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using Microsoft.IdentityModel.Tokens;

namespace Film_otomasyonu
{
    public partial class Kayıt : Form
    {
        public Kayıt()
        {
            InitializeComponent();
        }

        private void button1_click(object sender, EventArgs e)
        {
            string isim = textBox1.Text;
            string soyisim = textBox2.Text;
            string email = textBox3.Text;
            string şifre = textBox4.Text;

            if (textBox1.Text.IsNullOrEmpty() || textBox2.Text.IsNullOrEmpty() || textBox3.Text.IsNullOrEmpty() || textBox4.Text.IsNullOrEmpty())
            {
                MessageBox.Show("Lütfen Tüm Bilgileri Giriniz.");
            }
            else
            {
                string connectionString = "Data Source=ENESSS\\SQLEXPRESS;Initial Catalog=film_otomasyonu;Integrated Security=True";
                string query = "INSERT INTO yeni_kullanıcılar (isim, soyisim, email, şifre) VALUES (@isim, @soyisim, @email, @şifre)";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {

                        cmd.Parameters.AddWithValue("@isim", isim);
                        cmd.Parameters.AddWithValue("@soyisim", soyisim);
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@şifre", şifre);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Kayıt başarılı!");
                        conn.Close();
                    }


                }
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                this.Close();
                GirişEkranı giriş = new GirişEkranı();
                giriş.Show();

            }



        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            
            this.Close();
            GirişEkranı girişEkranı = new GirişEkranı();
            girişEkranı.Show();

        }
    }
}
