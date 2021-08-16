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
    public partial class makinaListesi : Form
    {
        static SqlCommand komut;
        static SqlDataReader dr;

        public static string seciliID = "";

        public static List<string> birimler = new List<string>();
        public static List<string> gruplar = new List<string>();
        public static List<string> kolonlar = new List<string>();

        public static List<string> filtreBirimler =new List<string>();
        public static List<string> filtreGruplar = new List<string>();
        public static List<string> filtreKolonlar = new List<string>();
        public static List<string> filtreTur = new List<string>();

        public makinaListesi()
        {
            InitializeComponent();
        }

        private void makinaListesi_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            birimler.Clear(); gruplar.Clear(); kolonlar.Clear(); filtreBirimler.Clear(); filtreGruplar.Clear(); filtreKolonlar.Clear();

            komut = new SqlCommand("Select birimler From birimListesi", Giris.baglanti);
            Giris.baglanti.Open();
            dr = komut.ExecuteReader();
            while (dr.Read()) { birimler.Add(dr.GetString(0)); }
            dr.Close();
            Giris.baglanti.Close();

            komut = new SqlCommand("SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME='makinaListesi'", Giris.baglanti);
            Giris.baglanti.Open();
            dr = komut.ExecuteReader();
            while (dr.Read()) { kolonlar.Add(dr.GetString(0)); }
            dr.Close();
            Giris.baglanti.Close();

            komut = new SqlCommand("Select makinaGrubu From makinaGrupları", Giris.baglanti);
            Giris.baglanti.Open();
            dr = komut.ExecuteReader();
            while (dr.Read()) { gruplar.Add(dr.GetString(0)); }
            dr.Close();
            Giris.baglanti.Close();

            filtreBirimler.AddRange(birimler); filtreGruplar.AddRange(gruplar); filtreKolonlar.AddRange(kolonlar);

            yenileButon.PerformClick();
            if (Giris.yetki == "misafir") { detayButon.Enabled = false; ekleButon.Enabled = false; yazdırButon.Enabled = false; }
        }

        public void listViewYazici()
        {
            string komutMetni = "Select ";
            makinaListView.Clear();
            makinaListView.View = View.Details;
            makinaListView.FullRowSelect = true;
            makinaListView.MultiSelect = false;
            makinaListView.GridLines = true;
            for (int i = 0; i < filtreKolonlar.Count; i++)
            {
                int genislik = 0;
                komut = new SqlCommand("Select kolonGenişliği From kolonBilgileri Where kolonAdı='"+ filtreKolonlar[i] +"'", Giris.baglanti);
                Giris.baglanti.Open(); dr = komut.ExecuteReader();
                while (dr.Read()) { genislik=dr.GetInt32(0); } dr.Close(); Giris.baglanti.Close();
                makinaListView.Columns.Add(filtreKolonlar[i],genislik);
                if (i != (filtreKolonlar.Count - 1)) { if (filtreKolonlar[i] == "SeriNo" || filtreKolonlar[i] == "Model" || filtreKolonlar[i] == "İmalTarihi" || filtreKolonlar[i] == "Marka") { komutMetni = komutMetni + "ISNULL([" + filtreKolonlar[i] + "],'Belirtilmedi')" + ","; } else { komutMetni = komutMetni + "[" + filtreKolonlar[i] + "]" + ","; } }
                else { if (filtreKolonlar[i] == "SeriNo" || filtreKolonlar[i] == "Model" || filtreKolonlar[i] == "İmalTarihi" || filtreKolonlar[i] == "Marka") { komutMetni = komutMetni + "ISNULL([" + filtreKolonlar[i] + "],'Belirtilmedi')"; } else { komutMetni = komutMetni + "[" + filtreKolonlar[i] + "]"; } }
            }
            komutMetni = komutMetni + " From makinaListesi Where (";
            for (int i = 0; i < filtreBirimler.Count; i++)
            {
                if(i != (filtreBirimler.Count-1)) { komutMetni = komutMetni + "Birim='" + filtreBirimler[i] + "' or "; }
                else { komutMetni = komutMetni + "Birim='" + filtreBirimler[i] + "')"; }
            }
            komutMetni = komutMetni + " and (";
            for (int i = 0; i < filtreGruplar.Count; i++)
            {
                if(i != (filtreGruplar.Count-1)) { komutMetni = komutMetni + "Grup='" + filtreGruplar[i] + "' or "; }
                else { komutMetni = komutMetni + "Grup='" + filtreGruplar[i] + "')"; }
            }
            filtreTur.Clear();
            for (int i = 0; i < filtreKolonlar.Count; i++)
            {
                komut = new SqlCommand("Select değişkenTürü From kolonBilgileri Where kolonAdı='" + filtreKolonlar[i] + "'", Giris.baglanti);
                Giris.baglanti.Open(); dr = komut.ExecuteReader();
                while (dr.Read()) { filtreTur.Add(dr.GetString(0)); } dr.Close(); Giris.baglanti.Close();
            }

            komut = new SqlCommand(komutMetni, Giris.baglanti);
            try
            {
                Giris.baglanti.Open(); dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    ListViewItem tablo = new ListViewItem(Convert.ToString(dr.GetInt32(0)));
                    for (int i = 1; i < filtreKolonlar.Count; i++)
                    {
                        if (filtreTur[i] == "int") { tablo.SubItems.Add(Convert.ToString(dr.GetInt32(i))); }
                        else if (filtreTur[i] == "string") { tablo.SubItems.Add(Convert.ToString(dr.GetString(i))); }
                    }
                    makinaListView.Items.Add(tablo);
                }
                dr.Close(); Giris.baglanti.Close();
            }
            catch (Exception) { dr.Close(); Giris.baglanti.Close(); }
            
            makinaListView.ListViewItemSorter = new ListViewItemComparer(1);
            makinaListView.Sort();
        }

        private void makinaListesi_FormClosed(object sender, FormClosedEventArgs e)
        {
            anaMenu menu = new anaMenu();
            menu.Show();
        }

        private void yenileButon_Click(object sender, EventArgs e)
        {
            listViewYazici();
        }

        private void filtereButon_Click(object sender, EventArgs e)
        {
            while (true)
            {
                filtrelemeSeçenekleri filtrele = new filtrelemeSeçenekleri();
                DialogResult diar = filtrele.ShowDialog();
                if (diar == DialogResult.Yes)
                {
                    yenileButon.PerformClick(); break;
                }
                else break;
            }
        }

        private void anaMenuButon_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void detayButon_Click(object sender, EventArgs e)
        {
            if (seciliID != "")
            {
                sistemAyarları.kayitEkle(Giris.kullanıcıAdı, "Ekipman Detayları Görüntülendi [Ekipman ID]: " + seciliID);
                while (true)
                {
                    ekipmanDetay detay = new ekipmanDetay();
                    DialogResult diar2 = detay.ShowDialog();
                    if (diar2 == DialogResult.Yes)
                    {
                        yenileButon.PerformClick(); break;
                    }
                    else break;
                }
            }
            else { MessageBox.Show("Ekipman Seçiniz!"); }
        }

        private void makinaListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            try { seciliID = makinaListView.FocusedItem.Text; }
            catch (Exception) { }
        }

        private void ekleButon_Click(object sender, EventArgs e)
        {
            while (true)
            {
                ekipmanEkle ekle = new ekipmanEkle();
                DialogResult diar3 = ekle.ShowDialog();
                if (diar3 == DialogResult.Yes)
                {
                    if (ekipmanEkle.yenile) { yenileButon.PerformClick(); break; }
                }
                else break;
            }
        }
        /*
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            if (sayfaNo == 1)
            {
                int satırsayısı = makinaListView.Items.Count;
                while (true)
                {
                    satırsayısı = satırsayısı - 33;
                    if (satırsayısı <= 0) break;
                    else sayfaSayisi++;
                }
            }
            Font myFont1 = new Font("Calibri", 10, FontStyle.Italic);
            SolidBrush sbrush1 = new SolidBrush(Color.Black);
            Pen myPen1 = new Pen(Color.Black);

            e.Graphics.DrawString("Başak Bakım Onarım Sistemi", myFont1, sbrush1, 69, 40);
            e.Graphics.DrawString("Sayfa: " + sayfaNo.ToString() + "/" + sayfaSayisi.ToString(), myFont1, sbrush1, 900, 40);
            e.Graphics.DrawString("Tarih: " + DateTime.Today.ToString("d"), myFont1, sbrush1, 1010, 40);

            Font myFont = new Font("Calibri", 28, FontStyle.Bold);
            SolidBrush sbrush = new SolidBrush(Color.Black);
            Pen myPen = new Pen(Color.Black);
            e.Graphics.DrawString("EKiPMAN LİSTESİ", myFont, sbrush, 450, 20);

            myFont = new Font("Calibri", 12, FontStyle.Bold);
            e.Graphics.DrawString("Ekipman Kodu", myFont, sbrush, 70, 80);
            e.Graphics.DrawString("Atölye", myFont, sbrush, 200 , 80);
            e.Graphics.DrawString("Grup", myFont, sbrush, 330, 80);
            e.Graphics.DrawString("Ekipman Adı", myFont, sbrush, 460, 80);
            e.Graphics.DrawString("Seri No", myFont, sbrush, 860, 80);
            e.Graphics.DrawString("İmal Tarihi", myFont, sbrush, 985, 80);

            e.Graphics.DrawLine(myPen, 70, 100, 1115, 100);
            e.Graphics.DrawLine(myPen, 200, 80, 200, 760);
            e.Graphics.DrawLine(myPen, 330, 80, 330, 760);
            e.Graphics.DrawLine(myPen, 460, 80, 460, 760);
            e.Graphics.DrawLine(myPen, 860, 80, 860, 760);
            e.Graphics.DrawLine(myPen, 985, 80, 985, 760);
            e.Graphics.DrawLine(myPen, 70, 80, 70, 760);
            e.Graphics.DrawLine(myPen, 70, 80, 1115, 80);
            e.Graphics.DrawLine(myPen, 70, 760, 1115, 760);
            e.Graphics.DrawLine(myPen, 1115, 80, 1115, 760);

            for (int i = 0; i < 33; i++)
            {
                e.Graphics.DrawLine(myPen, 70, 100 + (i * 20), 1115, 100 + (i * 20));
            }

            myFont = new Font("Calibri", 12);
            int y = 100;
            foreach (ListViewItem lvi in makinaListView.Items)
            {
                e.Graphics.DrawString(lvi.SubItems[3].Text, myFont, sbrush, 70, y);
                e.Graphics.DrawString(lvi.SubItems[1].Text, myFont, sbrush, 200, y);
                e.Graphics.DrawString(lvi.SubItems[2].Text, myFont, sbrush, 330, y);
                e.Graphics.DrawString(lvi.SubItems[4].Text, myFont, sbrush, 460, y);
                e.Graphics.DrawString(lvi.SubItems[5].Text, myFont, sbrush, 860, y);
                e.Graphics.DrawString(lvi.SubItems[6].Text, myFont, sbrush, 985, y);

                y += 20;

            }
            sayfaNo++;
            if (sayfaNo <= sayfaSayisi) e.HasMorePages = true;
            else { e.HasMorePages = false; sayfaNo = 1; sayfaSayisi = 1; }
        }
        */
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
                int returnVal = -1;
                returnVal = String.Compare(((ListViewItem)x).SubItems[col].Text,
                ((ListViewItem)y).SubItems[col].Text);
                return returnVal;
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
            oTable = oWordDoc.Tables.Add(wrdRng, makinaListView.Items.Count + 1, 8, ref oMissing, ref oMissing);
            Object style = "Tablo Kılavuzu";
            oTable.set_Style(ref style);
            oTable.LeftPadding = 0.3f; oTable.RightPadding = 0; oTable.TopPadding = 0.3f; oTable.BottomPadding = 0;

            //sütun genişlikleri
            for (int i = 1; i <= 8; i++)
            {
                switch (i)
                {
                    case 1: oTable.Columns[i].SetWidth(50, Microsoft.Office.Interop.Word.WdRulerStyle.wdAdjustNone); break;
                    case 2: oTable.Columns[i].SetWidth(150, Microsoft.Office.Interop.Word.WdRulerStyle.wdAdjustNone); break;
                    case 3: oTable.Columns[i].SetWidth(80, Microsoft.Office.Interop.Word.WdRulerStyle.wdAdjustNone); break;
                    case 4: oTable.Columns[i].SetWidth(60, Microsoft.Office.Interop.Word.WdRulerStyle.wdAdjustNone); break;
                    case 5: oTable.Columns[i].SetWidth(50, Microsoft.Office.Interop.Word.WdRulerStyle.wdAdjustNone); break;
                    case 6: oTable.Columns[i].SetWidth(50, Microsoft.Office.Interop.Word.WdRulerStyle.wdAdjustNone); break;
                    case 7: oTable.Columns[i].SetWidth(50, Microsoft.Office.Interop.Word.WdRulerStyle.wdAdjustNone); break;
                    case 8: oTable.Columns[i].SetWidth(50, Microsoft.Office.Interop.Word.WdRulerStyle.wdAdjustNone); break;
                }
            }
            //başlık kısımlarının biçimlendirilmesi doldurulması
            oTable.Rows.HeightRule = Microsoft.Office.Interop.Word.WdRowHeightRule.wdRowHeightAtLeast;
            oTable.Range.Font.Size = 8; oTable.Range.Font.Name = "Times New Romans"; oTable.Range.Font.Bold = 0;

            for (int i = 1; i <= 8; i++) { oTable.Cell(1, i).Range.Font.Size = 10; oTable.Cell(1, i).Range.Font.Name = "Times New Romans"; oTable.Cell(1, i).Range.Font.Bold = 1; }
            oTable.Cell(1, 1).Range.Text = "Ekipman Kodu"; oTable.Cell(1, 2).Range.Text = "Ekipman Adı"; oTable.Cell(1, 3).Range.Text = "Tanım"; oTable.Cell(1, 4).Range.Text = "Atölye"; oTable.Cell(1, 5).Range.Text = "Marka"; oTable.Cell(1, 6).Range.Text = "Model"; oTable.Cell(1, 7).Range.Text = "Seri No"; oTable.Cell(1, 8).Range.Text = "İmal Tarihi";

            for (int i = 1; i <= 8; i++) { oTable.Cell(1, i).VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter; oTable.Cell(1, i).Range.Paragraphs.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter; }

            for (int i = 2; i <= makinaListView.Items.Count + 1; i++)
            {
                oTable.Cell(i, 1).Range.Text = makinaListView.Items[i - 2].SubItems[3].Text;
                oTable.Cell(i, 2).Range.Text = makinaListView.Items[i - 2].SubItems[4].Text;
                oTable.Cell(i, 3).Range.Text = makinaListView.Items[i - 2].SubItems[2].Text;
                oTable.Cell(i, 4).Range.Text = makinaListView.Items[i - 2].SubItems[1].Text;
                oTable.Cell(i, 5).Range.Text = makinaListView.Items[i - 2].SubItems[8].Text;
                oTable.Cell(i, 6).Range.Text = makinaListView.Items[i - 2].SubItems[6].Text;
                oTable.Cell(i, 7).Range.Text = makinaListView.Items[i - 2].SubItems[5].Text;
                oTable.Cell(i, 8).Range.Text = makinaListView.Items[i - 2].SubItems[7].Text;
            }

            for (int i = 2; i <= makinaListView.Items.Count+1; i++) { for (int k = 1; k <= 8; k++) { oTable.Cell(i, k).VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter; oTable.Cell(i, k).Range.Paragraphs.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft;  } }
            
            object EndPositon = 0;
            Microsoft.Office.Interop.Word.Range rngCrsr = oWordDoc.Range(ref EndPositon, ref EndPositon);
            rngCrsr.Select();
            oWordDoc.ActiveWindow.ActivePane.View.Type = Microsoft.Office.Interop.Word.WdViewType.wdPrintView;
            oWord.Visible = true;
        }

        private void yazdırButon_Click(object sender, EventArgs e)
        {
            TextToWordTable(@"C:\Program Files\Basak BOS v1.0\Templates\SysTemplates\ekipmanListesi.dotx");
            sistemAyarları.kayitEkle(Giris.kullanıcıAdı,"Ekipman Listesi Yazdırıldı");
        }
    }
}
