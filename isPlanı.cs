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
    public partial class isPlanı : Form
    {
        SqlCommand komut;
        SqlDataReader dr;

        public static bool bakımyapılmamis = false;
        public static bool pbakımen = true;
        public static bool dbakımen = true;
        public static DateTime listetarihi = DateTime.Today.AddDays(10);

        List<DateTime> baslangic = new List<DateTime>();
        List<string> baslangicS = new List<string>();
        List<DateTime> bitis = new List<DateTime>();
        List<string> bitisS = new List<string>();
        List<Int32> periyot = new List<Int32>();
        List<string> kalan = new List<string>();
        List<string> tur = new List<string>();
        List<string> isTanımı = new List<string>();
        List<string> talepEden = new List<string>();
        List<string> sorumlusu = new List<string>();
        List<string> ekipmanAdı = new List<string>();
        List<string> ekipmanKodu = new List<string>();
        List<string> birim = new List<string>();
        List<int> ID = new List<int>();
        List<int> ekipmanId = new List<int>();

        public static string seciliId = "";
        public static string seciliPBakımId = "";
        public static string seciliIsTuru = "";

        public isPlanı()
        {
            InitializeComponent();
        }

        private void isPlanı_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            listViewYazici();

            if (Giris.yetki == "misafir") { talepEkleButon.Enabled = false; talebiDüzenleButon.Enabled = false; sonucButon.Enabled = false; yazdırButon.Enabled = false; }
        }

        public void listViewYazici()
        {
            isListView.Clear();
            isListView.View = View.Details;
            isListView.FullRowSelect = true;
            isListView.MultiSelect = false;
            isListView.GridLines = true;
            isListView.CheckBoxes = true;

            isListView.Columns.Add("", 20);
            isListView.Columns.Add("Kalan", 40);
            isListView.Columns.Add("Tür", 80);
            isListView.Columns.Add("İş Tanımı", 250);
            isListView.Columns.Add("Talep Eden", 100);
            isListView.Columns.Add("Kayıt Tarihi/Son Bakım Tarihi", 100);
            isListView.Columns.Add("Planlanan Bitiş", 100);
            isListView.Columns.Add("Sorumlusu", 100);
            isListView.Columns.Add("Birim", 80);
            isListView.Columns.Add("Ekipman Adı", 300);
            isListView.Columns.Add("Ekipman Kodu", 100);
            isListView.Columns.Add("ID", 40);

            //temizlik
            baslangic.Clear(); bitis.Clear(); kalan.Clear(); periyot.Clear(); tur.Clear(); isTanımı.Clear(); talepEden.Clear(); sorumlusu.Clear(); ekipmanAdı.Clear(); ekipmanKodu.Clear(); ekipmanId.Clear(); birim.Clear(); ID.Clear();
            DateTime nulltarih = Convert.ToDateTime("01.01.2000");
            DateTime bugun = DateTime.Now;
            int periyodikSatır = 0;
            //kalan olustur,baslangic olustur,bitis olustur
            if (pbakımen)
            {
                if(bakımyapılmamis){komut = new SqlCommand("Select ISNULL(sonBakımTarihi,'2000-01-01'),Periyot,ID,Yeri,bakımNo,Kriter,Metod,[Araç ve Gereç],Tür From periyodikBakımListesi where (birSonrakiBakımTarihi <= '" + listetarihi.ToString("MM.dd.yyyy") + "' or birSonrakiBakımTarihi IS NULL) and Periyot >= 30", Giris.baglanti);}
                else { komut = new SqlCommand("Select ISNULL(sonBakımTarihi,'2000-01-01'),Periyot,ID,Yeri,bakımNo,Kriter,Metod,[Araç ve Gereç],Tür From periyodikBakımListesi where birSonrakiBakımTarihi <= '" + listetarihi.ToString("MM.dd.yyyy") + "' and Periyot >= 30", Giris.baglanti); }
                Giris.baglanti.Open(); dr = komut.ExecuteReader();
                while (dr.Read()) { baslangic.Add(dr.GetDateTime(0)); periyot.Add(dr.GetInt32(1)); } dr.Close(); Giris.baglanti.Close();
                for (int i = 0; i < baslangic.Count; i++) { if (baslangic[i] != nulltarih) { bitis.Add(baslangic[i].AddDays(periyot[i])); } else { bitis.Add(Convert.ToDateTime("01.01.2000")); } }
                periyodikSatır = baslangic.Count;
            }
            if (dbakımen)
            {
                komut = new SqlCommand("Select * From işListesi", Giris.baglanti);
                Giris.baglanti.Open(); dr = komut.ExecuteReader();
                while (dr.Read()) { baslangic.Add(dr.GetDateTime(3)); bitis.Add(dr.GetDateTime(4)); } dr.Close(); Giris.baglanti.Close();
            }
            for (int i = 0; i < baslangic.Count; i++) { if (baslangic[i] != nulltarih) { kalan.Add(bitis[i].Subtract(bugun).Days.ToString()); } else { kalan.Add("-999"); } }
            //tur olustur
            if (pbakımen)
            {
                if (bakımyapılmamis) { komut = new SqlCommand("Select ISNULL(sonBakımTarihi,'2000-01-01'),Periyot,ID,Yeri,bakımNo,Kriter,Metod,[Araç ve Gereç],Tür From periyodikBakımListesi where (birSonrakiBakımTarihi <= '" + listetarihi.ToString("MM.dd.yyyy") + "' or birSonrakiBakımTarihi IS NULL) and Periyot >= 30", Giris.baglanti); }
                else { komut = new SqlCommand("Select ISNULL(sonBakımTarihi,'2000-01-01'),Periyot,ID,Yeri,bakımNo,Kriter,Metod,[Araç ve Gereç],Tür From periyodikBakımListesi where birSonrakiBakımTarihi <= '" + listetarihi.ToString("MM.dd.yyyy") + "' and Periyot >= 30", Giris.baglanti); }
                Giris.baglanti.Open(); dr = komut.ExecuteReader();
                while (dr.Read()) { tur.Add(dr.GetString(8)); } dr.Close(); Giris.baglanti.Close();
            }
            if (dbakımen)
            {
                komut = new SqlCommand("Select * From işListesi", Giris.baglanti);
                Giris.baglanti.Open(); dr = komut.ExecuteReader();
                while (dr.Read()) { tur.Add(dr.GetString(5)); } dr.Close(); Giris.baglanti.Close();
            }
            //is tanımı olustur
            if (pbakımen)
            {
                if (bakımyapılmamis) { komut = new SqlCommand("Select ISNULL(sonBakımTarihi,'2000-01-01'),Periyot,ID,Yeri,bakımNo,Kriter,Metod,[Araç ve Gereç],Tür From periyodikBakımListesi where (birSonrakiBakımTarihi <= '" + listetarihi.ToString("MM.dd.yyyy") + "' or birSonrakiBakımTarihi IS NULL) and Periyot >= 30", Giris.baglanti); }
                else { komut = new SqlCommand("Select ISNULL(sonBakımTarihi,'2000-01-01'),Periyot,ID,Yeri,bakımNo,Kriter,Metod,[Araç ve Gereç],Tür From periyodikBakımListesi where birSonrakiBakımTarihi <= '" + listetarihi.ToString("MM.dd.yyyy") + "' and Periyot >= 30", Giris.baglanti); }
                Giris.baglanti.Open(); dr = komut.ExecuteReader();
                while (dr.Read()) { isTanımı.Add(dr.GetString(3) + " - " + dr.GetString(5)); } dr.Close(); Giris.baglanti.Close();
            }
            if (dbakımen)
            {
                komut = new SqlCommand("Select * From işListesi", Giris.baglanti);
                Giris.baglanti.Open(); dr = komut.ExecuteReader();
                while (dr.Read()) { isTanımı.Add(dr.GetString(0)); } dr.Close(); Giris.baglanti.Close();
            }
            // talep eden olustur
            if (pbakımen)
            {
                for (int i = 0; i < periyodikSatır; i++) { talepEden.Add("Bakım Atölyesi"); }
            }
            if (dbakımen)
            {
                komut = new SqlCommand("Select * From işListesi", Giris.baglanti);
                Giris.baglanti.Open(); dr = komut.ExecuteReader();
                while (dr.Read()) { talepEden.Add(dr.GetString(1)); } dr.Close(); Giris.baglanti.Close();
            }
            //kayıt tarihi olustur
            for (int i = 0; i < baslangic.Count; i++) { baslangicS.Add(baslangic[i].ToString("d")); }
            //bitis tarih olustur
            for (int i = 0; i < bitis.Count; i++) { bitisS.Add(bitis[i].ToString("d")); }
            //sorumlusu olustur.
            if (pbakımen)
            {
                for (int i = 0; i < periyodikSatır; i++) { sorumlusu.Add("Bakım Atölyesi"); }
            }
            if (dbakımen)
            {
                komut = new SqlCommand("Select * From işListesi", Giris.baglanti);
                Giris.baglanti.Open(); dr = komut.ExecuteReader();
                while (dr.Read()) { sorumlusu.Add(dr.GetString(2)); } dr.Close(); Giris.baglanti.Close();
            }
            //ekipman id olustur
            if (pbakımen)
            {
                if (bakımyapılmamis) { komut = new SqlCommand("Select ISNULL(sonBakımTarihi,'2000-01-01'),Periyot,ID,Yeri,bakımNo,Kriter,Metod,[Araç ve Gereç],Tür From periyodikBakımListesi where (birSonrakiBakımTarihi <= '" + listetarihi.ToString("MM.dd.yyyy") + "' or birSonrakiBakımTarihi IS NULL) and Periyot >= 30", Giris.baglanti); }
                else { komut = new SqlCommand("Select ISNULL(sonBakımTarihi,'2000-01-01'),Periyot,ID,Yeri,bakımNo,Kriter,Metod,[Araç ve Gereç],Tür From periyodikBakımListesi where birSonrakiBakımTarihi <= '" + listetarihi.ToString("MM.dd.yyyy") + "' and Periyot >= 30", Giris.baglanti); }
                Giris.baglanti.Open(); dr = komut.ExecuteReader();
                while (dr.Read()) { ekipmanId.Add(dr.GetInt32(2)); } dr.Close(); Giris.baglanti.Close();
            }
            if (dbakımen)
            {
                komut = new SqlCommand("Select * From işListesi", Giris.baglanti);
                Giris.baglanti.Open(); dr = komut.ExecuteReader();
                while (dr.Read()) { ekipmanId.Add(dr.GetInt32(6)); } dr.Close(); Giris.baglanti.Close();
            }
            //birim, ekipman adı, ekipman kodu oluştur
            for (int i = 0; i < ekipmanId.Count; i++)
            {
                komut = new SqlCommand("Select Birim,Adı,[Ekipman Kodu] From makinaListesi Where ID=" + ekipmanId[i].ToString(), Giris.baglanti);
                Giris.baglanti.Open(); dr = komut.ExecuteReader();
                while (dr.Read()) { birim.Add(dr.GetString(0)); ekipmanAdı.Add(dr.GetString(1)); ekipmanKodu.Add(dr.GetString(2)); } dr.Close(); Giris.baglanti.Close();
            }
            //islem id oluştur
            if (pbakımen)
            {
                if (bakımyapılmamis) { komut = new SqlCommand("Select ISNULL(sonBakımTarihi,'2000-01-01'),Periyot,ID,Yeri,bakımNo,Kriter,Metod,[Araç ve Gereç],Tür From periyodikBakımListesi where (birSonrakiBakımTarihi <= '" + listetarihi.ToString("MM.dd.yyyy") + "' or birSonrakiBakımTarihi IS NULL) and Periyot >= 30", Giris.baglanti); }
                else { komut = new SqlCommand("Select ISNULL(sonBakımTarihi,'2000-01-01'),Periyot,ID,Yeri,bakımNo,Kriter,Metod,[Araç ve Gereç],Tür From periyodikBakımListesi where birSonrakiBakımTarihi <= '" + listetarihi.ToString("MM.dd.yyyy") + "' and Periyot >= 30", Giris.baglanti); }
                Giris.baglanti.Open(); dr = komut.ExecuteReader();
                while (dr.Read()) { ID.Add(dr.GetInt32(4)); } dr.Close(); Giris.baglanti.Close();
            }
            if (dbakımen)
            {
                komut = new SqlCommand("Select * From işListesi", Giris.baglanti);
                Giris.baglanti.Open(); dr = komut.ExecuteReader();
                while (dr.Read()) { ID.Add(dr.GetInt32(7)); } dr.Close(); Giris.baglanti.Close();
            }
            
            for (int i = 0; i < ID.Count; i++) 
            {
                ListViewItem tablo = new ListViewItem();
                tablo.SubItems.Add(Convert.ToString(kalan[i]));
                tablo.SubItems.Add(Convert.ToString(tur[i]));
                tablo.SubItems.Add(Convert.ToString(isTanımı[i]));
                tablo.SubItems.Add(Convert.ToString(talepEden[i]));
                tablo.SubItems.Add(Convert.ToString(baslangicS[i]));
                tablo.SubItems.Add(Convert.ToString(bitisS[i]));
                tablo.SubItems.Add(Convert.ToString(sorumlusu[i]));
                tablo.SubItems.Add(Convert.ToString(birim[i]));
                tablo.SubItems.Add(Convert.ToString(ekipmanAdı[i]));
                tablo.SubItems.Add(Convert.ToString(ekipmanKodu[i]));
                tablo.SubItems.Add(Convert.ToString(ID[i]));
                isListView.Items.Add(tablo);
            }
            isListView.ListViewItemSorter = new IntegerComparer(1);
            isListView.Sort();

            int j = 0;
            Color shaded = Color.FromArgb(240, 240, 240);
            foreach (ListViewItem item in isListView.Items)
            {
                if (j++ % 2 == 0) { item.BackColor = Color.LightCyan; item.UseItemStyleForSubItems = true; }
                else { item.BackColor = Color.Aqua; item.UseItemStyleForSubItems = true; }
            }
        }

        public class IntegerComparer : IComparer//http://stackoverflow.com/questions/1214289/how-do-i-sort-integers-in-a-listview
        {
            private int _colIndex;
            public IntegerComparer(int colIndex)
            {
                _colIndex = colIndex;
            }
            public int Compare(object x, object y)
            {
                int nx = int.Parse((x as ListViewItem).SubItems[_colIndex].Text);
                int ny = int.Parse((y as ListViewItem).SubItems[_colIndex].Text);
                return nx.CompareTo(ny);
            }
        }

        private void isPlanı_FormClosed(object sender, FormClosedEventArgs e)
        {
            anaMenu menu = new anaMenu();
            menu.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void talepEkleButon_Click(object sender, EventArgs e)
        {
            while (true)
            {
                isTalebiEkle talepEkle = new isTalebiEkle();
                DialogResult diar = talepEkle.ShowDialog();
                if (diar == DialogResult.Yes) { if (isTalebiEkle.yenile) { listViewYazici(); break; } }
                else break;
            }
        }

        private void isListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            try { ListViewItem item = isListView.SelectedItems[0]; if (item.SubItems[1].Text != "Periyodik Bakım") { seciliId = item.SubItems[10].Text; seciliPBakımId = ""; seciliIsTuru = "  "; } else { seciliId = ""; seciliPBakımId = item.SubItems[10].Text; seciliIsTuru = "Periyodik Bakım"; } }
            catch (Exception) { seciliId = ""; seciliPBakımId = ""; seciliIsTuru = ""; }
        }

        private void talebiDüzenleButon_Click(object sender, EventArgs e)
        {
            if (seciliId != "")
            {
                while (true)
                {
                    isTalebiDüzenle talepDuzenle = new isTalebiDüzenle();
                    DialogResult diar1 = talepDuzenle.ShowDialog();
                    if (diar1 == DialogResult.Yes) { if (isTalebiDüzenle.yenile) { listViewYazici(); break; } }
                    else break;
                }
            }
            else { MessageBox.Show("Bakım Seçiniz!\nPeriyodik Bakım Düzenlenemez"); }
        }

        private void yazdırButon_Click(object sender, EventArgs e)
        {
            TextToWordTable(@"C:\Program Files\Basak BOS v1.0\Templates\SysTemplates\isPlani.dotx");
            sistemAyarları.kayitEkle(Giris.kullanıcıAdı,"İş Planı Yazdırıldı");
        }

        private void sonucButon_Click(object sender, EventArgs e)
        {
            if (seciliIsTuru != "")
            {
                while (true)
                {
                    isiSonlandir sonlandir = new isiSonlandir();
                    DialogResult diar2 = sonlandir.ShowDialog();
                    if (diar2 == DialogResult.Yes) { if (isiSonlandir.yenile) { listViewYazici(); break; } }
                    else break;
                }
            }
            else { MessageBox.Show("İş Seçiniz!"); }
        }

        private void yenileButon_Click(object sender, EventArgs e)
        {
            listViewYazici();
        }

        private void listelemeButon_Click(object sender, EventArgs e)
        {
            while (true)
            {
                isPlanıListeleme listele = new isPlanıListeleme();
                DialogResult diar3 = listele.ShowDialog();
                if (diar3 == DialogResult.Yes) { if (isPlanıListeleme.yenile) { listViewYazici(); break; } }
                else break;
            }
        }

        public void TextToWordTable(string pWordDoc)
        {
            int issayisi = 0;
            for (int i = 0; i < isListView.Items.Count; i++) { if (isListView.Items[i].Checked) issayisi++; }

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
            oTable = oWordDoc.Tables.Add(wrdRng, issayisi + 1, 8, ref oMissing, ref oMissing);
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
            oTable.Cell(1, 1).Range.Text = "Başlangıç Tarihi"; oTable.Cell(1, 2).Range.Text = "Planlanan Bitiş Tarihi"; oTable.Cell(1, 3).Range.Text = "Ekipman Kodu"; oTable.Cell(1, 4).Range.Text = "Ekipman Adı"; oTable.Cell(1, 5).Range.Text = "Atölye"; oTable.Cell(1, 6).Range.Text = "İşlem Türü"; oTable.Cell(1, 7).Range.Text = "İş Tanımı"; oTable.Cell(1, 8).Range.Text = "Açıklama";

            for (int i = 1; i <= 8; i++) { oTable.Cell(1, i).VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter; oTable.Cell(1, i).Range.Paragraphs.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter; }
            int satır = 2;
            for (int i = 0; i < isListView.Items.Count ; i++)
            {
                if (isListView.Items[i].Checked)
                {
                    oTable.Cell(satır, 1).Range.Text = isListView.Items[i].SubItems[5].Text;
                    oTable.Cell(satır, 2).Range.Text = isListView.Items[i].SubItems[6].Text;
                    oTable.Cell(satır, 3).Range.Text = isListView.Items[i].SubItems[10].Text;
                    oTable.Cell(satır, 4).Range.Text = isListView.Items[i].SubItems[9].Text;
                    oTable.Cell(satır, 5).Range.Text = isListView.Items[i].SubItems[8].Text;
                    oTable.Cell(satır, 6).Range.Text = isListView.Items[i].SubItems[2].Text;
                    oTable.Cell(satır, 7).Range.Text = isListView.Items[i].SubItems[3].Text;
                    satır++;
                }
            }

            for (int i = 2; i <= issayisi + 1; i++) { for (int k = 1; k <= 8; k++) { oTable.Cell(i, k).VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter; oTable.Cell(i, k).Range.Paragraphs.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft; } }

            object EndPositon = 0;
            Microsoft.Office.Interop.Word.Range rngCrsr = oWordDoc.Range(ref EndPositon, ref EndPositon);
            rngCrsr.Select();
            oWordDoc.ActiveWindow.ActivePane.View.Type = Microsoft.Office.Interop.Word.WdViewType.wdPrintView;
            oWord.Visible = true;
        }
    }
}
