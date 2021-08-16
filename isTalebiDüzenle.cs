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
    public partial class isTalebiDüzenle : Form
    {
        SqlCommand komut;
        SqlDataReader dr;

        public static bool yenile = false;

        string eskiEkipmanKodu = "", eskiIsTanımı = "";

        public isTalebiDüzenle()
        {
            InitializeComponent();
        }

        private void isTalebiDüzenle_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            string ekipmanID = "";
            komut = new SqlCommand("Select * From işListesi Where [İşlem ID]=" + isPlanı.seciliId, Giris.baglanti);
            Giris.baglanti.Open(); dr = komut.ExecuteReader();
            while (dr.Read()) 
            {
                isTanımıTextBox.Text = dr.GetString(0);
                talepEdenTextBox.Text = dr.GetString(1);
                sorumluTextBox.Text = dr.GetString(2);
                kayıtTarihiDateTimePicker.Value = dr.GetDateTime(3);
                bitisTarihiDateTimePicker.Value = dr.GetDateTime(4);
                islemTuruComboBox.Text = dr.GetString(5);
                ekipmanID = dr.GetInt32(6).ToString();
            }
            dr.Close(); Giris.baglanti.Close();

            komut = new SqlCommand("Select Birim,Adı,[Ekipman Kodu] From makinaListesi Where ID=" + ekipmanID, Giris.baglanti);
            Giris.baglanti.Open(); dr = komut.ExecuteReader();
            while (dr.Read()) { birimTextBox.Text = dr.GetString(0); ekipmanAdıTextBox.Text = dr.GetString(1); ekipmanKoduTextBox.Text = dr.GetString(2); } dr.Close(); Giris.baglanti.Close();

            komut = new SqlCommand("Select [Arıza Tipi],[Duruş Saati] From işListesi Where [İşlem ID]=" + isPlanı.seciliId, Giris.baglanti);
            Giris.baglanti.Open(); dr = komut.ExecuteReader();
            while (dr.Read()) { arızaComboBox.Text = dr.GetString(0); durusTextBox.Text = dr.GetString(1); } dr.Close(); Giris.baglanti.Close();

            eskiEkipmanKodu = ekipmanKoduTextBox.Text; eskiIsTanımı = isTanımıTextBox.Text;
            araButon.PerformClick();
            if (islemTuruComboBox.Text != "Onarım") { durusLabel.Visible = false; durusTextBox.Visible = false; arızaComboBox.Visible = false; arızaLabel.Visible = false; }
            else { durusLabel.Visible = true; durusTextBox.Visible = true; arızaComboBox.Visible = true; arızaLabel.Visible = true; }
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
            if (talepEdenTextBox.Text != "" && sorumluTextBox.Text != "" && birimTextBox.Text != "" && isTanımıTextBox.Text != "" && islemTuruComboBox.Text != "Seçiniz" && bitiskayıtfark >= 0 && bitisbugunfark >= 0)
            {
                int ekipmanId = 0;
                komut = new SqlCommand("Select ID From makinaListesi Where [Ekipman Kodu]='" + ekipmanKoduTextBox.Text + "'", Giris.baglanti);
                Giris.baglanti.Open(); dr = komut.ExecuteReader();
                while (dr.Read()) { ekipmanId = dr.GetInt32(0); } dr.Close(); Giris.baglanti.Close();

                if (islemTuruComboBox.Text == "Onarım")
                {
                    if (arızaComboBox.Text != "Seçiniz" && durusTextBox.Text != "")
                    {
                        komut.CommandText = "UPDATE işListesi SET [İş Tanımı]='" + isTanımıTextBox.Text + "' , [Talep Eden]='" + talepEdenTextBox.Text + "' , Sorumlu='" + sorumluTextBox.Text + "',[Kayıt Tarihi]='" + kayıtTarihiDateTimePicker.Value.ToString("MM.dd.yyyy") + "',[Bitiş Tarihi]='" + bitisTarihiDateTimePicker.Value.ToString("MM.dd.yyyy") + "',[İşlem Türü]='" + islemTuruComboBox.Text + "',[Ekipman ID]=" + ekipmanId.ToString() + ",[Arıza Tipi]='" + arızaComboBox.Text + "',[Duruş Saati]='" + durusTextBox.Text + "' where [İşlem ID]=" + isPlanı.seciliId;
                        Giris.baglanti.Open(); komut.ExecuteNonQuery(); Giris.baglanti.Close();
                        MessageBox.Show("Kayıt başarıyla güncellendi!");
                        sistemAyarları.kayitEkle(Giris.kullanıcıAdı, "İş Talebi Düzenlendi [Ekipman Kodu]: " + eskiEkipmanKodu + " ---> " + ekipmanKoduTextBox.Text + " [İş Tanımı]: " + eskiIsTanımı + " ---> " + isTanımıTextBox.Text);
                        this.Close();
                        yenile = true;
                    }
                    else { MessageBox.Show("İşlem Gerçekleştirilemedi!\n\nHiçbir alan boş geçilemez!"); }
                }
                else
                {
                    komut.CommandText = "UPDATE işListesi SET [İş Tanımı]='" + isTanımıTextBox.Text + "' , [Talep Eden]='" + talepEdenTextBox.Text + "' , Sorumlu='" + sorumluTextBox.Text + "',[Kayıt Tarihi]='" + kayıtTarihiDateTimePicker.Value.ToString("MM.dd.yyyy") + "',[Bitiş Tarihi]='" + bitisTarihiDateTimePicker.Value.ToString("MM.dd.yyyy") + "',[İşlem Türü]='" + islemTuruComboBox.Text + "',[Ekipman ID]=" + ekipmanId.ToString() + ",[Arıza Tipi]=NULL,[Duruş Saati]=NULL where [İşlem ID]=" + isPlanı.seciliId;
                    Giris.baglanti.Open(); komut.ExecuteNonQuery(); Giris.baglanti.Close();
                    MessageBox.Show("Kayıt başarıyla güncellendi!");
                    sistemAyarları.kayitEkle(Giris.kullanıcıAdı, "İş Talebi Düzenlendi [Ekipman Kodu]: " + eskiEkipmanKodu + " ---> " + ekipmanKoduTextBox.Text + " [İş Tanımı]: " + eskiIsTanımı + " ---> " + isTanımıTextBox.Text);
                    this.Close();
                    yenile = true;
                }
            }
            else { MessageBox.Show("İşlem Gerçekleştrilemedi!\n\n* Hiçbir Alan Boş Geçilemez!\n* Bitiş Tarihi Geçmiş Bir Tarih Olamaz!\n* Bitiş Tarihi Kayıt Tarihinden Önceki Bir Tarih Olamaz!"); yenile = false; }
        }

        private void silButon_Click(object sender, EventArgs e)
        {
            DialogResult Secim = new DialogResult();

            Secim = MessageBox.Show("İş Kaydını Silmeyi Onaylıyor Musunuz?", "Dikkat!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (Secim == DialogResult.Yes)
            {
                Giris.baglanti.Open();
                komut.CommandText = "DELETE işListesi Where [İşlem ID]=" + isPlanı.seciliId;
                komut.ExecuteNonQuery();
                Giris.baglanti.Close();
                MessageBox.Show("Kayıt Silindi");
                sistemAyarları.kayitEkle(Giris.kullanıcıAdı, "İş Talebi Silindi [Ekipman Kodu]: " + eskiEkipmanKodu + " [İş Tanımı]: " + eskiIsTanımı);
                yenile = true;
            }
        }

        private void islemTuruComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (islemTuruComboBox.Text != "Onarım") { durusLabel.Visible = false; durusTextBox.Visible = false; arızaComboBox.Visible = false; arızaLabel.Visible = false; }
            else { durusLabel.Visible = true; durusTextBox.Visible = true; arızaComboBox.Visible = true; arızaLabel.Visible = true; }
        }
    }
}
