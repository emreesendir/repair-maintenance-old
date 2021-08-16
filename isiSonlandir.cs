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
    public partial class isiSonlandir : Form
    {
        SqlCommand komut;
        SqlDataReader dr;

        public static bool yenile;

        public isiSonlandir()
        {
            InitializeComponent();
        }

        private void isiSonlandir_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            if (isPlanı.seciliIsTuru == "Periyodik Bakım")
            {
                kayıtTarihLabel.Text = "Son Bakım Tarihi";
                sorumluLabel.Text = "Bakım Periyodu";
                string ekipmanID = "";
                komut = new SqlCommand("Select ID,Açıklama,Periyot,ISNULL(sonBakımTarihi,'2000-01-01') From periyodikBakımListesi Where bakımNo=" + isPlanı.seciliPBakımId, Giris.baglanti);
                Giris.baglanti.Open(); dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    ekipmanID = dr.GetInt32(0).ToString();
                    isTanımıTextBox.Text = dr.GetString(1);
                    sorumluTextBox.Text = Convert.ToString(dr.GetInt32(2));
                    kayıtTarihiDateTimePicker.Value = dr.GetDateTime(3);
                }
                dr.Close(); Giris.baglanti.Close();
                islemTuruComboBox.Text = "Periyodik Bakım";
                bitisTarihiDateTimePicker.Value = DateTime.Today;
                talepEdenTextBox.Text = "Bakım Atölyesi";

                komut = new SqlCommand("Select Birim,Adı,[Ekipman Kodu] From makinaListesi Where ID=" + ekipmanID, Giris.baglanti);
                Giris.baglanti.Open(); dr = komut.ExecuteReader();
                while (dr.Read()) { birimTextBox.Text = dr.GetString(0); ekipmanAdıTextBox.Text = dr.GetString(1); ekipmanKoduTextBox.Text = dr.GetString(2); } dr.Close(); Giris.baglanti.Close();
            }
            else
            {
                kayıtTarihLabel.Text = "Kayıt Tarihi";
                sorumluLabel.Text = "Sorumlu";
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
            }
            if (islemTuruComboBox.Text != "Onarım") { durusLabel.Visible = false; durusTextBox.Visible = false; arızaComboBox.Visible = false; arızaLabel.Visible = false; bitisLabel.Visible = false; bitisTextBox.Visible = false; }
            else { durusLabel.Visible = true; durusTextBox.Visible = true; arızaComboBox.Visible = true; arızaLabel.Visible = true; bitisLabel.Visible = true; bitisTextBox.Visible = true; }
        }

        private void kaydetButon_Click(object sender, EventArgs e)
        {
            int bitiskayıtfark = Convert.ToInt32(bitisTarihiDateTimePicker.Value.Subtract(kayıtTarihiDateTimePicker.Value).Days);
            DateTime bugun = DateTime.Today;
            int bitisbugunfark = Convert.ToInt32(bitisTarihiDateTimePicker.Value.Subtract(bugun).Days);

            if (talepEdenTextBox.Text != "" && sorumluTextBox.Text != "" && birimTextBox.Text != "" && isTanımıTextBox.Text != "" && islemTuruComboBox.Text != "Seçiniz" && bitiskayıtfark >= 0 && bitisbugunfark <= 0)
            {
                if (isPlanı.seciliIsTuru == "Periyodik Bakım")
                {
                    int ekipmanId = 0;
                    komut = new SqlCommand("Select ID From makinaListesi Where [Ekipman Kodu]='" + ekipmanKoduTextBox.Text + "'", Giris.baglanti);
                    Giris.baglanti.Open(); dr = komut.ExecuteReader();
                    while (dr.Read()) { ekipmanId = dr.GetInt32(0); } dr.Close(); Giris.baglanti.Close();
                    
                    komut = new SqlCommand("INSERT INTO işGeçmişi VALUES ('" + isTanımıTextBox.Text + "' , '" + talepEdenTextBox.Text + "' , 'Bakım Atölyesi','" + kayıtTarihiDateTimePicker.Value.ToString("MM.dd.yyyy") + "','" + bitisTarihiDateTimePicker.Value.ToString("MM.dd.yyyy") + "','" + islemTuruComboBox.Text + "','" + ekipmanId.ToString() + "','" + aciklamaTextBox.Text + "','" + birimTextBox.Text + "')", Giris.baglanti);
                    Giris.baglanti.Open(); komut.ExecuteNonQuery(); Giris.baglanti.Close();

                    DateTime sonrakiBakım = bitisTarihiDateTimePicker.Value.AddDays(Convert.ToUInt32(sorumluTextBox.Text));

                    komut.CommandText = "UPDATE periyodikBakımListesi SET birSonrakiBakımTarihi='" + sonrakiBakım.ToString("MM.dd.yyyy") + "', sonBakımTarihi='" + bitisTarihiDateTimePicker.Value.ToString("MM.dd.yyyy") + "' where bakımNo=" + isPlanı.seciliPBakımId;
                    Giris.baglanti.Open(); komut.ExecuteNonQuery(); Giris.baglanti.Close();
                    MessageBox.Show("İşlem Tamamlandı!");
                    sistemAyarları.kayitEkle(Giris.kullanıcıAdı, "İşlem Sonlandırıldı [Ekipman Kodu]: " + ekipmanKoduTextBox.Text + " [İş Tanımı: ]" + isTanımıTextBox.Text + "[Açıklama]: " + aciklamaTextBox.Text);
                    yenile = true;
                    this.Close();
                }
                else
                {
                    int ekipmanId = 0;
                    komut = new SqlCommand("Select ID From makinaListesi Where [Ekipman Kodu]='" + ekipmanKoduTextBox.Text + "'", Giris.baglanti);
                    Giris.baglanti.Open(); dr = komut.ExecuteReader();
                    while (dr.Read()) { ekipmanId = dr.GetInt32(0); } dr.Close(); Giris.baglanti.Close();

                    if (islemTuruComboBox.Text == "Onarım")
                    {
                        if (bitisTextBox.Text!="")
                        {
                            komut = new SqlCommand("INSERT INTO işGeçmişi VALUES ('" + isTanımıTextBox.Text + "' , '" + talepEdenTextBox.Text + "' , '" + sorumluTextBox.Text + "','" + kayıtTarihiDateTimePicker.Value.ToString("MM.dd.yyyy") + "','" + bitisTarihiDateTimePicker.Value.ToString("MM.dd.yyyy") + "','" + islemTuruComboBox.Text + "','" + ekipmanId.ToString() + "','" + aciklamaTextBox.Text + "','" + birimTextBox.Text + "','" + arızaComboBox.Text + "','" + durusTextBox.Text + "','" + bitisTextBox.Text + "')", Giris.baglanti);
                            Giris.baglanti.Open(); komut.ExecuteNonQuery(); Giris.baglanti.Close();
                        }
                        else { MessageBox.Show("İşlem Gerçekleştirilemedi!\n\nHiçbir alan boş geçilemez!"); }
                    }
                    else
                    {
                        komut = new SqlCommand("INSERT INTO işGeçmişi VALUES ('" + isTanımıTextBox.Text + "' , '" + talepEdenTextBox.Text + "' , '" + sorumluTextBox.Text + "','" + kayıtTarihiDateTimePicker.Value.ToString("MM.dd.yyyy") + "','" + bitisTarihiDateTimePicker.Value.ToString("MM.dd.yyyy") + "','" + islemTuruComboBox.Text + "','" + ekipmanId.ToString() + "','" + aciklamaTextBox.Text + "','" + birimTextBox.Text + "',NULL,NULL,NULL)", Giris.baglanti);
                        Giris.baglanti.Open(); komut.ExecuteNonQuery(); Giris.baglanti.Close();
                    }                    
                    
                    Giris.baglanti.Open();
                    komut.CommandText = "DELETE işListesi Where [İşlem ID]=" + isPlanı.seciliId;
                    komut.ExecuteNonQuery();
                    Giris.baglanti.Close();
                    MessageBox.Show("İşlem Tamamlandı!");
                    yenile = true;
                    this.Close();
                }
            }
            else { MessageBox.Show("İşlem Gerçekleştrilemedi!\n\n* Hiçbir Alan Boş Geçilemez!\n* Bitiş Tarihi Geçmiş Bir Tarih Olamaz!\n* Bitiş Tarihi Kayıt Tarihinden Önceki Bir Tarih Olamaz!"); yenile = false; }
        }
    }
}
