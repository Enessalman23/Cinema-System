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
    public partial class SalonKayıt : Form
    {
        public SalonKayıt()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string salonadı = textBox1.Text;
            string koltuksayısı = comboBox1.Text;
            if (textBox1.Text.IsNullOrEmpty() || comboBox1.Text.IsNullOrEmpty())
            {
                MessageBox.Show("Lütfen Tüm Bilgileri Giriniz.");
            }
            else
            {
                string connectionString = "Data Source=ENESSS\\SQLEXPRESS;Initial Catalog=film_otomasyonu;Integrated Security=True";
                string query = "INSERT INTO salon (salonAdı, koltukSayısı) VALUES (@salonadı, @koltuksayısı)";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {

                        cmd.Parameters.AddWithValue("@salonAdı", salonadı);
                        cmd.Parameters.AddWithValue("@koltukSayısı", koltuksayısı);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Kayıt başarılı!");
                        conn.Close();
                    }


                }
                textBox1.Clear();
                comboBox1.Text = "";


                
            }
        }

        private void SalonKayıt_Load(object sender, EventArgs e)
        {
            string connectionString = "Data Source=ENESSS\\SQLEXPRESS;Initial Catalog=film_otomasyonu;Integrated Security=True";
            string query = "SELECT * FROM salon";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dataGridView1.DataSource = table;
                }
            }
        }
    }
}
