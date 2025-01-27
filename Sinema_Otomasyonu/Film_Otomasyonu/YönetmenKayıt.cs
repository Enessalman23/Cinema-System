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

namespace Film_otomasyonu
{
    public partial class YönetmenKayıt : Form
    {
        public YönetmenKayıt()
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
            string cinsiyet = radioButton1.Checked ? "E" : radioButton2.Checked ? "K" : string.Empty;
            string Resim = textBox3.Text;
            
            if (textBox1.Text.IsNullOrEmpty() || textBox2.Text.IsNullOrEmpty())
            {
                MessageBox.Show("Lütfen Tüm Bilgileri Giriniz.");
            }
            else
            {

                if (string.IsNullOrWhiteSpace(isim) || string.IsNullOrWhiteSpace(soyad) || string.IsNullOrWhiteSpace(cinsiyet))
                { MessageBox.Show("Lütfen Tüm Bilgileri Giriniz.");
                }
                else
                {
                    string connectionString = "Data Source=ENESSS\\SQLEXPRESS;Initial Catalog=film_otomasyonu;Integrated Security=True"; 
                    string query = "INSERT INTO yönetmen (isim, soyad, cinsiyet,Resim) VALUES (@isim, @soyad, @cinsiyet,@Resim)"; 
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    { 
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        { 
                            cmd.Parameters.AddWithValue("@isim", isim); 
                            cmd.Parameters.AddWithValue("@soyad", soyad);
                            cmd.Parameters.AddWithValue("@cinsiyet", cinsiyet);
                            cmd.Parameters.AddWithValue("@Resim", Resim);
                            conn.Open(); cmd.ExecuteNonQuery();
                            MessageBox.Show("Kayıt başarılı!");
                            conn.Close(); 
                        } 
                    }
                    
                    textBox1.Clear(); 
                    textBox2.Clear(); 
                    radioButton1.Checked = false; 
                    radioButton2.Checked = false;
                    pictureBox3.Image = null;
                    textBox3.Clear();
                    


                }
            }

            
        } private void button4_Click(object sender, EventArgs e)
            {
                this.Close();


            }
}
    }  