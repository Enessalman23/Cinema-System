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
    public partial class Yönetmenler : Form
    {
        public Yönetmenler()
        {
            InitializeComponent();
        }

        private void Yönetmenler_Load(object sender, EventArgs e)
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
                    DataGridViewTextBoxColumn imageColumn = new DataGridViewTextBoxColumn();
                    imageColumn.Name = "ResimYolu";
                    imageColumn.HeaderText = "Resim Yolu";
                    dataGridView1.Columns.Add(imageColumn);
                    dataGridView1.DataSource = table;
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.Cells["Resim"].Value != null)
                        {
                            string resimYolu = row.Cells["Resim"].Value.ToString();
                            row.Cells["ResimYolu"].Value = resimYolu;
                        }
                    }
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
