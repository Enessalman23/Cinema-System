using Microsoft.IdentityModel.Tokens;
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

namespace Film_otomasyonu
{
    public partial class BiletsSorgula : Form
    {
        public BiletsSorgula()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string müşteriAd = textBox1.Text;
            string müşteriSoyad = textBox2.Text;
            if (textBox1.Text.IsNullOrEmpty() || textBox2.Text.IsNullOrEmpty())
            {
                MessageBox.Show("Bütün Bilgileri Giriniz.");
            }
            else
            {
                string connectionString = "Data Source=ENESSS\\SQLEXPRESS;Initial Catalog=film_otomasyonu;Integrated Security=True";
                string query = @" SELECT biletler.müşteriAd, biletler.müşteriSoyad, film.isim AS filmAdı, biletler.koltukNo, biletler.tarih FROM biletler 
                 INNER JOIN film ON biletler.filmID = film.id 
                  WHERE biletler.müşteriAd = @müşteriAd AND biletler.müşteriSoyad = @müşteriSoyad";
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using(SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@müşteriAd", müşteriAd);
                        cmd.Parameters.AddWithValue("@müşteriSoyad", müşteriSoyad);
                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                string biletBilgileri = $"Film Adı:{reader["filmAdı"]},Koltuk No:{reader["koltukNo"]},Tarih:{reader["tarih"]}"; 
                                listBox1.Items.Add(biletBilgileri);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Kayıt Bulunamadı.");
                        }
                    }
                }
            }
        }
    }
}
