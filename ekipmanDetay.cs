using System;
using System.Collections;
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
    public partial class ekipmanDetay : Form
    {
        SqlCommand komut;
        SqlDataReader dr;
        List<DateTime> dt = new List<DateTime>();

        public static string seciliBakımNo = "";
        public static bool islem = false;
        public static string secilimarka = "";
        public static string secilimodel = "";
        public static string seciliNo = "";
        public static string seciliadı = "";
        public static string seciligrup = "";
                
        public ekipmanDetay()
        {
            InitializeComponent();
        }

        private void ekipmanDetay_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            listViewYazici();

            bilgiYazici();
            bilgiKaydetButon.Visible = false;
            bilgiIptalButon.Visible = false;
            ekipmanBilgiPaneli.Enabled = false;
            seciligrup = grupComboBox.Text;
        }

        private void bilgiYazici()
        {
            birimComboBox.Items.Clear();
            grupComboBox.Items.Clear();
            for (int i = 0; i < makinaListesi.birimler.Count; i++) { birimComboBox.Items.Add(makinaListesi.birimler[i]); }
            for (int i = 0; i < makinaListesi.gruplar.Count; i++) { grupComboBox.Items.Add(makinaListesi.gruplar[i]); }

            komut = new SqlCommand("Select [Ekipman Kodu],Birim,Grup,Adı,ISNULL(SeriNo,'Belirtilmedi'),ISNULL(Model,'Belirtilmedi'),ISNULL(İmalTarihi,'Belirtilmedi'),ISNULL(Marka,'Belirtilmedi') From makinaListesi Where ID=" + makinaListesi.seciliID, Giris.baglanti);
            Giris.baglanti.Open(); dr = komut.ExecuteReader();
            while (dr.Read())
            {
                ekipmanKoduTextBox.Text = dr.GetString(0);
                birimComboBox.Text = dr.GetString(1);
                grupComboBox.Text = dr.GetString(2);
                ekipmanAdıTextBox.Text = dr.GetString(3);
                seriNoTextBox.Text = dr.GetString(4);
                modelTextBox.Text = dr.GetString(5);
                imalTarihiTextBox.Text = dr.GetString(6);
                markaTextBox.Text = dr.GetString(7);
            }
            dr.Close(); Giris.baglanti.Close();
        }

        public void listViewYazici()
        {
            bakımListView.Clear();
            bakımListView.View = View.Details;
            bakımListView.FullRowSelect = true;
            bakımListView.MultiSelect = false;
            bakımListView.GridLines = true;
            bakımListView.Columns.Add("B.No", 40);
            bakımListView.Columns.Add("YerNo", 50);
            bakımListView.Columns.Add("Yeri", 240);
            bakımListView.Columns.Add("Kriter", 240);
            bakımListView.Columns.Add("Metod/Yağ Tipi", 240);
            bakımListView.Columns.Add("Araç ve Gereç/Operasyon", 240);
            bakımListView.Columns.Add("Tür", 80);
            bakımListView.Columns.Add("Pryt.", 50);
            if (bakımcıRadioButon.Checked) bakımListView.Columns.Add("Son Bakım", 80);

            if (bakımcıRadioButon.Checked) komut = new SqlCommand("Select bakımNo,[Yer No],Yeri,Kriter,Metod,[Araç ve Gereç],Tür,Periyot,ISNULL(sonBakımTarihi,'2000-01-01') From periyodikBakımListesi Where ID=" + makinaListesi.seciliID + " and Periyot>=30 Order By Tür ASC, Periyot ASC", Giris.baglanti);
            else komut = new SqlCommand("Select bakımNo,[Yer No],Yeri,Kriter,Metod,[Araç ve Gereç],Tür,Periyot From periyodikBakımListesi Where ID=" + makinaListesi.seciliID + " and Periyot<=7 Order By Tür ASC, Periyot ASC", Giris.baglanti);
            Giris.baglanti.Open(); dr = komut.ExecuteReader();
            while (dr.Read())
            {
                ListViewItem tablo = new ListViewItem(dr.GetInt32(0).ToString());
                tablo.SubItems.Add(Convert.ToString(dr.GetString(1)));
                tablo.SubItems.Add(Convert.ToString(dr.GetString(2)));
                tablo.SubItems.Add(Convert.ToString(dr.GetString(3)));
                tablo.SubItems.Add(Convert.ToString(dr.GetString(4)));
                tablo.SubItems.Add(Convert.ToString(dr.GetString(5)));
                tablo.SubItems.Add(Convert.ToString(dr.GetString(6)));
                tablo.SubItems.Add(Convert.ToString(dr.GetInt32(7)).ToString());
                if(bakımcıRadioButon.Checked) tablo.SubItems.Add(dr.GetDateTime(8).ToString("d"));
                bakımListView.Items.Add(tablo);
            }
            dr.Close(); Giris.baglanti.Close();
            for (int i = 0; i < bakımListView.Items.Count; i++)
            {
                switch (bakımListView.Items[i].SubItems[7].Text)
                {
                    case "1": bakımListView.Items[i].SubItems[7].Text = "G"; break;
                    case "7": bakımListView.Items[i].SubItems[7].Text = "H"; break;
                    case "30": bakımListView.Items[i].SubItems[7].Text = "A"; break;
                    case "90": bakımListView.Items[i].SubItems[7].Text = "3A"; break;
                    case "180": bakımListView.Items[i].SubItems[7].Text = "6A"; break;
                    case "360": bakımListView.Items[i].SubItems[7].Text = "Y"; break;
                }
            }
        }

        private void bakımDüzenleButon_Click(object sender, EventArgs e)
        {
            if (seciliBakımNo != "")
            {
                islem = false;
                while (true)
                {
                    bakımYönetimi bakımDuzenle = new bakımYönetimi();
                    DialogResult diar = bakımDuzenle.ShowDialog();
                    if (diar == DialogResult.Yes) { listViewYazici(); break; }
                    else break;
                }
            }
            else { MessageBox.Show("Bakım Seçiniz"); }
        }

        private void bakımEkleButon_Click(object sender, EventArgs e)
        {
            islem = true;
            while (true)
            {
                bakımYönetimi bakımEkle = new bakımYönetimi();
                DialogResult diar2 = bakımEkle.ShowDialog();
                if (diar2 == DialogResult.Yes) { listViewYazici(); break; }
                else break;
            }
        }

        private void bakımListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            try { seciliBakımNo = bakımListView.FocusedItem.Text; }
            catch (Exception) { seciliBakımNo = ""; }
        }

        private void bakımSilButon_Click(object sender, EventArgs e)
        {
            DialogResult Secim = new DialogResult();

            Secim = MessageBox.Show("Silme İşlemini Onaylıyor Musunuz?", "Dikkat!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (Secim == DialogResult.Yes)
            {
                if (seciliBakımNo != "")
                {
                    Giris.baglanti.Open();
                    komut.CommandText = "DELETE periyodikBakımListesi Where bakımNo=" + seciliBakımNo;
                    komut.ExecuteNonQuery();
                    Giris.baglanti.Close();
                    MessageBox.Show("Bakım Silindi");
                    sistemAyarları.kayitEkle(Giris.kullanıcıAdı, "Periyodik Bakım Silindi [Ekipman ID]: " + makinaListesi.seciliID);
                    listViewYazici();
                }
                else { MessageBox.Show("Bakım Seçiniz!"); }
            }
        }

        private void bilgiKaydetButon_Click(object sender, EventArgs e)
        {
            if (ekipmanKoduTextBox.Text == "" || ekipmanAdıTextBox.Text == "")
            {
                MessageBox.Show("İşlem Gerçekleştirilemedi!\n\n* Hiçbir alan boş geçilemez!");
            }
            else
            {
                try
                {
                    string komutMetni = "UPDATE makinaListesi SET [Ekipman Kodu]='" + ekipmanKoduTextBox.Text + "' , Birim='" + birimComboBox.Text + "' , Grup='" + grupComboBox.Text + "' , Adı='" + ekipmanAdıTextBox.Text + "',";
                    if (seriNoTextBox.Text == "" || seriNoTextBox.Text == "Belirtilmedi") { komutMetni = komutMetni + " SeriNo = NULL , "; } else { komutMetni = komutMetni + "SeriNo='" + seriNoTextBox.Text + "',"; }
                    if (modelTextBox.Text == "" || modelTextBox.Text == "Belirtilmedi") { komutMetni = komutMetni + " Model = NULL , "; } else { komutMetni = komutMetni + "Model='" + modelTextBox.Text + "',"; }
                    if (markaTextBox.Text == "" || markaTextBox.Text == "Belirtilmedi") { komutMetni = komutMetni + " Marka = NULL , "; } else { komutMetni = komutMetni + "Marka='" + markaTextBox.Text + "',"; }
                    if (imalTarihiTextBox.Text == "" || imalTarihiTextBox.Text == "Belirtilmedi") { komutMetni = komutMetni + " İmalTarihi = NULL "; } else { komutMetni = komutMetni + "İmalTarihi='" + imalTarihiTextBox.Text + "'"; }
                    Giris.baglanti.Open();
                    komut.CommandText = komutMetni + "where ID=" + makinaListesi.seciliID;
                    komut.ExecuteNonQuery();
                    Giris.baglanti.Close();
                    sistemAyarları.kayitEkle(Giris.kullanıcıAdı, "Ekipman Bilgileri Düzenlendi [Ekpman ID]: " + makinaListesi.seciliID);
                }
                catch (Exception) { MessageBox.Show("İşlem gerçekleştrilemedi!\nAynı ekipman kodu birden fazla ekipmana verilemez!"); dr.Close(); Giris.baglanti.Close(); }
            }
            bilgiYazici();
            bilgiKaydetButon.Visible = false;
            bilgiIptalButon.Visible = false;
            ekipmanBilgiPaneli.Enabled = false;
        }

        private void bilgiDuzenleButon_Click(object sender, EventArgs e)
        {
            ekipmanBilgiPaneli.Enabled = true;
            bilgiKaydetButon.Visible = true;
            bilgiIptalButon.Visible = true;
        }

        private void bilgiIptalButon_Click(object sender, EventArgs e)
        {
            bilgiYazici();
            bilgiKaydetButon.Visible = false;
            bilgiIptalButon.Visible = false;
            ekipmanBilgiPaneli.Enabled = false;
        }

        private void makinaSilButon_Click(object sender, EventArgs e)
        {
            DialogResult Secim = new DialogResult();
            Secim = MessageBox.Show("Ekipmanı Silmeyi Onaylıyor Musunuz?\nEkipmanla birlikte ekipmana kayıtlı tüm işlem ve bakımlarda silinir!\nSilmek yerine başka bir birime aktarma yapılabilir.", "Dikkat!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (Secim == DialogResult.Yes)
            {
                Giris.baglanti.Open();
                komut.CommandText = "DELETE makinaListesi Where ID=" + makinaListesi.seciliID;
                komut.ExecuteNonQuery();
                Giris.baglanti.Close();
                MessageBox.Show("EkipmanSilindi");
                sistemAyarları.kayitEkle(Giris.kullanıcıAdı, "Ekipman Silindi [Ekipman ID]: " + makinaListesi.seciliID);
                this.Close();
            }
        }

        private void dokumanButon_Click(object sender, EventArgs e)
        {
            seciliadı = ekipmanAdıTextBox.Text; secilimarka = markaTextBox.Text; secilimodel = modelTextBox.Text; seciliNo = seriNoTextBox.Text;
            ciktiAl dokuman = new ciktiAl();
            dokuman.ShowDialog();
        }

        private void yazdirButon_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bu Bölüm Geliştirme Aşamasındadır!");
        }

        private void bakımcıRadioButon_CheckedChanged(object sender, EventArgs e)
        {
            listViewYazici();
        }

        private void grupComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            seciligrup = grupComboBox.Text;
        }

        private void ekipmanDetay_FormClosing(object sender, FormClosingEventArgs e)
        {
            yesButon.PerformClick();
        }
    }
}
