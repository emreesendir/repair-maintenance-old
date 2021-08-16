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
    public partial class isTalebiEkle : Form
    {
        SqlCommand komut;
        SqlDataReader dr;

        public static bool yenile = false;

        public isTalebiEkle()
        {
            InitializeComponent();
        }

        private void isTalebiEkle_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void araButon_Click(object sender, EventArgs e)
        {
            if (ekipmanKoduTextBox.Text != "")
            {
                komut = new SqlCommand("Select Birim,Adı From makinaListesi Where [Ekipman Kodu]='" + ekipmanKoduTextBox.Text + "'", Giris.baglanti);
                Giris.baglanti.Open(); dr = komut.ExecuteReader();
                while (dr.Read()) { birimTextBox.Text = dr.GetString(0); ekipmanAdıTextBox.Text = dr.GetString(1); } dr.Close(); Giris.baglanti.Close();
                if (birimTextBox.Text == "") { MessageBox.Show("Geçersiz Ekipman Kodu!"); }
            }
            else { MessageBox.Show("Ekipman Kodu Giriniz!"); }
        }

        private void ekipmanKoduTextBox_TextChanged(object sender, EventArgs e) { birimTextBox.Clear(); ekipmanAdıTextBox.Clear(); }

        private void kaydetButon_Click(object sender, EventArgs e)
        {
            int bitiskayıtfark = Convert.ToInt32(bitisTarihiDateTimePicker.Value.Subtract(kayıtTarihiDateTimePicker.Value).Days);
            DateTime bugun = DateTime.Today;
            int bitisbugunfark = Convert.ToInt32(bitisTarihiDateTimePicker.Value.Subtract(bugun).Days);
            if (talepEdenTextBox.Text != "" && sorumluTextBox.Text != "" && birimTextBox.Text != "" && isTanımıTextBox.Text != "" && islemTuruComboBox.Text != "Seçiniz" && bitiskayıtfark>=0 && bitisbugunfark>=0)
            {
                int ekipmanId = 0;
                komut = new SqlCommand("Select ID From makinaListesi Where [Ekipman Kodu]='" + ekipmanKoduTextBox.Text + "'", Giris.baglanti);
                Giris.baglanti.Open(); dr = komut.ExecuteReader();
                while (dr.Read()) { ekipmanId = dr.GetInt32(0); } dr.Close(); Giris.baglanti.Close();

                if (islemTuruComboBox.Text == "Onarım")
                {
                    if (durusTextBox.Text != "" && arızaComboBox.Text != "Seçiniz")
                    {
                        komut = new SqlCommand("INSERT INTO işListesi VALUES ('" + isTanımıTextBox.Text + "' , '" + talepEdenTextBox.Text + "' , '" + sorumluTextBox.Text + "','" + kayıtTarihiDateTimePicker.Value.ToString("MM.dd.yyyy") + "','" + bitisTarihiDateTimePicker.Value.ToString("MM.dd.yyyy") + "','" + islemTuruComboBox.Text + "','" + ekipmanId.ToString() + "','" + arızaComboBox.Text + "','" + durusTextBox.Text + "')", Giris.baglanti);
                        Giris.baglanti.Open(); komut.ExecuteNonQuery(); Giris.baglanti.Close();
                        MessageBox.Show("Kayıt başarıyla eklendi!");
                        sistemAyarları.kayitEkle(Giris.kullanıcıAdı, "İş Talebi Eklendi [Ekipman Kodu]: " + ekipmanKoduTextBox.Text + " [İş Tanımı]: " + isTanımıTextBox.Text);
                        this.Close();
                        yenile = true;
                    }
                    else { MessageBox.Show("İşlem Gerçekleştirilemedi!\n\nHiçbir alan boş geçilemez!"); }
                }
                else
                {
                    komut = new SqlCommand("INSERT INTO işListesi VALUES ('" + isTanımıTextBox.Text + "' , '" + talepEdenTextBox.Text + "' , '" + sorumluTextBox.Text + "','" + kayıtTarihiDateTimePicker.Value.ToString("MM.dd.yyyy") + "','" + bitisTarihiDateTimePicker.Value.ToString("MM.dd.yyyy") + "','" + islemTuruComboBox.Text + "','" + ekipmanId.ToString() + "',NULL,NULL)", Giris.baglanti);
                    Giris.baglanti.Open(); komut.ExecuteNonQuery(); Giris.baglanti.Close();
                    MessageBox.Show("Kayıt başarıyla eklendi!");
                    sistemAyarları.kayitEkle(Giris.kullanıcıAdı, "İş Talebi Eklendi [Ekipman Kodu]: " + ekipmanKoduTextBox.Text + " [İş Tanımı]: " + isTanımıTextBox.Text);
                    this.Close();
                    yenile = true;
                }
            }
            else { MessageBox.Show("İşlem Gerçekleştrilemedi!\n\n* Hiçbir Alan Boş Geçilemez!\n* Bitiş Tarihi Geçmiş Bir Tarih Olamaz!\n* Bitiş Tarihi Kayıt Tarihinden Önceki Bir Tarih Olamaz!"); yenile = false; }
        }

        private void islemTuruComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (islemTuruComboBox.Text != "Onarım") { durusLabel.Visible = false; durusTextBox.Visible = false; arızaComboBox.Visible = false; arızaLabel.Visible = false; }
            else { durusLabel.Visible = true; durusTextBox.Visible = true; arızaComboBox.Visible = true; arızaLabel.Visible = true; }
        }
    }
}