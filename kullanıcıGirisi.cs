using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class kullanıcıGirisi : Form
    {
        SqlCommand komut;
        SqlDataReader dr;

        private string sifre = "", yetki = "";
        public static bool girisOnay = false;

        public kullanıcıGirisi()
        {
            InitializeComponent();
        }

        private void kullanıcıGirisi_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            sifreTextBox.PasswordChar = '*';
        }

        private void girisButon_Click(object sender, EventArgs e)
        {
            if (kAdıTextBox.Text != "misafir" && sifreTextBox.Text != "misafir")
            {
                komut = new SqlCommand("Select sifre,yetki from kullanıcıListesi where kullanıcıAdı='" + kAdıTextBox.Text + "'", Giris.baglanti);
                Giris.baglanti.Open();
                dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    sifre = dr.GetString(0);
                    yetki = dr.GetString(1);
                }
                dr.Close();
                Giris.baglanti.Close();

                if (sifre == sifreTextBox.Text && sifre != "")
                {
                    sistemAyarları.kayitEkle(kAdıTextBox.Text, "Sisteme Giriş Yapıldı");
                    Giris.kullanıcıAdı = kAdıTextBox.Text;
                    Giris.yetki = yetki;
                    girisOnay = true;
                    this.Close();
                }
                else { MessageBox.Show("Hatalı Kullanıcı Adı veya Şifre"); girisOnay = false; }
            }
            else
            {
                sistemAyarları.kayitEkle(kAdıTextBox.Text, "Sisteme Giriş Yapıldı");
                Giris.kullanıcıAdı = "misafir";
                Giris.yetki = "misafir";
                girisOnay = true;
                this.Close();
            }
        }
    }
}
