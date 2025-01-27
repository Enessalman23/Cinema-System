using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.SqlClient;
using System.Collections;
namespace Film_otomasyonu
{
    public partial class FilmEkle : Form
    {

        public FilmEkle()
        {
            InitializeComponent();
        }

        private void FilmEkle_Load(object sender, EventArgs e)
        {
        }
        private void logGeçmiş(int newId)
        {
            string connectionString = "Data Source=ENESSS\\SQLEXPRESS;Initial Catalog=film_otomasyonu;Integrated Security=True";
            string query = "INSERT INTO geçmiş (tarih,işlem) VALUES (@tarih,@işlem)";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {

                    cmd.Parameters.AddWithValue("@tarih", DateTime.Now);
                    cmd.Parameters.AddWithValue("@işlem", newId + " numaralı film eklendi.");

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }

            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string isim = textBox1.Text;
            string süre = textBox2.Text;
            string dil = textBox3.Text;
            DateTime cikis_tarihi = dateTimePicker1.Value;
            if (textBox1.Text.IsNullOrEmpty() || textBox2.Text.IsNullOrEmpty() || dateTimePicker1.Text.IsNullOrEmpty() || textBox3.Text.IsNullOrEmpty())
            {
                MessageBox.Show("Tüm Bilgileri Doldur.");
            }
            else
            {
                string connectionString = "Data Source=ENESSS\\SQLEXPRESS;Initial Catalog=film_otomasyonu;Integrated Security=True";
                string query = @" INSERT INTO film (isim, süre, dil, cikis_tarihi) VALUES (@isim, @süre, @dil, @cikis_tarihi); SELECT SCOPE_IDENTITY();";

                int newId;

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {

                        cmd.Parameters.AddWithValue("@isim", isim);
                        cmd.Parameters.AddWithValue("@süre", süre);
                        cmd.Parameters.AddWithValue("@dil", dil);
                        cmd.Parameters.AddWithValue("@cikis_tarihi", cikis_tarihi.ToString("yyyy-MM-dd"));

                        conn.Open();
                        object result = cmd.ExecuteScalar();
                        newId = Convert.ToInt32(result);


                        MessageBox.Show("Başarılı bir şekilde film eklendi!");
                        conn.Close();

                    }

                }
                logGeçmiş(newId);


                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();


            }

        }

      

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
