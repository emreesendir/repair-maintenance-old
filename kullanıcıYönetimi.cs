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
    public partial class kullanıcıYönetimi : Form
    {
        SqlCommand komut;
        SqlDataReader dr;

        public static bool yenile = false;

        public kullanıcıYönetimi()
        {
            InitializeComponent();
        }

        private void kullanıcıYönetimi_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            if (sistemAyarları.islem == true)
            {
                baslikLabel.Text = "Kullanıcı Ekle";
                ekleDuzenleButon.Text = "Ekle";

                kAdıTextBox.Clear();
                sifreTextBox.Clear();
                yetkiComboBox.Text = "Seçiniz...";
            }
            else
            {
                baslikLabel.Text = "Kullanıcı Düzenle";
                ekleDuzenleButon.Text = "Kaydet";

                komut = new SqlCommand("Select sifre,yetki From kullanıcıListesi where kullanıcıAdı='" + sistemAyarları.seciliKullanıcı + "'", Giris.baglanti);
                Giris.baglanti.Open();
                dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    kAdıTextBox.Text = sistemAyarları.seciliKullanıcı;
                    sifreTextBox.Text=dr.GetString(0);
                    yetkiComboBox.Text = dr.GetString(1);
                }
                dr.Close();
                Giris.baglanti.Close();
            }
        }

        private void ekleDuzenleButon_Click(object sender, EventArgs e)
        {
            if (kAdıTextBox.Text == "" || sifreTextBox.Text == "" || yetkiComboBox.Text == "Seçiniz...")
            {
                MessageBox.Show("İşlem Gerçekleştirilemedi!\n\nHiçbir alan boş geçilemez!");
            }
            else
            {
                if (sistemAyarları.islem)
                {
                    komut = new SqlCommand("INSERT INTO kullanıcıListesi VALUES ('" + kAdıTextBox.Text + "' , '" + sifreTextBox.Text + "' , '" + yetkiComboBox.Text + "')", Giris.baglanti);
                    Giris.baglanti.Open();
                    komut.ExecuteNonQuery();
                    Giris.baglanti.Close();
                    yenile = true;
                    MessageBox.Show("Kullanıcı başarıyla eklendi!");
                    this.Close();
                }
                else
                {
                    Giris.baglanti.Open();
                    komut.CommandText = "UPDATE kullanıcıListesi SET kullanıcıAdı='" + kAdıTextBox.Text + "' , sifre='" + sifreTextBox.Text + "' , yetki='" + yetkiComboBox.Text + "' where kullanıcıAdı='" + sistemAyarları.seciliKullanıcı + "'"; 
                    komut.ExecuteNonQuery();
                    Giris.baglanti.Close();
                    yenile = true;
                    MessageBox.Show("Kullanıcı başarıyla güncellendi!");
                    this.Close();
                }
            }
        }
    }
}
