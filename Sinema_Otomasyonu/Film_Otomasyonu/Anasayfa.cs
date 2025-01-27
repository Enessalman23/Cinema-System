using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace Film_otomasyonu
{
    public partial class Anasayfa : Form
    {
        public Anasayfa()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button13_Click(object sender, EventArgs e)
        {

            Filmler filmler = new Filmler();
            filmler.Show();

        }

        private void button12_Click(object sender, EventArgs e)
        {
            Yönetmenler yönetmenler = new Yönetmenler();
            yönetmenler.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Aktörler aktörler = new Aktörler();
            aktörler.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SalonKayıt salonkayıt = new SalonKayıt();
            salonkayıt.Show();
        }

        private void Anasayfa_Load(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            Bilet bilet = new Bilet();
            bilet.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            BiletsSorgula biletsorgula = new BiletsSorgula();
            biletsorgula.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminGiriş admin = new AdminGiriş();
            admin.Show();
        }
    }
}


