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
    public partial class grupYönetimi : Form
    {
        SqlCommand komut;
        SqlDataReader dr;

        OpenFileDialog dosyasec = new OpenFileDialog();
        sistemAyarları sistem = new sistemAyarları();

        public static bool yenile = false;

        public grupYönetimi()
        {
            InitializeComponent();
        }

        private void grupYönetimi_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            if (sistemAyarları.islem==true)
            {
                baslikLable.Text = "Grup Ekle";
                düzenleEkleButon.Text = "Ekle";

                grupAdıTextBox.Clear();
                sicilTextBox.Clear();
                gunlukTextBox.Clear();
                calistirmaTextBox.Clear();
                yillikTextBox.Clear();
                semaButon.Enabled = false;
            }
            else
            {
                baslikLable.Text = "Grup Düzenle";
                düzenleEkleButon.Text = "Kaydet";

                komut = new SqlCommand("Select sicilSablonAdresi,calistirmaSablonAdresi,gunlukBakımSablonAdresi,yillikBakımSablonAdresi,ISNULL(Şema,'') From makinaGrupları where makinaGrubu='" + sistemAyarları.seciliGrup + "'", Giris.baglanti);
                Giris.baglanti.Open();
                dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    grupAdıTextBox.Text = sistemAyarları.seciliGrup;
                    sicilTextBox.Text = dr.GetString(0);
                    gunlukTextBox.Text = dr.GetString(2);
                    calistirmaTextBox.Text = dr.GetString(1);
                    yillikTextBox.Text = dr.GetString(3);
                    semaTextBox.Text = dr.GetString(4);
                }
                dr.Close();
                Giris.baglanti.Close();
                if (semaTextBox.Text == "") { semaCheckBox1.Checked = false; semaButon.Enabled = false; } else { semaCheckBox1.Checked = true; semaButon.Enabled = true; }
            }
        }

        private void sicilSablonButon_Click(object sender, EventArgs e)
        {
            dosyasec.Title = "Şablon Seçin";
            dosyasec.InitialDirectory = @"C:\Program Files\Basak BOS v1.0\Templates\Template4";
            dosyasec.ShowDialog();
            sicilTextBox.Text = dosyasec.FileName;
        }

        private void gunlukSablonButon_Click(object sender, EventArgs e)
        {
            dosyasec.Title = "Şablon Seçin";
            dosyasec.InitialDirectory = @"C:\Program Files\Basak BOS v1.0\Templates\Template2";
            dosyasec.ShowDialog();
            gunlukTextBox.Text = dosyasec.FileName;
        }

        private void calistirmaSablonButon_Click(object sender, EventArgs e)
        {
            dosyasec.Title = "Şablon Seçin";
            dosyasec.InitialDirectory = @"C:\Program Files\Basak BOS v1.0\Templates\Template1";
            dosyasec.ShowDialog();
            calistirmaTextBox.Text = dosyasec.FileName;
        }

        private void yıllıkSablonButon_Click(object sender, EventArgs e)
        {
            dosyasec.Title = "Şablon Seçin";
            dosyasec.InitialDirectory = @"C:\Program Files\Basak BOS v1.0\Templates\Template3";
            dosyasec.ShowDialog();
            yillikTextBox.Text = dosyasec.FileName;
        }

        private void düzenleEkleButon_Click(object sender, EventArgs e)
        {
            if (grupAdıTextBox.Text=="" || sicilTextBox.Text=="" || calistirmaTextBox.Text=="" || gunlukTextBox.Text=="" || yillikTextBox.Text=="" || (semaCheckBox1.Checked && semaTextBox.Text==""))
            {
                MessageBox.Show("İşlem Gerçekleştirilemedi!\n\nHiçbir alan boş geçilemez!");
            }
            else
            {
                if (sistemAyarları.islem)//ekle
                {
                    if (semaCheckBox1.Checked) komut = new SqlCommand("INSERT INTO makinaGrupları VALUES ('" + grupAdıTextBox.Text + "','" + sicilTextBox.Text + "','" + calistirmaTextBox.Text + "','" + gunlukTextBox.Text + "','" + yillikTextBox.Text + "','" + semaTextBox.Text + "')", Giris.baglanti);
                    else komut = new SqlCommand("INSERT INTO makinaGrupları VALUES ('" + grupAdıTextBox.Text + "','" + sicilTextBox.Text + "','" + calistirmaTextBox.Text + "','" + gunlukTextBox.Text + "','" + yillikTextBox.Text + "',NULL)", Giris.baglanti);
                    Giris.baglanti.Open();
                    komut.ExecuteNonQuery();
                    Giris.baglanti.Close();
                    yenile = true;
                    MessageBox.Show("Grup başarıyla eklendi!");
                }
                else//düzenle
                {
                    Giris.baglanti.Open();
                    if (semaCheckBox1.Checked) komut.CommandText = "UPDATE makinaGrupları SET makinaGrubu='" + grupAdıTextBox.Text + "' , sicilSablonAdresi='" + sicilTextBox.Text + "' , calistirmaSablonAdresi='" + calistirmaTextBox.Text + "' , gunlukBakımSablonAdresi='" + gunlukTextBox.Text + "' , yillikBakımSablonAdresi='" + yillikTextBox.Text + "',Şema='" + semaTextBox.Text + "' where makinaGrubu='" + sistemAyarları.seciliGrup + "'";
                    else komut.CommandText = "UPDATE makinaGrupları SET makinaGrubu='" + grupAdıTextBox.Text + "' , sicilSablonAdresi='" + sicilTextBox.Text + "' , calistirmaSablonAdresi='" + calistirmaTextBox.Text + "' , gunlukBakımSablonAdresi='" + gunlukTextBox.Text + "' , yillikBakımSablonAdresi='" + yillikTextBox.Text + "', Şema = NULL where makinaGrubu='" + sistemAyarları.seciliGrup + "'";
                    komut.ExecuteNonQuery();
                    Giris.baglanti.Close();
                    yenile = true;
                    MessageBox.Show("Grup başarıyla güncellendi!");
                }
            }
        }

        private void grupYönetimi_FormClosing(object sender, FormClosingEventArgs e)
        {
            sistem.yenileButon.PerformClick();
        }

        private void semaCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (semaCheckBox1.Checked) { semaButon.Enabled = true; } else { semaTextBox.Clear(); semaButon.Enabled = false; }
        }

        private void semaButon_Click(object sender, EventArgs e)
        {
            dosyasec.Title = "Şablon Seçin";
            dosyasec.InitialDirectory = @"C:\Program Files\Basak BOS v1.0\Templates\Template2\Pictures";
            dosyasec.ShowDialog();
            semaTextBox.Text = dosyasec.FileName;
        }
    }
}