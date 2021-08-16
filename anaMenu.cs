using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class anaMenu : Form
    {
        public anaMenu()
        {
            InitializeComponent();
        }

        private void anaMenu_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            kAdıLabel.Text = Giris.kullanıcıAdı;
            yetkiLabel.Text = Giris.yetki;

            if (Giris.yetki != "Yönetici" && Giris.yetki!="Sistem Yöneticisi") { sistemAyarlarıButon.Enabled = false; }
        }

        private void cikisButon_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void sistemAyarlarıButon_Click(object sender, EventArgs e)
        {
            sistemAyarları.kayitEkle(Giris.kullanıcıAdı,"Sistem Ayarlarına Girildi");
            sistemAyarları ayarlar = new sistemAyarları();
            ayarlar.Show();
            this.Hide();
        }

        private void makinaListesiButon_Click(object sender, EventArgs e)
        {
            sistemAyarları.kayitEkle(Giris.kullanıcıAdı,"Ekipman Listesine Girildi");
            makinaListesi makinalist = new makinaListesi();
            makinalist.Show();
            this.Hide();
        }

        private void anaMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Giris.kullanıcıCikisi();
            Giris giris = new Giris();
            giris.Show();
        }

        private void isPlanıButon_Click(object sender, EventArgs e)
        {
            sistemAyarları.kayitEkle(Giris.kullanıcıAdı,"İş Planı Modülene Girildi");
            isPlanı isplanı = new isPlanı();
            isplanı.Show();
            this.Hide();
        }

        private void isGecmisiButon_Click(object sender, EventArgs e)
        {
            sistemAyarları.kayitEkle(Giris.kullanıcıAdı,"İş Geçmişine Girildi");
            isGecmisi gecmis = new isGecmisi();
            gecmis.Show();
            this.Hide();
        }
    }
}
