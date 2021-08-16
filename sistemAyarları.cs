using System;
using System.IO;
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
    public partial class sistemAyarları : Form
    {
        SqlCommand komut;
        SqlDataReader dr;

        public static bool islem = false;
        public static string seciliGrup = "";
        public static string seciliBirim = "";
        public static string seciliKullanıcı = "";

        public sistemAyarları()
        {
            InitializeComponent();
        }

        private void sistemAyarları_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            
            listViewYazici();
            listBoxYazici();
            grupListBox.SelectedIndex = 0;
            birimListBox.SelectedIndex = 0;
        }

        public void listBoxYazici()
        {
            birimListBox.Items.Clear();
            komut = new SqlCommand("Select birimler from birimListesi", Giris.baglanti);
            Giris.baglanti.Open(); dr = komut.ExecuteReader();
            while (dr.Read()) { birimListBox.Items.Add(dr.GetString(0)); } dr.Close(); Giris.baglanti.Close();

            grupListBox.Items.Clear();
            komut = new SqlCommand("Select makinaGrubu from makinaGrupları", Giris.baglanti);
            Giris.baglanti.Open(); dr = komut.ExecuteReader();
            while (dr.Read()) { grupListBox.Items.Add(dr.GetString(0)); } dr.Close(); Giris.baglanti.Close();
        }

        public void listViewYazici()
        {
            kullanıcıListView.Clear();
            kullanıcıListView.View = View.Details;
            kullanıcıListView.FullRowSelect = true;
            kullanıcıListView.MultiSelect = false;
            kullanıcıListView.GridLines = true;
            kullanıcıListView.Columns.Add("K.Adı", 65);
            kullanıcıListView.Columns.Add("Şifre", 65);
            kullanıcıListView.Columns.Add("Yetki", 60);

            komut = new SqlCommand("Select kullanıcıAdı,sifre,yetki From kullanıcıListesi where kullanıcıAdı!='sa'", Giris.baglanti);
            Giris.baglanti.Open(); dr = komut.ExecuteReader();
            while (dr.Read())
            {
                ListViewItem tablo = new ListViewItem(dr.GetString(0));
                tablo.SubItems.Add(Convert.ToString(dr.GetString(1)));
                tablo.SubItems.Add(Convert.ToString(dr.GetString(2)));
                kullanıcıListView.Items.Add(tablo);
            }
            dr.Close(); Giris.baglanti.Close();
        }

        public void yenileButon_Click(object sender, EventArgs e)
        {
            listViewYazici();
            listBoxYazici();
            grupListBox.SelectedIndex = 0;
            birimListBox.SelectedIndex = 0;
        }

        private void anaMenuButon_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void sysLogButon_Click(object sender, EventArgs e)
        {
            try { System.Diagnostics.Process.Start("SysLog.txt"); }
            catch (Exception) { MessageBox.Show("'SysLog.txt' dosyası bulunamadı!"); }
        }

        private void yedeklemeButon_Click(object sender, EventArgs e)
        {
            yedekleme yedek = new yedekleme();
            yedek.ShowDialog();
        }

        private void grupDüzenleButon_Click(object sender, EventArgs e)
        {
            if (seciliGrup != "Belirtilmedi")
            {
                islem = false;
                while (true)
                {
                    grupYönetimi grupDuzenle = new grupYönetimi();
                    DialogResult diar0 = grupDuzenle.ShowDialog();
                    if (diar0 == DialogResult.Yes)
                    {
                        if (grupYönetimi.yenile) { yenileButon.PerformClick(); break; }
                    }
                    else break;
                }
            }
            else { MessageBox.Show("Belirtilmedi Grubu Düzenlenemez!"); }
        }

        private void grupEkleButon_Click(object sender, EventArgs e)
        {
            islem = true;
            while (true)
            {
                grupYönetimi grupDuzenle = new grupYönetimi();
                DialogResult diar1 = grupDuzenle.ShowDialog();
                if (diar1 == DialogResult.Yes)
                {
                    if (grupYönetimi.yenile) { yenileButon.PerformClick(); break; }
                }
                else break;
            }
        }

        private void grupListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                seciliGrup = grupListBox.SelectedItem.ToString();
            }
            catch (Exception)
            {
                grupListBox.SelectedIndex = 0;
            }
        }

        private void birimListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                seciliBirim = birimListBox.SelectedItem.ToString();
            }
            catch (Exception)
            {
                birimListBox.SelectedIndex = 0;
            }
        }

        private void grupSilButon_Click(object sender, EventArgs e)
        {
            DialogResult Secim = new DialogResult();

            Secim = MessageBox.Show("Grup Silmeyi Onaylıyor Musunuz?\n\nGruba kayıtlı makinalar 'Belirtilmedi' grubuna aktarılacaktır!", "Dikkat!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (Secim == DialogResult.Yes)
            {
                if (seciliGrup != "Belirtilmedi")
                {
                    Giris.baglanti.Open();
                    komut.CommandText = "UPDATE makinaListesi SET Grup='Belirtilmedi' where Grup='" + seciliGrup + "'";
                    komut.ExecuteNonQuery();
                    Giris.baglanti.Close();
                    Giris.baglanti.Open();
                    komut.CommandText = "DELETE makinaGrupları Where makinaGrubu='" + seciliGrup + "' ";
                    komut.ExecuteNonQuery();
                    Giris.baglanti.Close();
                    MessageBox.Show("Grup Silindi");
                    yenileButon.PerformClick();
                }
                else { MessageBox.Show("Belirtilmedi grubu silinemez!"); }
            }
        }

        private void sistemAyarları_FormClosed(object sender, FormClosedEventArgs e)
        {
            anaMenu menu = new anaMenu();
            menu.Show();
        }

        private void birimDüzenleButon_Click(object sender, EventArgs e)
        {
            if (seciliBirim != "Belirtilmedi")
            {
                islem = false;
                while (true)
                {
                    birimYönetimi birimDuzenle = new birimYönetimi();
                    DialogResult diar2 = birimDuzenle.ShowDialog();
                    if (diar2 == DialogResult.Yes)
                    {
                        if (birimYönetimi.yenile) { yenileButon.PerformClick(); break; }
                    }
                    else break;
                }
            }
            else { MessageBox.Show("Belirtilmedi Birimi Düzeltilemez!"); }
        }

        private void birimEkleButon_Click(object sender, EventArgs e)
        {
            islem = true;
            while (true)
            {
                birimYönetimi birimDuzenle = new birimYönetimi();
                DialogResult diar3 = birimDuzenle.ShowDialog();
                if (diar3 == DialogResult.Yes)
                {
                    if (birimYönetimi.yenile) { yenileButon.PerformClick(); break; }
                }
                else break;
            }
        }

        private void kullanıcıEkleButon_Click(object sender, EventArgs e)
        {
            islem = true;
            while (true)
            {
                kullanıcıYönetimi kullanıcıEkle = new kullanıcıYönetimi();
                DialogResult diar4 = kullanıcıEkle.ShowDialog();
                if (diar4 == DialogResult.Yes)
                {
                    if (kullanıcıYönetimi.yenile) { yenileButon.PerformClick(); break; }
                }
                else break;
            }
        }

        private void kullanıcıDüzenleButon_Click(object sender, EventArgs e)
        {
            if (seciliKullanıcı != "")
            {
                islem = false;
                while (true)
                {
                    kullanıcıYönetimi kullanıcıDuzenle = new kullanıcıYönetimi();
                    DialogResult diar5 = kullanıcıDuzenle.ShowDialog();
                    if (diar5 == DialogResult.Yes)
                    {
                        if (kullanıcıYönetimi.yenile) { yenileButon.PerformClick(); break; }
                    }
                    else break;
                }
            }
            else { MessageBox.Show("Kullanıcı Seçiniz"); }
        }

        private void kullanıcıListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            try { seciliKullanıcı = kullanıcıListView.FocusedItem.Text; }
            catch (Exception) { }
        }

        private void kullanıcıSilButon_Click(object sender, EventArgs e)
        {
            DialogResult Secim = new DialogResult();

            Secim = MessageBox.Show("Kullanıcıyı Silmeyi Onaylıyor Musunuz?", "Dikkat!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (Secim == DialogResult.Yes)
            {
                if (Giris.kullanıcıAdı != seciliKullanıcı && seciliKullanıcı != "sa")
                {
                    if (seciliKullanıcı != "")
                    {
                        Giris.baglanti.Open();
                        komut.CommandText = "DELETE kullanıcıListesi Where kullanıcıAdı='" + seciliKullanıcı + "'";
                        komut.ExecuteNonQuery();
                        Giris.baglanti.Close();
                        MessageBox.Show("Kullanıcı Silindi");
                        yenileButon.PerformClick();
                    }
                    else { MessageBox.Show("Kullanıcı Seçiniz!"); }
                }
                else { MessageBox.Show("Silme İşlemi Başarısız!\n\nŞunlara dikkat edin;\n* Aktif kullanıcı silinemez.\n* sa kullanıcısı silinemez."); }
            }
        }

        private void birimSilButon_Click(object sender, EventArgs e)
        {
            DialogResult Secim = new DialogResult();

            Secim = MessageBox.Show("Birimi Silmeyi Onaylıyor Musunuz?\n\nBirime kayıtlı ekipmanlar 'Belirtilmedi' birimine aktarılacaktır!", "Dikkat!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (Secim == DialogResult.Yes)
            {
                if (seciliBirim != "Belirtilmedi")
                {
                    Giris.baglanti.Open();
                    komut.CommandText = "UPDATE makinaListesi SET Birim='Belirtilmedi' where Birim='" + seciliBirim + "'";
                    komut.ExecuteNonQuery();
                    Giris.baglanti.Close();
                    Giris.baglanti.Open();
                    komut.CommandText = "UPDATE işGeçmişi SET Birim='Belirtilmedi' where Birim='" + seciliBirim + "'";
                    komut.ExecuteNonQuery();
                    Giris.baglanti.Close();
                    Giris.baglanti.Open();
                    komut.CommandText = "DELETE birimListesi Where birimler='" + seciliBirim + "' ";
                    komut.ExecuteNonQuery();
                    Giris.baglanti.Close();
                    MessageBox.Show("Birim Silindi");
                    yenileButon.PerformClick();
                }
                else { MessageBox.Show("Belirtilmedi Birimi Silinemez!"); }
            }
        }

        public static void kayitEkle(string kullanici,string islem)
        {

            string DosyaYolu = @"C:\Users\emre\Desktop\Başak BOS\WindowsFormsApplication1\bin\Debug" + "\\" + "SysLog" + ".txt";
            if (System.IO.File.Exists(DosyaYolu))
            {
                /*string fileName = "SysLog.txt";//http://stackoverflow.com/questions/16212127/add-a-new-line-at-a-specific-position-in-a-text-file
                List<string> txtLines = new List<string>();

                foreach (string str in File.ReadAllLines(fileName))
                {
                    txtLines.Add(str);
                }

                txtLines.Insert(2, DateTime.Now + "\t" + kullanici + "\t\t\t" + islem);
                using (File.Create(fileName)) { }
                foreach (string str in txtLines)
                {
                    File.AppendAllText(fileName, str + Environment.NewLine);
                }*/
                TextWriter tw = new StreamWriter("SysLog.txt", true);
                tw.WriteLine(DateTime.Now + "\t" + kullanici + "\t\t\t" + islem);
                tw.Close();
            }
            else
            {
                TextWriter tw = new StreamWriter("SysLog.txt");
                tw.WriteLine("Tarih\t\t\tKullanıcı\t\tİşlem");
                tw.WriteLine("------------------\t------------\t\t------------------");
                tw.WriteLine(DateTime.Now + "\t" + kullanici + "\t\t\t" + islem);
                tw.Close();
            }
        }
    }
}
