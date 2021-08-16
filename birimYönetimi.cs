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
    public partial class birimYönetimi : Form
    {
        SqlCommand komut;
        SqlDataReader dr;
        public static bool yenile = false;

        public birimYönetimi()
        {
            InitializeComponent();
        }

        private void birimYönetimi_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            if (sistemAyarları.islem == true)
            {
                baslikLabel.Text = "Birim Ekle";
                button1.Text = "Ekle";

                textBox1.Clear();
            }
            else
            {
                baslikLabel.Text = "Birim Düzenle";
                button1.Text = "Kaydet";

                komut = new SqlCommand("Select sicilSablonAdresi,calistirmaSablonAdresi,gunlukBakımSablonAdresi,yillikBakımSablonAdresi From makinaGrupları where makinaGrubu='" + sistemAyarları.seciliGrup + "'", Giris.baglanti);
                Giris.baglanti.Open();
                dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    textBox1.Text = sistemAyarları.seciliBirim;
                }
                dr.Close();
                Giris.baglanti.Close();
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("İşlem Gerçekleştirilemedi!\n\nBirim adı boş geçilemez!");
            }
            else
            {
                if (sistemAyarları.islem)//ekle
                {
                    komut = new SqlCommand("INSERT INTO birimListesi VALUES ('" + textBox1.Text + "')", Giris.baglanti);
                    Giris.baglanti.Open();
                    komut.ExecuteNonQuery();
                    Giris.baglanti.Close();
                    yenile = true;
                    MessageBox.Show("Birim başarıyla eklendi!");
                }
                else//düzenle
                {
                    Giris.baglanti.Open();
                    komut.CommandText = "UPDATE işGeçmişi SET Birim='" + textBox1.Text + "' where Birim='" + sistemAyarları.seciliBirim + "'";
                    komut.ExecuteNonQuery();
                    Giris.baglanti.Close();
                    Giris.baglanti.Open();
                    komut.CommandText = "UPDATE birimListesi SET birimler='" + textBox1.Text + "' where birimler='" + sistemAyarları.seciliBirim + "'";
                    komut.ExecuteNonQuery();
                    Giris.baglanti.Close();
                    yenile = true;
                    MessageBox.Show("Birim başarıyla güncellendi!");
                    this.Close();
                }
            }
        }
    }
}
