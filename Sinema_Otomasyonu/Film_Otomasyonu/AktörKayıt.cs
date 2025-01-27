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
using System.Data.SqlClient;

namespace Film_otomasyonu
{
    public partial class AktörKayıt : Form
    {
        public AktörKayıt()
        {
            InitializeComponent();
        }
       

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Resim Seçin";
            openFileDialog.Filter = "PNG | *.png |JPG |*.jpg|All Files|*.*";
            openFileDialog.FilterIndex = 3;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox3.Image = new Bitmap(openFileDialog.FileName);
                textBox3.Text = openFileDialog.FileName;
                MessageBox.Show(openFileDialog.FileName.ToString());
            }
        }

        
       

        private void button3_Click(object sender, EventArgs e)
        {
            
            string isim = textBox1.Text;
            string soyad = textBox2.Text;
            string cinsiyet = radioButton1.Checked ? "E" : radioButton2.Checked ? "K" :string.Empty;
            string resim = textBox3.Text;
            
            if (textBox1.Text.IsNullOrEmpty() || textBox2.Text.IsNullOrEmpty())
            {
                MessageBox.Show("Lütfen Tüm Bilgileri Giriniz.");
            }
            else
            {   
                string connectionString = "Data Source=ENESSS\\SQLEXPRESS;Initial Catalog=film_otomasyonu;Integrated Security=True";
                string query = "INSERT INTO aktör (isim, soyad,cinsiyet,resim) VALUES (@isim, @soyad ,@cinsiyet,@resim)";
                int newId;
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {

                        cmd.Parameters.AddWithValue("@isim", isim);
                        cmd.Parameters.AddWithValue("@soyad", soyad);
                        cmd.Parameters.AddWithValue("@cinsiyet", cinsiyet);
                        cmd.Parameters.AddWithValue("@resim", resim);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Kayıt başarılı!");
                        conn.Close();
                    }


                }
                
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                pictureBox3.Image = null;
              
                
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }
    }
 }
