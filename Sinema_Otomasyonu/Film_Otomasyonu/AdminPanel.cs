using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Film_otomasyonu
{
    public partial class AdminPanel : Form
    {
        public AdminPanel()
        {
            InitializeComponent();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            FilmEkle filmEkle = new FilmEkle();
            filmEkle.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            FilmSil filmsil = new FilmSil();
            filmsil.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            FilmGüncelle filmGüncelle = new FilmGüncelle();
            filmGüncelle.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            YönetmenKayıt yönetmenkayıt = new YönetmenKayıt();
            yönetmenkayıt.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            AktörKayıt aktörKayıt = new AktörKayıt();
            aktörKayıt.Show();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            Log filmLog = new Log();
            filmLog.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            KayıtlıKullanıcılar kayıtlıKullanıcılar = new KayıtlıKullanıcılar();
            kayıtlıKullanıcılar.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Anasayfa anasayfa = new Anasayfa();
            anasayfa.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Anasayfa anasayfa = new Anasayfa();
            anasayfa.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
            YönetmenSil yönetmensil = new YönetmenSil();
            yönetmensil.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            AktörSil aktörSil = new AktörSil();
            aktörSil.Show();
        }
    }
}
