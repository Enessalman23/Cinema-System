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
    public partial class YönetmenSil : Form
    {
        public YönetmenSil()
        {
            InitializeComponent();
            LoadYönetmen();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
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
                    cmd.Parameters.AddWithValue("@işlem", newId + " numaralı Yönetmen silindi.");

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }

            }
        }
        private void LoadYönetmen()
        {
            string connectionString = "Data Source=ENESSS\\SQLEXPRESS;Initial Catalog=film_otomasyonu;Integrated Security=True";
            string query = "SELECT * FROM yönetmen";

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
                int selectedYönetmenID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);

                string connectionString = "Data Source=ENESSS\\SQLEXPRESS;Initial Catalog=film_otomasyonu;Integrated Security=True";
                string query = "DELETE FROM yönetmen WHERE id = @id";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", selectedYönetmenID);

                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Başarılı bir şekilde Yönetmen silindi!");
                            LoadYönetmen();
                            logGeçmiş(selectedYönetmenID);
                        }
                        else
                        {
                            MessageBox.Show("Belirtilen isimde Yönetmen bulunamadı.");
                        }
                        conn.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen silmek istediğiniz Yönetmeni seçin.");
            }
        }
    }
}
