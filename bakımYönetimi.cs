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
    public partial class bakımYönetimi : Form
    {
        SqlCommand komut;
        SqlDataReader dr;

        public bakımYönetimi()
        {
            InitializeComponent();
        }

        private void bakımYönetimi_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            if (ekipmanDetay.islem == true) ekleDuzenleButon.Text = "Ekle";
            else
            {
                ekleDuzenleButon.Text = "Kaydet";
                int periyot = 0;
                komut = new SqlCommand("Select Yeri,Periyot,[Yer No],Kriter,Metod,[Araç ve Gereç],Tür From periyodikBakımListesi where bakımNo="+ekipmanDetay.seciliBakımNo, Giris.baglanti);
                Giris.baglanti.Open(); dr = komut.ExecuteReader();
                while (dr.Read()) { yeriTextBox.Text = dr.GetString(0); periyot = dr.GetInt32(1); yerNoTextBox.Text = dr.GetString(2); kriterTextBox.Text = dr.GetString(3); metodTextBox.Text = dr.GetString(4); aracTextBox.Text = dr.GetString(5); turComboBox.Text = dr.GetString(6); }
                dr.Close(); Giris.baglanti.Close();

                switch (periyot)
                {
                    case 1: periyotComboBox.Text = "G"; break;
                    case 7: periyotComboBox.Text = "H"; break;
                    case 30: periyotComboBox.Text = "A"; break;
                    case 90: periyotComboBox.Text = "3A"; break;
                    case 180: periyotComboBox.Text = "6A"; break;
                    case 360: periyotComboBox.Text = "Y"; break;
                }
            }

            komut = new SqlCommand("Select ISNULL(Şema,'NULL') From makinaGrupları where makinaGrubu='" + ekipmanDetay.seciligrup + "'", Giris.baglanti);
            Giris.baglanti.Open(); dr = komut.ExecuteReader();
            while (dr.Read()) { if (dr.GetString(0) == "NULL") {  yerNoTextBox.Enabled = false; yerNoTextBox.Text = "0"; } } dr.Close(); Giris.baglanti.Close();
        }

        private void ekleDuzenleButon_Click(object sender, EventArgs e)
        {
            /*int result = 0;
            bool periyot = Int32.TryParse(periyotTextBox.Text, out result);*/
            if (yeriTextBox.Text == "" || periyotComboBox.Text == "Seçiniz" || yerNoTextBox.Text == "" || kriterTextBox.Text == "" || metodTextBox.Text == "" || aracTextBox.Text == "" || turComboBox.Text == "Seçiniz") MessageBox.Show("İşlem Gerçekleştirilemedi!\n\n* Hiçbir alan boş geçilemez!\n* Bakım Periyodu alanına sadece pozitif tamsayı yazılabilir.");
            else
            {
                string periyot = "";
                switch (periyotComboBox.Text)
                {
                    case "G": periyot = "1"; break;
                    case "H": periyot = "7"; break;
                    case "A": periyot = "30"; break;
                    case "3A": periyot = "90"; break;
                    case "6A": periyot = "180"; break;
                    case "Y": periyot = "360"; break;
                }
                if (ekipmanDetay.islem)
                {
                    komut = new SqlCommand("INSERT INTO periyodikBakımListesi (ID,Yeri,Periyot,sonBakımTarihi,birSonrakiBakımTarihi,Kriter,Metod,[Araç ve Gereç],Tür,[Yer No]) VALUES (" + makinaListesi.seciliID + ",'" + yeriTextBox.Text + "'," + periyot + ",NULL,NULL,'" + kriterTextBox.Text + "','" + metodTextBox.Text + "','" + aracTextBox.Text + "','" + turComboBox.Text + "','" + yerNoTextBox.Text + "')", Giris.baglanti);
                    Giris.baglanti.Open();
                    komut.ExecuteNonQuery();
                    Giris.baglanti.Close();
                    MessageBox.Show("Bakım başarıyla eklendi!");
                    sistemAyarları.kayitEkle(Giris.kullanıcıAdı, "Periyodik Bakım Eklendi [Ekipman ID]: " + makinaListesi.seciliID);
                }
                else
                {
                    Giris.baglanti.Open();
                    komut.CommandText = "UPDATE periyodikBakımListesi SET Yeri='" + yeriTextBox.Text + "' , Periyot=" + periyot + ", [Yer No]='" + yerNoTextBox.Text + "', Kriter='" + kriterTextBox.Text + "', Metod='" + metodTextBox.Text + "', [Araç ve Gereç]='" + aracTextBox.Text + "', Tür='" + turComboBox.Text + "' where bakımNo=" + ekipmanDetay.seciliBakımNo;
                    komut.ExecuteNonQuery();
                    Giris.baglanti.Close();
                    MessageBox.Show("Bakım başarıyla güncellendi!");
                    sistemAyarları.kayitEkle(Giris.kullanıcıAdı, "Periyodik Bakım Düzenlendi [Ekipman ID]: " + makinaListesi.seciliID);
                    this.Close();
                }
            }
        }

        private void turComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (turComboBox.Text)
            {
                case "Temizlik": yeriLabel.Text = "Yeri"; metodLabel.Text = "Metod"; aracLabel.Text = "Araç ve Gereç"; break;
                case "Yağlama": yeriLabel.Text = "Yağlama Noktaları"; metodLabel.Text = "Yağ Tipi"; aracLabel.Text = "Araç ve Gereç"; break;
                case "Kontrol": yeriLabel.Text = "Yeri"; metodLabel.Text = "Metod"; aracLabel.Text = "Operasyonlar"; break;
            }
        }
    }
}