using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Film_otomasyonu
{
    public partial class Filmler : Form
    {

        public Filmler()
        {
            InitializeComponent();

        }

        private void Filmler_Load(object sender, EventArgs e)
        {
            string connectionString = "Data Source=ENESSS\\SQLEXPRESS;Initial Catalog=film_otomasyonu;Integrated Security=True";
            string query = "SELECT * FROM film";

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
       

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
