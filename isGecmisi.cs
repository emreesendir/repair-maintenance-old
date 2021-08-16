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
    public partial class isGecmisi : Form
    {
        SqlCommand komut;
        SqlDataReader dr;

        public static bool ekipmanAtölyeModu = false, tarihModu = false;
        public static string seciliEkipmanID = "";
        public static DateTime ilkTarih = DateTime.Today.AddDays(-10);
        public static DateTime sonTarih = DateTime.Today;
        public static List<string> atölyeler = new List<string>();
        public static List<string> filtreAtölyeler = new List<string>();
        public static List<string> türler = new List<string>();
        public static List<string> filtreTürler = new List<string>();

        List<string> bitişTarihi = new List<string>();
        List<string> ekipmanId = new List<string>();
        List<string> ekipmanKodu = new List<string>();
        List<string> birim = new List<string>();
        List<string> ekipmanAdı = new List<string>();
        List<string> istanımı = new List<string>();
        List<string> sorumlu = new List<string>();
        List<string> aciklama = new List<string>();
        List<string> talepeden = new List<string>();
        List<string> islemturu = new List<string>();
        List<string> baslangictarihi = new List<string>();

        public isGecmisi()
        {
            InitializeComponent();
        }

        private void isGecmisi_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            türler.Clear(); atölyeler.Clear(); filtreAtölyeler.Clear(); filtreTürler.Clear();

            komut = new SqlCommand("Select birimler From birimListesi", Giris.baglanti);
            Giris.baglanti.Open();
            dr = komut.ExecuteReader();
            while (dr.Read()) { atölyeler.Add(dr.GetString(0)); }
            dr.Close();
            Giris.baglanti.Close();

            komut = new SqlCommand("Select [İşlem Türü] From işGeçmişi Group By [İşlem Türü]", Giris.baglanti);
            Giris.baglanti.Open();
            dr = komut.ExecuteReader();
            while (dr.Read()) { türler.Add(dr.GetString(0)); }
            dr.Close();
            Giris.baglanti.Close();

            filtreTürler.AddRange(türler); filtreAtölyeler.AddRange(atölyeler);

            listViewYazici();
            if (Giris.yetki == "misafir") { yazdırButon.Enabled = false; }
        }

        public void listViewYazici()
        {
            bitişTarihi.Clear(); ekipmanId.Clear(); ekipmanKodu.Clear(); birim.Clear(); ekipmanAdı.Clear(); ekipmanAdı.Clear(); istanımı.Clear(); sorumlu.Clear(); aciklama.Clear(); talepeden.Clear(); islemturu.Clear(); baslangictarihi.Clear();

            gecmisListView.Clear();
            gecmisListView.View = View.Details;
            gecmisListView.FullRowSelect = true;
            gecmisListView.MultiSelect = false;
            gecmisListView.GridLines = true;
            gecmisListView.Columns.Add("Bitiş Tarihi", 100);
            gecmisListView.Columns.Add("Ekipman Kodu", 100);
            gecmisListView.Columns.Add("Birim", 80);
            gecmisListView.Columns.Add("Ekipman Adı", 300);
            gecmisListView.Columns.Add("İş Tanımı", 250);
            gecmisListView.Columns.Add("Sorumlusu", 100);
            gecmisListView.Columns.Add("Açıklama", 250);
            gecmisListView.Columns.Add("Talep Eden", 100);
            gecmisListView.Columns.Add("İşlem Türü", 100);
            gecmisListView.Columns.Add("Başlangıç Tarihi", 100);

            if (ekipmanAtölyeModu)
            {
                string komutMetni = "Select * From işGeçmişi where ";
                for (int i = 0; i < filtreTürler.Count; i++)
                {
                    if (i == 0 && filtreTürler.Count != 1) { komutMetni = komutMetni + "([İşlem Türü]='" + filtreTürler[i] + "' or "; }
                    else if (i == 0 && filtreTürler.Count == 1) { komutMetni = komutMetni + "[İşlem Türü]='" + filtreTürler[i] + "' and"; }
                    else if (i != filtreTürler.Count - 1) { komutMetni = komutMetni + "[İşlem Türü]='" + filtreTürler[i] + "' or "; }
                    else { komutMetni = komutMetni + "[İşlem Türü]='" + filtreTürler[i] + "') and"; }
                }
                if (tarihModu) { komut = new SqlCommand(komutMetni + " [Bitiş Tarihi]<='" + sonTarih.ToString("MM.dd.yyyy") + "' and [Bitiş Tarihi]>='" + ilkTarih.ToString("MM.dd.yyyy") + "' and [Ekipman ID]=" + seciliEkipmanID, Giris.baglanti); }
                else { komut = new SqlCommand(komutMetni + " [Ekipman ID]=" + seciliEkipmanID, Giris.baglanti); }
                Giris.baglanti.Open(); dr = komut.ExecuteReader();
                while (dr.Read()) { ekipmanId.Add(dr.GetInt32(6).ToString()); } Giris.baglanti.Close(); dr.Close();

                for (int i = 0; i < ekipmanId.Count; i++)
                {
                    komut = new SqlCommand("Select [Ekipman Kodu],Birim,Adı From makinaListesi where ID=" + ekipmanId[i], Giris.baglanti);
                    Giris.baglanti.Open(); dr = komut.ExecuteReader();
                    while (dr.Read()) { ekipmanKodu.Add(dr.GetString(0)); birim.Add(dr.GetString(1)); ekipmanAdı.Add(dr.GetString(2)); } Giris.baglanti.Close(); dr.Close();
                }

                if (tarihModu) { komut = new SqlCommand(komutMetni + "[Bitiş Tarihi]<='" + sonTarih.ToString("MM.dd.yyyy") + "' and [Bitiş Tarihi]>='" + ilkTarih.ToString("MM.dd.yyyy") + "' and [Ekipman ID]=" + seciliEkipmanID, Giris.baglanti); }
                else { komut = new SqlCommand(komutMetni + "[Ekipman ID]=" + seciliEkipmanID, Giris.baglanti); }
                Giris.baglanti.Open(); dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    istanımı.Add(dr.GetString(0));
                    sorumlu.Add(Convert.ToString(dr.GetString(2)));
                    aciklama.Add(Convert.ToString(dr.GetString(7)));
                    bitişTarihi.Add(dr.GetDateTime(4).ToString("d"));
                    talepeden.Add(Convert.ToString(dr.GetString(1)));
                    islemturu.Add(Convert.ToString(dr.GetString(5)));
                    baslangictarihi.Add(Convert.ToString(dr.GetDateTime(3).ToString("d")));
                }
                dr.Close(); Giris.baglanti.Close();
            }
            else
            {
                string komutMetni = "";
                if (!(filtreAtölyeler.Count == 0 && filtreTürler.Count == 0 && !tarihModu)) { komutMetni = "Select * From işGeçmişi Where "; }
                else { komutMetni = "Select * From işGeçmişi "; }
                for (int i = 0; i < filtreTürler.Count; i++)
                {
                    if (i == 0 && filtreTürler.Count != 1) { komutMetni = komutMetni + "([İşlem Türü]='" + filtreTürler[i] + "' or "; }
                    else if (i == 0 && filtreTürler.Count == 1) { komutMetni = komutMetni + "[İşlem Türü]='" + filtreTürler[i] + "' and"; }
                    else if (i != filtreTürler.Count - 1) { komutMetni = komutMetni + "[İşlem Türü]='" + filtreTürler[i] + "' or "; }
                    else { if (tarihModu || filtreAtölyeler.Count != 0) komutMetni = komutMetni + "[İşlem Türü]='" + filtreTürler[i] + "') and"; else komutMetni = komutMetni + "[İşlem Türü]='" + filtreTürler[i] + "')"; }
                }
                for (int i = 0; i < filtreAtölyeler.Count; i++)
			    {
                    if (i == 0 && filtreAtölyeler.Count != 1) { komutMetni = komutMetni + "(Birim='" + filtreAtölyeler[i] + "' or "; }
                    else if (i == 0 && filtreAtölyeler.Count == 1) { if (tarihModu) komutMetni = komutMetni + "Birim='" + filtreAtölyeler[i] + "' and"; else komutMetni = komutMetni + "Birim='" + filtreAtölyeler[i] + "'"; }
                    else if (i != filtreAtölyeler.Count - 1) { komutMetni = komutMetni + "Birim='" + filtreAtölyeler[i] + "' or "; }
                    else { if (tarihModu) { komutMetni = komutMetni + "Birim='" + filtreAtölyeler[i] + "') and"; } else { komutMetni = komutMetni + "Birim='" + filtreAtölyeler[i] + "')"; } }
			    }
                if (tarihModu) { komut = new SqlCommand(komutMetni + " [Bitiş Tarihi]<='" + sonTarih.ToString("MM.dd.yyyy") + "' and [Bitiş Tarihi]>='" + ilkTarih.ToString("MM.dd.yyyy") + "'", Giris.baglanti); }
                else { komut = new SqlCommand(komutMetni, Giris.baglanti); }
                Giris.baglanti.Open(); dr = komut.ExecuteReader();
                while (dr.Read()) { ekipmanId.Add(dr.GetInt32(6).ToString()); } Giris.baglanti.Close(); dr.Close();

                for (int i = 0; i < ekipmanId.Count; i++)
                {
                    komut = new SqlCommand("Select [Ekipman Kodu],Birim,Adı From makinaListesi where ID=" + ekipmanId[i], Giris.baglanti);
                    Giris.baglanti.Open(); dr = komut.ExecuteReader();
                    while (dr.Read()) { ekipmanKodu.Add(dr.GetString(0)); birim.Add(dr.GetString(1)); ekipmanAdı.Add(dr.GetString(2)); } Giris.baglanti.Close(); dr.Close();
                }

                if (tarihModu) { komut = new SqlCommand(komutMetni + "[Bitiş Tarihi]<='" + sonTarih.ToString("MM.dd.yyyy") + "' and [Bitiş Tarihi]>='" + ilkTarih.ToString("MM.dd.yyyy") + "'", Giris.baglanti); }
                else { komut = new SqlCommand(komutMetni, Giris.baglanti); }
                Giris.baglanti.Open(); dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    istanımı.Add(dr.GetString(0));
                    sorumlu.Add(Convert.ToString(dr.GetString(2)));
                    aciklama.Add(Convert.ToString(dr.GetString(7)));
                    bitişTarihi.Add(dr.GetDateTime(4).ToString("d"));
                    talepeden.Add(Convert.ToString(dr.GetString(1)));
                    islemturu.Add(Convert.ToString(dr.GetString(5)));
                    baslangictarihi.Add(Convert.ToString(dr.GetDateTime(3).ToString("d")));
                }
                dr.Close(); Giris.baglanti.Close();                
            }

            for (int i = 0; i < ekipmanId.Count; i++)
            {
                ListViewItem tablo1 = new ListViewItem(Convert.ToString(bitişTarihi[i]));
                tablo1.SubItems.Add(Convert.ToString(ekipmanKodu[i]));
                tablo1.SubItems.Add(Convert.ToString(birim[i]));
                tablo1.SubItems.Add(Convert.ToString(ekipmanAdı[i]));
                tablo1.SubItems.Add(Convert.ToString(istanımı[i]));
                tablo1.SubItems.Add(Convert.ToString(sorumlu[i]));
                tablo1.SubItems.Add(Convert.ToString(aciklama[i]));
                tablo1.SubItems.Add(Convert.ToString(talepeden[i]));
                tablo1.SubItems.Add(Convert.ToString(islemturu[i]));
                tablo1.SubItems.Add(Convert.ToString(baslangictarihi[i]));
                gecmisListView.Items.Add(tablo1);
            }
            gecmisListView.ListViewItemSorter = new ListViewItemComparer(0);
            gecmisListView.Sort();

            int j = 0;
            Color shaded = Color.FromArgb(240, 240, 240);
            foreach (ListViewItem item in gecmisListView.Items)
            {
                if (j++ % 2 == 0) { item.BackColor = Color.LightCyan; item.UseItemStyleForSubItems = true; }
                else { item.BackColor = Color.Aqua; item.UseItemStyleForSubItems = true; }
            }
        }

        class ListViewItemComparer : IComparer
        {
            private int col;
            public ListViewItemComparer()
            {
                col = 0;
            }
            public ListViewItemComparer(int column)
            {
                col = column;
            }
            public int Compare(object x, object y)
            {
                int returnVal;
                // Determine whether the type being compared is a date type.  
                try
                {
                    // Parse the two objects passed as a parameter as a DateTime.  
                    System.DateTime firstDate =
                            DateTime.Parse(((ListViewItem)y).SubItems[col].Text);
                    System.DateTime secondDate =
                            DateTime.Parse(((ListViewItem)x).SubItems[col].Text);
                    // Compare the two dates.  
                    returnVal = DateTime.Compare(firstDate, secondDate);
                }
                // If neither compared object has a valid date format, compare  
                // as a string.  
                catch
                {
                    // Compare the two items as a string.  
                    returnVal = String.Compare(((ListViewItem)y).SubItems[col].Text,
                                ((ListViewItem)x).SubItems[col].Text);
                }
                // Determine whether the sort order is descending. 
                return returnVal;
            }
        }

        private void isGecmisi_FormClosed(object sender, FormClosedEventArgs e)
        {
            anaMenu menu = new anaMenu();
            menu.Show();
        }

        private void anaMenuButon_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void listelemeButon_Click(object sender, EventArgs e)
        {
            while (true)
            {
                isGecmisiListeleme listele = new isGecmisiListeleme();
                DialogResult diar3 = listele.ShowDialog();
                if (diar3 == DialogResult.Yes) { if (isGecmisiListeleme.yenile) { listViewYazici(); break; } }
                else break;
            }
        }

        public void TextToWordTable(string pWordDoc)
        {
            Object oMissing = System.Reflection.Missing.Value;
            Object oTrue = true;
            Object oFalse = false;
            Microsoft.Office.Interop.Word.Application oWord = new Microsoft.Office.Interop.Word.Application();
            Microsoft.Office.Interop.Word.Document oWordDoc = new Microsoft.Office.Interop.Word.Document();
            Object oEndOfDoc = "\\endofdoc";
            oWord.Visible = false;
            Object oTemplatePath = pWordDoc;
            oWordDoc = oWord.Documents.Add(ref oTemplatePath, ref oMissing, ref oMissing, ref oMissing);

            //tablo oluşturma
            Microsoft.Office.Interop.Word.Table oTable;
            Microsoft.Office.Interop.Word.Range wrdRng = oWordDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            oTable = oWordDoc.Tables.Add(wrdRng, gecmisListView.Items.Count + 1, 8, ref oMissing, ref oMissing);
            Object style = "Tablo Kılavuzu";
            oTable.set_Style(ref style);
            oTable.LeftPadding = 0.3f; oTable.RightPadding = 0; oTable.TopPadding = 0.3f; oTable.BottomPadding = 0;

            //sütun genişlikleri
            for (int i = 1; i <= 8; i++)
            {
                switch (i)
                {
                    case 1: oTable.Columns[i].SetWidth(45, Microsoft.Office.Interop.Word.WdRulerStyle.wdAdjustNone); break;
                    case 2: oTable.Columns[i].SetWidth(45, Microsoft.Office.Interop.Word.WdRulerStyle.wdAdjustNone); break;
                    case 3: oTable.Columns[i].SetWidth(50, Microsoft.Office.Interop.Word.WdRulerStyle.wdAdjustNone); break;
                    case 4: oTable.Columns[i].SetWidth(100, Microsoft.Office.Interop.Word.WdRulerStyle.wdAdjustNone); break;
                    case 5: oTable.Columns[i].SetWidth(50, Microsoft.Office.Interop.Word.WdRulerStyle.wdAdjustNone); break;
                    case 6: oTable.Columns[i].SetWidth(50, Microsoft.Office.Interop.Word.WdRulerStyle.wdAdjustNone); break;
                    case 7: oTable.Columns[i].SetWidth(100, Microsoft.Office.Interop.Word.WdRulerStyle.wdAdjustNone); break;
                    case 8: oTable.Columns[i].SetWidth(100, Microsoft.Office.Interop.Word.WdRulerStyle.wdAdjustNone); break;
                }
            }
            //başlık kısımlarının biçimlendirilmesi doldurulması
            oTable.Rows.HeightRule = Microsoft.Office.Interop.Word.WdRowHeightRule.wdRowHeightAtLeast;
            oTable.Range.Font.Size = 8; oTable.Range.Font.Name = "Times New Romans"; oTable.Range.Font.Bold = 0;

            for (int i = 1; i <= 8; i++) { oTable.Cell(1, i).Range.Font.Size = 10; oTable.Cell(1, i).Range.Font.Name = "Times New Romans"; oTable.Cell(1, i).Range.Font.Bold = 1; }
            oTable.Cell(1, 1).Range.Text = "Başlangıç Tarihi"; oTable.Cell(1, 2).Range.Text = "Bitiş Tarihi"; oTable.Cell(1, 3).Range.Text = "Ekipman Kodu"; oTable.Cell(1, 4).Range.Text = "Ekipman Adı"; oTable.Cell(1, 5).Range.Text = "Atölye"; oTable.Cell(1, 6).Range.Text = "İşlem Türü"; oTable.Cell(1, 7).Range.Text = "İş Tanımı"; oTable.Cell(1, 8).Range.Text = "Açıklama";

            for (int i = 1; i <= 8; i++) { oTable.Cell(1, i).VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter; oTable.Cell(1, i).Range.Paragraphs.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter; }

            for (int i = 2; i <= gecmisListView.Items.Count + 1; i++)
            {
                oTable.Cell(i, 1).Range.Text = gecmisListView.Items[i - 2].SubItems[9].Text;
                oTable.Cell(i, 2).Range.Text = gecmisListView.Items[i - 2].SubItems[0].Text;
                oTable.Cell(i, 3).Range.Text = gecmisListView.Items[i - 2].SubItems[1].Text;
                oTable.Cell(i, 4).Range.Text = gecmisListView.Items[i - 2].SubItems[3].Text;
                oTable.Cell(i, 5).Range.Text = gecmisListView.Items[i - 2].SubItems[2].Text;
                oTable.Cell(i, 6).Range.Text = gecmisListView.Items[i - 2].SubItems[8].Text;
                oTable.Cell(i, 7).Range.Text = gecmisListView.Items[i - 2].SubItems[4].Text;
                oTable.Cell(i, 8).Range.Text = gecmisListView.Items[i - 2].SubItems[6].Text;
            }

            for (int i = 2; i <= gecmisListView.Items.Count + 1; i++) { for (int k = 1; k <= 8; k++) { oTable.Cell(i, k).VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter; oTable.Cell(i, k).Range.Paragraphs.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft; } }

            object EndPositon = 0;
            Microsoft.Office.Interop.Word.Range rngCrsr = oWordDoc.Range(ref EndPositon, ref EndPositon);
            rngCrsr.Select();
            oWordDoc.ActiveWindow.ActivePane.View.Type = Microsoft.Office.Interop.Word.WdViewType.wdPrintView;
            oWord.Visible = true;
        }

        private void yazdırButon_Click(object sender, EventArgs e)
        {
            TextToWordTable(@"C:\Program Files\Basak BOS v1.0\Templates\SysTemplates\isGecmisi.dotx");
            sistemAyarları.kayitEkle(Giris.kullanıcıAdı, "İş Geçmişi Yazdırıldı");
        }
    }
}
