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
    public partial class KayıtlıKullanıcılar : Form
    {
        public KayıtlıKullanıcılar()
        {
            InitializeComponent();
        }

        private void KayıtlıKullanıcılar_Load(object sender, EventArgs e)
        {
            string connectionString = "Data Source=ENESSS\\SQLEXPRESS;Initial Catalog=film_otomasyonu;Integrated Security=True";
            string query = "SELECT * FROM yeni_kullanıcılar";

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

       

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
