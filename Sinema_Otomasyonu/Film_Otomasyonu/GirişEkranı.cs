using System.Data.SqlClient;
using System.Data;
using Microsoft.IdentityModel.Tokens;
namespace Film_otomasyonu
{
    public partial class GirişEkranı : Form
    {




        public GirişEkranı()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Kayıt kayıt = new Kayıt();
            kayıt.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string email = textBox1.Text;
            string şifre = textBox2.Text;

            if (textBox1.Text.IsNullOrEmpty() || textBox2.Text.IsNullOrEmpty())
            {
                MessageBox.Show("Tüm Bilgileri Giriniz.");
            }
            else
            {

                string query = "SELECT COUNT(1) FROM yeni_kullanıcılar WHERE email=@email AND şifre=@sifre";
                using (SqlConnection conn = new SqlConnection("Data Source=ENESSS\\SQLEXPRESS;Initial Catalog=film_otomasyonu;Integrated Security=True"))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@sifre", şifre);
                        conn.Open();
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        if (count == 1)
                        {
                            MessageBox.Show("Giriş başarılı!");
                            this.Hide();
                            Anasayfa anasayfa = new Anasayfa();
                            anasayfa.Show();

                        }
                        else
                        {
                            MessageBox.Show("Kullanıcı adı veya şifre yanlış!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            
            }



        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminGiriş admin = new AdminGiriş();
            admin.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
    

