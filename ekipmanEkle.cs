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
    public partial class ekipmanEkle : Form
    {
        SqlCommand komut;

        public static bool yenile = false;

        public ekipmanEkle()
        {
            InitializeComponent();
        }

        private void bilgiIptalButon_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ekipmanEkle_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            ekipmanAdıTextBox.Clear();
            ekipmanKoduTextBox.Clear();
            birimComboBox.Items.Clear();
            grupComboBox.Items.Clear();
            for (int i = 0; i < makinaListesi.birimler.Count; i++) { birimComboBox.Items.Add(makinaListesi.birimler[i]); }
            for (int i = 0; i < makinaListesi.gruplar.Count; i++) { grupComboBox.Items.Add(makinaListesi.gruplar[i]); }

            birimComboBox.Text = "Seçiniz";
            grupComboBox.Text = "Seçiniz";
        }

        private void bilgiKaydetButon_Click(object sender, EventArgs e)
        {
            if (ekipmanKoduTextBox.Text == "" || ekipmanAdıTextBox.Text == "" || birimComboBox.Text == "Seçiniz" || grupComboBox.Text == "Seçiniz" || markaTextBox.Text == "") MessageBox.Show("İşlem Gerçekleştirilemedi!\n\n* Hiçbir alan boş geçilemez!");
            else
            {
                try
                {
                    string komutMetni = "INSERT INTO makinaListesi VALUES ('" + birimComboBox.Text + "','" + grupComboBox.Text + "','" + ekipmanKoduTextBox.Text + "','" + ekipmanAdıTextBox.Text + "',";
                    if (seriNoTextBox.Text == "" || seriNoTextBox.Text == "Belirtilmedi") { komutMetni = komutMetni + " NULL ,"; } else { komutMetni = komutMetni + "'" + seriNoTextBox.Text + "',"; }
                    if (modelTextBox.Text == "" || modelTextBox.Text == "Belirtilmedi") { komutMetni = komutMetni + "  NULL , "; } else { komutMetni = komutMetni + "'" + modelTextBox.Text + "',"; }
                    if (imalTarihiTextBox.Text == "" || imalTarihiTextBox.Text == "Belirtilmedi") { komutMetni = komutMetni + "  NULL ,"; } else { komutMetni = komutMetni + "'" + imalTarihiTextBox.Text + "',"; }
                    if (markaTextBox.Text == "" || markaTextBox.Text == "Belirtilmedi") { komutMetni = komutMetni + "  NULL "; } else { komutMetni = komutMetni + "'" + markaTextBox.Text + "'"; }
                    komut = new SqlCommand(komutMetni + ")", Giris.baglanti);
                    Giris.baglanti.Open();
                    komut.ExecuteNonQuery();
                    Giris.baglanti.Close();
                    MessageBox.Show("Ekipman başarıyla eklendi!");
                    sistemAyarları.kayitEkle(Giris.kullanıcıAdı, "Ekipman Eklendi [Ekipman Kodu]: " + ekipmanKoduTextBox.Text);
                    yenile = true;
                }
                catch (Exception) { MessageBox.Show("İşlem gerçekleştrilemedi!\nAynı ekipman kodu birden fazla ekipmana verilemez!"); Giris.baglanti.Close(); }
            }
        }
    }
}