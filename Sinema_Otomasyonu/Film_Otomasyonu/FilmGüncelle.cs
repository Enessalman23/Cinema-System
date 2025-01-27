using Microsoft.IdentityModel.Tokens;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Film_otomasyonu
{
    public partial class FilmGüncelle : Form
    {
        public FilmGüncelle()
        {
            InitializeComponent();
            LoadFilmler();
            dataGridView1.SelectionChanged += DataGridView1_SelectionChanged; // Event handler ekliyoruz
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
                    cmd.Parameters.AddWithValue("@işlem", newId + " numaralı film güncellendi.");

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }

            }
        }

        private void LoadFilmler()
        {
            string connectionString = "Data Source=ENESSS\\SQLEXPRESS;Initial Catalog=film_otomasyonu;Integrated Security=True";
            string query = "SELECT id, isim, cikis_tarihi FROM film";

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

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int selectedFilmID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);
                string filmAdı = textBox1.Text;
                DateTime cikis_tarihi = dateTimePicker1.Value;

                if (textBox1.Text.IsNullOrEmpty())
                {
                    MessageBox.Show("Boş bırakmayın.");
                }
                else
                {
                    string connectionString = "Data Source=ENESSS\\SQLEXPRESS;Initial Catalog=film_otomasyonu;Integrated Security=True";
                    string query = "UPDATE film SET isim = @isim, cikis_tarihi = @cikis_tarihi WHERE id = @id";

                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", selectedFilmID);
                            cmd.Parameters.AddWithValue("@isim", filmAdı);
                            cmd.Parameters.AddWithValue("@cikis_tarihi", cikis_tarihi.ToString("yyyy-MM-dd"));

                            conn.Open();
                            int rowsAffected = cmd.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Başarılı bir şekilde film güncellendi.");
                                logGeçmiş(selectedFilmID);
                                LoadFilmler();

                            }
                            else
                            {
                                MessageBox.Show("Güncellenemedi.");
                            }
                            conn.Close();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen güncellemek istediğiniz filmi seçin.");
            }
        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string filmAdı = dataGridView1.SelectedRows[0].Cells["isim"].Value.ToString();
                DateTime cikis_tarihi = Convert.ToDateTime(dataGridView1.SelectedRows[0].Cells["cikis_tarihi"].Value);

                textBox1.Text = filmAdı;
                dateTimePicker1.Value = cikis_tarihi;
            }
        }

      

        private void FilmGüncelle_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
