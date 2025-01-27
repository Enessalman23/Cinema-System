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
    public partial class Bilet : Form
    {
        public Bilet()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void LoadSalon()
        {
            string connectionstring = "Data Source=ENESSS\\SQLEXPRESS;Initial Catalog=film_otomasyonu;Integrated Security=True";

            string query = "SELECT id,salonAdı FROM salon";
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        comboBox2.Items.Add(new ComboBoxItem(reader["salonAdı"].ToString(), reader["id"].ToString()));
                    }
                }
            }
        }
        public void LoadKoltuk()
        {
            string connectionstring = "Data Source=ENESSS\\SQLEXPRESS;Initial Catalog=film_otomasyonu;Integrated Security=True";

            string query = "SELECT id,koltukSayısı FROM salon";
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        comboBox3.Items.Add(new ComboBoxItem(reader["koltukSayısı"].ToString(), reader["id"].ToString()));
                    }
                }
            }
        }

        public void LoadFilms()
        {
            string connectionstring = "Data Source=ENESSS\\SQLEXPRESS;Initial Catalog=film_otomasyonu;Integrated Security=True";

            string query = "SELECT id,isim FROM film";
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        comboBox1.Items.Add(new ComboBoxItem(reader["isim"].ToString(), reader["id"].ToString()));
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string müşteriAd = textBox1.Text;
            string müşteriSoyad = textBox2.Text;
            string telNo = textBox3.Text;
            ComboBoxItem selectedFilm = (ComboBoxItem)comboBox1.SelectedItem;
            ComboBoxItem selectedsalon = (ComboBoxItem)comboBox2.SelectedItem;
            ComboBoxItem selectedkoltuk = (ComboBoxItem)comboBox3.SelectedItem;


            DateTime tarih = dateTimePicker1.Value;

            if (textBox1.Text.IsNullOrEmpty() || textBox2.Text.IsNullOrEmpty() || textBox3.Text.IsNullOrEmpty() || comboBox1.Text.IsNullOrEmpty())
            {
                MessageBox.Show("Tüm Bilgileri Giriniz.");
            }
            else
            {
                string connectionstring = "Data Source=ENESSS\\SQLEXPRESS;Initial Catalog=film_otomasyonu;Integrated Security=True";

                string query = "INSERT INTO biletler (filmID, müşteriAd, müşteriSoyad, telNo, koltukNo, salonNo, tarih) VALUES (@filmID, @müşteriAd, @müşteriSoyad, @telNo, @koltukNo, @salonNo, @tarih)"; using (SqlConnection conn = new SqlConnection(connectionstring))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@filmID", selectedFilm.Value);
                        cmd.Parameters.AddWithValue("@müşteriAd", müşteriAd);
                        cmd.Parameters.AddWithValue("@müşteriSoyad", müşteriSoyad);
                        cmd.Parameters.AddWithValue("@telNo", telNo);
                        cmd.Parameters.AddWithValue("@koltukNo", selectedkoltuk.Value);
                        cmd.Parameters.AddWithValue("@salonNo", selectedsalon.Value);
                        cmd.Parameters.AddWithValue("@tarih", tarih);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Bilet Kaydedildi");
                        conn.Close();
                    }
                }
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                comboBox2.SelectedIndex = -1;
                comboBox3.SelectedIndex = -1;
                comboBox1.SelectedIndex = -1;

            }
        }
        private class ComboBoxItem
        {
            public string Text { get; set; }
            public string Value { get; set; }
            
            public ComboBoxItem(string text,string value)
            {
                Text = text;
                Value = value;
            }
            public override string ToString()
            {
                return Text;
            }
        }

        private void Bilet_Load(object sender, EventArgs e)
        {
            LoadFilms();
            LoadSalon();
            LoadKoltuk();
        }
    }
}
