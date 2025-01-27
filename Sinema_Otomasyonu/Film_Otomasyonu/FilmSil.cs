using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Film_otomasyonu
{
    public partial class FilmSil : Form
    {
        public FilmSil()
        {
            InitializeComponent();
            LoadFilmler();
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
                    cmd.Parameters.AddWithValue("@işlem", newId + " numaralı film silindi.");

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }

            }
        }
        private void LoadFilmler()
        {
            string connectionString = "Data Source=ENESSS\\SQLEXPRESS;Initial Catalog=film_otomasyonu;Integrated Security=True";
            string query = "SELECT id,isim  FROM film";

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

                string connectionString = "Data Source=ENESSS\\SQLEXPRESS;Initial Catalog=film_otomasyonu;Integrated Security=True";
                string query = "DELETE FROM film WHERE id = @id";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", selectedFilmID);

                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Başarılı bir şekilde film silindi!");
                            LoadFilmler(); // Filmleri yeniden yükleyin
                            logGeçmiş(selectedFilmID);
                        }
                        else
                        {
                            MessageBox.Show("Belirtilen isimde film bulunamadı.");
                        }
                        conn.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen silmek istediğiniz filmi seçin.");
            }
        }

        

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
