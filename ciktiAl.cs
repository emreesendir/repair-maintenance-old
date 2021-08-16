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
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;

namespace WindowsFormsApplication1
{
    public partial class ciktiAl : Form
    {
        static SqlCommand komut;
        static SqlDataReader dr;
        static string periyotDurum = "";
        /*
        List<Int32> periyotlar = new List<Int32>();
        List<string> kolon2 = new List<string>();
        List<string> kolon3 = new List<string>();
        List<string> kolon4 = new List<string>();
        List<string> kolon5 = new List<string>();
        List<string> kolon6 = new List<string>();
        List<string> kolon7 = new List<string>();
        List<string> kolon8 = new List<string>();
        List<string> kolon9 = new List<string>();
        List<string> kolon10 = new List<string>();
        List<string> kolon11 = new List<string>();
        List<string> kolon12 = new List<string>();
        List<string> kolon13 = new List<string>();
        List<string> kolon14 = new List<string>();
        List<string> kolon15 = new List<string>();
        */
        List<string> tarih = new List<string>();
        List<string> bsaat = new List<string>();
        List<string> tip = new List<string>();
        List<string> tanım = new List<string>();
        List<string> sorumlu = new List<string>();
        List<string> açıklama = new List<string>();
        List<string> dsaati = new List<string>();

        string aylikSimge = "□", ucaylikSimge = "∆", altiaylikSimge = "0", yillikSimge = "◊";

        public ciktiAl()
        {
            InitializeComponent();
        }

        private void yazdırButon_Click(object sender, EventArgs e)
        {
            string adres = "";

            if (belgeTuruComboBox.Text=="Sicil Kartı")
            {
                tarih.Clear(); bsaat.Clear(); tip.Clear(); tanım.Clear(); sorumlu.Clear(); açıklama.Clear(); dsaati.Clear();

                komut = new SqlCommand("Select sicilSablonAdresi From makinaGrupları where makinaGurubu='" + grupTextBox.Text + "'", Giris.baglanti);
                Giris.baglanti.Open(); dr = komut.ExecuteReader();
                while (dr.Read()) { adres = dr.GetString(0); } dr.Close(); Giris.baglanti.Close();

                komut = new SqlCommand("Select Top 47 * From işGeçmişi where makinaGurubu='" + grupTextBox.Text + "'", Giris.baglanti);
                Giris.baglanti.Open(); dr = komut.ExecuteReader();
                while (dr.Read()) { tarih.Add(dr.GetDateTime(4).ToString("d")); bsaat.Add(dr.GetString(11)); tip.Add(dr.GetString(9)); tanım.Add(dr.GetString(0)); sorumlu.Add(dr.GetString(2)); açıklama.Add(dr.GetString(7)); dsaati.Add(dr.GetString(10)); } dr.Close(); Giris.baglanti.Close();

                exceleSicilYaz(adres);
                sistemAyarları.kayitEkle(Giris.kullanıcıAdı,"Sicil Kartı Oluşturuldu [Ekipman Kodu]: " + makinaKoduTextBox.Text);
            }
            else if(belgeTuruComboBox.Text=="Çalıştırma Talimatı")
            {
                komut = new SqlCommand("Select calistirmaSablonAdresi From makinaGrupları where makinaGrubu='" + grupTextBox.Text + "'", Giris.baglanti);
                Giris.baglanti.Open();
                dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    adres = dr.GetString(0);
                }
                dr.Close();
                Giris.baglanti.Close();

                TextToWord(adres, "birim", birmTextBox.Text, "kodu", makinaKoduTextBox.Text);
                sistemAyarları.kayitEkle(Giris.kullanıcıAdı, "Çalıştırma Talimatı Oluşturuldu [Ekipman Kodu]: " + makinaKoduTextBox.Text);

            }
            else if (belgeTuruComboBox.Text == "Operatörler İçin Bakım Talimatı")
            {
                string semaadresi = "";
                komut = new SqlCommand("Select gunlukBakımSablonAdresi,ISNULL(Şema,'NULL') From makinaGrupları where makinaGrubu='" + grupTextBox.Text + "'", Giris.baglanti);
                Giris.baglanti.Open(); dr = komut.ExecuteReader();
                while (dr.Read()) { adres = dr.GetString(0); semaadresi = dr.GetString(1); } dr.Close(); Giris.baglanti.Close();
                periyotDurum = "Periyot<=7";
                TextToWordTable(adres,semaadresi);
                sistemAyarları.kayitEkle(Giris.kullanıcıAdı, "Operatörler İçin Bakım Talimatı Oluşturuldu [Ekipman Kodu]: " + makinaKoduTextBox.Text);
            }
            else if (belgeTuruComboBox.Text == "Bakımcı İçin Bakım Talimatı")
            {
                /*
                periyotlar.Clear(); kolon2.Clear(); kolon3.Clear(); kolon4.Clear(); kolon5.Clear(); kolon6.Clear(); kolon7.Clear(); kolon8.Clear(); kolon9.Clear(); kolon10.Clear(); kolon11.Clear(); kolon12.Clear(); kolon13.Clear(); kolon14.Clear(); kolon15.Clear();

                komut = new SqlCommand("Select yillikBakımSablonAdresi From makinaGrupları where makinaGrubu='" + grupTextBox.Text + "'", Giris.baglanti);
                Giris.baglanti.Open();
                dr = komut.ExecuteReader();
                while (dr.Read()) { adres = dr.GetString(0); } dr.Close(); Giris.baglanti.Close();

                komut = new SqlCommand("Select Açıklama,Periyot From periyodikBakımListesi where ID=" + makinaListesi.seciliID, Giris.baglanti);
                Giris.baglanti.Open();
                dr = komut.ExecuteReader();
                while (dr.Read()) { kolon2.Add(dr.GetString(0)); periyotlar.Add(dr.GetInt32(1)); } dr.Close(); Giris.baglanti.Close();
                
                for (int i = 0; i < kolon2.Count; i++)
                {
                    int periyotay = periyotlar[i]/30;
                    if (periyotay < 3) { kolon3.Add(aylikSimge); kolon4.Add(aylikSimge); kolon5.Add(aylikSimge); kolon6.Add(aylikSimge); kolon7.Add(aylikSimge); kolon8.Add(aylikSimge); kolon9.Add(aylikSimge); kolon10.Add(aylikSimge); kolon11.Add(aylikSimge); kolon12.Add(aylikSimge); kolon13.Add(aylikSimge); kolon14.Add(aylikSimge); kolon15.Add(aylikSimge); }
                    else if (periyotay >= 3 && periyotay < 6) { kolon3.Add(ucaylikSimge); kolon4.Add(ucaylikSimge); kolon5.Add(" "); kolon6.Add(" "); kolon7.Add(ucaylikSimge); kolon8.Add(" "); kolon9.Add(" "); kolon10.Add(ucaylikSimge); kolon11.Add(" "); kolon12.Add(" "); kolon13.Add(ucaylikSimge); kolon14.Add(" "); kolon15.Add(" "); }
                    else if (periyotay >= 6 && periyotay < 12) { kolon3.Add(altiaylikSimge); kolon4.Add(altiaylikSimge); kolon5.Add(" "); kolon6.Add(" "); kolon7.Add(" "); kolon8.Add(" "); kolon9.Add(" "); kolon10.Add(altiaylikSimge); kolon11.Add(" "); kolon12.Add(" "); kolon13.Add(" "); kolon14.Add(" "); kolon15.Add(" "); }
                    else if (periyotay == 12) { kolon3.Add(yillikSimge); kolon4.Add(yillikSimge); kolon5.Add(" "); kolon6.Add(" "); kolon7.Add(" "); kolon8.Add(" "); kolon9.Add(" "); kolon10.Add(" "); kolon11.Add(" "); kolon12.Add(" "); kolon13.Add(" "); kolon14.Add(" "); kolon15.Add(" "); }
                }
                exceleYaz(adres);*/
                string semaadresi = "";
                komut = new SqlCommand("Select yillikBakımSablonAdresi,ISNULL(Şema,'NULL') From makinaGrupları where makinaGrubu='" + grupTextBox.Text + "'", Giris.baglanti);
                Giris.baglanti.Open(); dr = komut.ExecuteReader();
                while (dr.Read()) { adres = dr.GetString(0); semaadresi = dr.GetString(1); } dr.Close(); Giris.baglanti.Close();
                periyotDurum = "Periyot>=30";
                TextToWordTable(adres,semaadresi);
                sistemAyarları.kayitEkle(Giris.kullanıcıAdı, "Bakımcı İçin Bakım Talimatı Oluşturuldu [Ekipman Kodu]: " + makinaKoduTextBox.Text);
            }
            else MessageBox.Show("Belge türü giriniz!");
        }

        public static void TextToWord(string pWordDoc, string pMergeField1, string pValue1, string pMergeField2, string pValue2)//Kaynak: http://stackoverflow.com/questions/10734817/sending-text-to-mail-merge-fields-in-microsoft-word-2010
        {
            Object oMissing = System.Reflection.Missing.Value;
            Object oTrue = true;
            Object oFalse = false;
            Microsoft.Office.Interop.Word.Application oWord = new Microsoft.Office.Interop.Word.Application();
            Microsoft.Office.Interop.Word.Document oWordDoc = new Microsoft.Office.Interop.Word.Document();
            oWord.Visible = true;
            Object oTemplatePath = pWordDoc;
            oWordDoc = oWord.Documents.Add(ref oTemplatePath, ref oMissing, ref oMissing, ref oMissing);
            foreach (Microsoft.Office.Interop.Word.Field myMergeField in oWordDoc.Fields)
            {
                Microsoft.Office.Interop.Word.Range rngFieldCode = myMergeField.Code;
                String fieldText = rngFieldCode.Text;
                if (fieldText.StartsWith(" MERGEFIELD"))
                {
                    Int32 endMerge = fieldText.IndexOf("\\");
                    Int32 fieldNameLength = fieldText.Length - endMerge;
                    String fieldName = fieldText.Substring(11, endMerge - 11);
                    fieldName = fieldName.Trim();
                    if (fieldName == pMergeField1)
                    {
                        myMergeField.Select();
                        oWord.Selection.TypeText(pValue1);
                    }
                    else if (fieldName == pMergeField2)
                    {
                        myMergeField.Select();
                        oWord.Selection.TypeText(pValue2);
                    }
                }
            }
        }

        public static void TextToWordTable(string pWordDoc,string semaadresi)
        {
            List<string> no = new List<string>();
            List<string> yeri = new List<string>();
            List<string> kriter = new List<string>();
            List<string> metod = new List<string>();
            List<string> arac = new List<string>();
            List<string> pryd = new List<string>();
            komut = new SqlCommand("Select * From periyodikBakımListesi where Tür='Temizlik' and "+periyotDurum+" and ID=" + makinaListesi.seciliID + "Order By Periyot ASC", Giris.baglanti);
            Giris.baglanti.Open(); dr = komut.ExecuteReader();
            while (dr.Read()) { no.Add(dr.GetString(10)); yeri.Add(dr.GetString(1)); kriter.Add(dr.GetString(6)); metod.Add(dr.GetString(7)); arac.Add(dr.GetString(8)); if (dr.GetInt32(2) == 1) pryd.Add("G"); else if (dr.GetInt32(2) == 7) pryd.Add("H"); else if (dr.GetInt32(2) == 30) pryd.Add("A"); else if (dr.GetInt32(2) == 90) pryd.Add("3A"); else if (dr.GetInt32(2) == 180) pryd.Add("6A"); else if (dr.GetInt32(2) == 360) pryd.Add("Y"); } dr.Close(); Giris.baglanti.Close(); int tsatır = no.Count;
            komut = new SqlCommand("Select * From periyodikBakımListesi where Tür='Yağlama' and " + periyotDurum + " and ID=" + makinaListesi.seciliID + "Order By Periyot ASC", Giris.baglanti);
            Giris.baglanti.Open(); dr = komut.ExecuteReader();
            while (dr.Read()) { no.Add(dr.GetString(10)); yeri.Add(dr.GetString(1)); kriter.Add(dr.GetString(6)); metod.Add(dr.GetString(7)); arac.Add(dr.GetString(8)); if (dr.GetInt32(2) == 1) pryd.Add("G"); else if (dr.GetInt32(2) == 7) pryd.Add("H"); else if (dr.GetInt32(2) == 30) pryd.Add("A"); else if (dr.GetInt32(2) == 90) pryd.Add("3A"); else if (dr.GetInt32(2) == 180) pryd.Add("6A"); else if (dr.GetInt32(2) == 360) pryd.Add("Y"); } dr.Close(); Giris.baglanti.Close(); int ysatır = no.Count - tsatır;
            komut = new SqlCommand("Select * From periyodikBakımListesi where Tür='Kontrol' and " + periyotDurum + " and ID=" + makinaListesi.seciliID + "Order By Periyot ASC", Giris.baglanti);
            Giris.baglanti.Open(); dr = komut.ExecuteReader();
            while (dr.Read()) { no.Add(dr.GetString(10)); yeri.Add(dr.GetString(1)); kriter.Add(dr.GetString(6)); metod.Add(dr.GetString(7)); arac.Add(dr.GetString(8)); if (dr.GetInt32(2) == 1) pryd.Add("G"); else if (dr.GetInt32(2) == 7) pryd.Add("H"); else if (dr.GetInt32(2) == 30) pryd.Add("A"); else if (dr.GetInt32(2) == 90) pryd.Add("3A"); else if (dr.GetInt32(2) == 180) pryd.Add("6A"); else if (dr.GetInt32(2) == 360) pryd.Add("Y"); } dr.Close(); Giris.baglanti.Close(); int ksatır = no.Count - tsatır - ysatır;

            Object oMissing = System.Reflection.Missing.Value;
            Object oTrue = true;
            Object oFalse = false;
            Microsoft.Office.Interop.Word.Application oWord = new Microsoft.Office.Interop.Word.Application();
            Microsoft.Office.Interop.Word.Document oWordDoc = new Microsoft.Office.Interop.Word.Document();
            Object oEndOfDoc = "\\endofdoc";
            oWord.Visible = false;
            Object oTemplatePath = pWordDoc;
            oWordDoc = oWord.Documents.Add(ref oTemplatePath, ref oMissing, ref oMissing, ref oMissing);

            foreach (Microsoft.Office.Interop.Word.Section section in oWordDoc.Sections )
            {
                Microsoft.Office.Interop.Word.Range headerRange = section.Headers[Microsoft.Office.Interop.Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
                foreach (Microsoft.Office.Interop.Word.Field myMergeField in headerRange.Fields)
                {
                    Microsoft.Office.Interop.Word.Range rngFieldCode = myMergeField.Code;
                    String fieldText = rngFieldCode.Text;
                    if (fieldText.StartsWith(" MERGEFIELD"))
                    {
                        Int32 endMerge = fieldText.IndexOf("\\");
                        Int32 fieldNameLength = fieldText.Length - endMerge;
                        String fieldName = fieldText.Substring(11, endMerge - 11);
                        fieldName = fieldName.Trim();
                        if (fieldName == "marka")
                        {
                            myMergeField.Select();
                            oWord.Selection.TypeText(ekipmanDetay.secilimarka);
                        }
                        else if (fieldName == "model")
                        {
                            myMergeField.Select();
                            oWord.Selection.TypeText(ekipmanDetay.secilimodel);
                        }
                        else if (fieldName == "serino")
                        {
                            myMergeField.Select();
                            oWord.Selection.TypeText(ekipmanDetay.seciliNo);
                        }
                        else if (fieldName == "dönem")
                        {
                            myMergeField.Select();
                            oWord.Selection.TypeText(DateTime.Today.ToString("MMMM/yyyy"));
                        }
                        else if (fieldName == "ekipmanadı")
                        {
                            myMergeField.Select();
                            oWord.Selection.TypeText(ekipmanDetay.seciliadı);
                        }
                    }
                }
            }

            oWordDoc.Paragraphs.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
            if (semaadresi!="NULL") { Microsoft.Office.Interop.Word.Range picRange = oWordDoc.Bookmarks.get_Item(ref oEndOfDoc).Range; oWord.Selection.InlineShapes.AddPicture(semaadresi, ref oMissing, ref oMissing, picRange); }
            
            //tablo oluşturma
            Microsoft.Office.Interop.Word.Table oTable;
            Microsoft.Office.Interop.Word.Range wrdRng = oWordDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            oTable = oWordDoc.Tables.Add(wrdRng, tsatır + ysatır + ksatır + 6, 39, ref oMissing, ref oMissing);
            Object style="Tablo Kılavuzu";
            oTable.set_Style(ref style);
            oTable.LeftPadding = 0.3f; oTable.RightPadding = 0; oTable.TopPadding = 0.3f; oTable.BottomPadding = 0;
            //sütun genişlikleri
            for (int i = 1; i <= 39; i++)
            {
                switch (i)
                {
                    case 1: oTable.Columns[i].SetWidth(10, Microsoft.Office.Interop.Word.WdRulerStyle.wdAdjustNone); break;
                    case 2: oTable.Columns[i].SetWidth(17,Microsoft.Office.Interop.Word.WdRulerStyle.wdAdjustNone); break;
                    case 3: oTable.Columns[i].SetWidth(108, Microsoft.Office.Interop.Word.WdRulerStyle.wdAdjustNone); break;
                    case 4: oTable.Columns[i].SetWidth(135, Microsoft.Office.Interop.Word.WdRulerStyle.wdAdjustNone); break;
                    case 5: oTable.Columns[i].SetWidth(52, Microsoft.Office.Interop.Word.WdRulerStyle.wdAdjustNone); break;
                    case 6: oTable.Columns[i].SetWidth(46, Microsoft.Office.Interop.Word.WdRulerStyle.wdAdjustNone); break;
                    case 7: oTable.Columns[i].SetWidth(140, Microsoft.Office.Interop.Word.WdRulerStyle.wdAdjustNone); break;
                    case 8: oTable.Columns[i].SetWidth(25, Microsoft.Office.Interop.Word.WdRulerStyle.wdAdjustNone); break;
                    default: oTable.Columns[i].SetWidth(8, Microsoft.Office.Interop.Word.WdRulerStyle.wdAdjustNone); break;
                }
            }
            //başlık kısımlarının biçimlendirilmesi doldurulması
            oTable.Rows.HeightRule = Microsoft.Office.Interop.Word.WdRowHeightRule.wdRowHeightAtLeast;
            oTable.Range.Font.Size = 8; oTable.Range.Font.Name = "Times New Romans"; oTable.Range.Font.Bold = 0;

            oWordDoc.Tables[1].Cell(1, 1).Merge(oWordDoc.Tables[1].Cell(tsatır + 2, 1)); oTable.Cell(1, 1).Range.Text = "T\nE\nM\nİ\nZ\nL\nİ\nK"; 

            for (int i = 2; i <= 8; i++) { if (i != 5 && i != 6)  oWordDoc.Tables[1].Cell(1, i).Merge(oWordDoc.Tables[1].Cell(2, i));} 
            oWordDoc.Tables[1].Cell(1, 5).Merge(oWordDoc.Tables[1].Cell(2, 6));
            oWordDoc.Tables[1].Cell(1, 8).Merge(oWordDoc.Tables[1].Cell(1, 38));
            for (int i = 3; i <= tsatır + 2; i++) oWordDoc.Tables[1].Cell(i, 5).Merge(oWordDoc.Tables[1].Cell(i, 6));
            for (int i = 1; i < 9; i++) { oTable.Cell(1, i).Range.Font.Size = 10; oTable.Cell(1, i).Range.Font.Name = "Times New Romans"; oTable.Cell(1, i).Range.Font.Bold = 1; }
            oTable.Cell(1, 2).Range.Text = "No"; oTable.Cell(1, 3).Range.Text = "Yeri"; oTable.Cell(1, 4).Range.Text = "Kriter"; oTable.Cell(1, 5).Range.Text = "Metod"; oTable.Cell(1, 6).Range.Text = "Araç ve Gereç"; oTable.Cell(1, 7).Range.Text = "Pryd."; oTable.Cell(1, 8).Range.Text = "Kontrol Çizelgesi"; for (int i = 8; i <= 38; i++) { oTable.Cell(2, i).Range.Text = (i - 7).ToString(); oTable.Cell(2, i).Range.Font.Bold = 0; oTable.Cell(2, i).Range.Font.Size = 7; oTable.Cell(2, i).Range.Font.Name = "Times New Romans"; }

            oWordDoc.Tables[1].Cell(tsatır + 3, 1).Merge(oWordDoc.Tables[1].Cell(tsatır + ysatır + 4, 1)); oTable.Cell(tsatır+3, 1).Range.Text = "Y\nA\nĞ\nL\nA\nM\nA";

            for (int i = 2; i <= 8; i++) { if (i != 5 && i != 6)  oWordDoc.Tables[1].Cell(tsatır+3, i).Merge(oWordDoc.Tables[1].Cell(tsatır+4, i));}
            oWordDoc.Tables[1].Cell(tsatır+3, 5).Merge(oWordDoc.Tables[1].Cell(tsatır+4, 6));
            oWordDoc.Tables[1].Cell(tsatır+3, 8).Merge(oWordDoc.Tables[1].Cell(tsatır+3, 38));
            for (int i = tsatır+5; i <= tsatır+ysatır + 4; i++) oWordDoc.Tables[1].Cell(i, 5).Merge(oWordDoc.Tables[1].Cell(i, 6));
            for (int i = 1; i < 9; i++) { oTable.Cell(tsatır+3, i).Range.Font.Size = 10; oTable.Cell(tsatır+3, i).Range.Font.Name = "Times New Romans"; oTable.Cell(tsatır+3, i).Range.Font.Bold = 1; }
            oTable.Cell(tsatır + 3, 2).Range.Text = "No"; oTable.Cell(tsatır + 3, 3).Range.Text = "Yağlama Noktaları"; oTable.Cell(tsatır + 3, 4).Range.Text = "Kriter"; oTable.Cell(tsatır + 3, 5).Range.Text = "Yağ Tipi"; oTable.Cell(tsatır + 3, 6).Range.Text = "Araç ve Gereç"; oTable.Cell(tsatır + 3, 7).Range.Text = "Pryd."; oTable.Cell(tsatır + 3, 8).Range.Text = "Kontrol Çizelgesi"; for (int i = 8; i <= 38; i++) { oTable.Cell(tsatır + 4, i).Range.Text = (i - 7).ToString(); oTable.Cell(tsatır + 4, i).Range.Font.Bold = 0; oTable.Cell(tsatır + 4, i).Range.Font.Size = 7; oTable.Cell(tsatır + 4, i).Range.Font.Name = "Times New Romans"; }

            oWordDoc.Tables[1].Cell(tsatır + ysatır + 5, 1).Merge(oWordDoc.Tables[1].Cell(tsatır + ysatır + ksatır + 6, 1)); oTable.Cell(tsatır+ysatır + 5, 1).Range.Text = "K\nO\nN\nT\nR\nO\nL";

            for (int i = 2; i <= 8; i++) { if (i != 6 && i != 7)  oWordDoc.Tables[1].Cell(tsatır+ysatır + 5, i).Merge(oWordDoc.Tables[1].Cell(tsatır+ysatır + 6, i)); }
            oWordDoc.Tables[1].Cell(tsatır + ysatır + 5, 6).Merge(oWordDoc.Tables[1].Cell(tsatır + ysatır + 6, 7));
            oWordDoc.Tables[1].Cell(tsatır + ysatır + 5, 8).Merge(oWordDoc.Tables[1].Cell(tsatır + ysatır + 5, 38));
            for (int i = tsatır+ysatır + 7; i <= tsatır + ysatır+ksatır + 6; i++) oWordDoc.Tables[1].Cell(i, 6).Merge(oWordDoc.Tables[1].Cell(i, 7));
            for (int i = 1; i < 9; i++) { oTable.Cell(tsatır+ysatır + 5, i).Range.Font.Size = 10; oTable.Cell(tsatır+ysatır + 5, i).Range.Font.Name = "Times New Romans"; oTable.Cell(tsatır+ysatır + 5, i).Range.Font.Bold = 1; }
            oTable.Cell(tsatır + ysatır + 5, 2).Range.Text = "No"; oTable.Cell(tsatır + ysatır + 5, 3).Range.Text = "Yeri"; oTable.Cell(tsatır + ysatır + 5, 4).Range.Text = "Kriter"; oTable.Cell(tsatır + ysatır + 5, 5).Range.Text = "Metod"; oTable.Cell(tsatır + ysatır + 5, 6).Range.Text = "Operasyonlar"; oTable.Cell(tsatır + ysatır + 5, 7).Range.Text = "Pryd."; oTable.Cell(tsatır + ysatır + 5, 8).Range.Text = "Kontrol Çizelgesi"; for (int i = 8; i <= 38; i++) { oTable.Cell(tsatır + ysatır + 6, i).Range.Text = (i - 7).ToString(); oTable.Cell(tsatır + ysatır + 6, i).Range.Font.Bold = 0; oTable.Cell(tsatır + ysatır + 6, i).Range.Font.Size = 7; oTable.Cell(tsatır + ysatır + 6, i).Range.Font.Name = "Times New Romans"; }

            for (int i = 1; i < 9; i++) { oTable.Cell(1, i).VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter; oTable.Cell(1, i).Range.Paragraphs.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter; }
            for (int i = 8; i < 39; i++) { oTable.Cell(2, i).VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter; oTable.Cell(2, i).Range.Paragraphs.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter; }

            for (int i = 1; i < 9; i++) { oTable.Cell(tsatır+3, i).VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter; oTable.Cell(tsatır+3, i).Range.Paragraphs.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter; }
            for (int i = 8; i < 39; i++) { oTable.Cell(tsatır+4, i).VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter; oTable.Cell(tsatır+4, i).Range.Paragraphs.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter; }

            for (int i = 1; i < 9; i++) { oTable.Cell(tsatır+ysatır + 5, i).VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter; oTable.Cell(tsatır+ysatır + 5, i).Range.Paragraphs.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter; }
            for (int i = 8; i < 39; i++) { oTable.Cell(tsatır+ysatır + 6, i).VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter; oTable.Cell(tsatır+ysatır + 6, i).Range.Paragraphs.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter; }
            int j=0;
            for (int i = 1; i <= tsatır + ysatır + ksatır + 6; i++)
            {
                if (i > 2 && i <= tsatır + 2) { oTable.Cell(i, 2).Range.Text = no[j]; oTable.Cell(i, 3).Range.Text = yeri[j]; oTable.Cell(i, 4).Range.Text = kriter[j]; oTable.Cell(i, 5).Range.Text = metod[j]; oTable.Cell(i, 6).Range.Text = arac[j]; oTable.Cell(i, 7).Range.Text = pryd[j]; j++; }
                else if (i > tsatır + 4 && i <= tsatır + 2 + ysatır + 2) { oTable.Cell(i, 2).Range.Text = no[j]; oTable.Cell(i, 3).Range.Text = yeri[j]; oTable.Cell(i, 4).Range.Text = kriter[j]; oTable.Cell(i, 5).Range.Text = metod[j]; oTable.Cell(i, 6).Range.Text = arac[j]; oTable.Cell(i, 7).Range.Text = pryd[j]; j++; }
                else if (i > tsatır + ysatır + 6 && i <= tsatır + ysatır + ksatır + 6) { oTable.Cell(i, 2).Range.Text = no[j]; oTable.Cell(i, 3).Range.Text = yeri[j]; oTable.Cell(i, 4).Range.Text = kriter[j]; oTable.Cell(i, 5).Range.Text = metod[j]; oTable.Cell(i, 6).Range.Text = arac[j]; oTable.Cell(i, 7).Range.Text = pryd[j]; j++; }
            }

            for (int i = 3; i <= tsatır + ysatır + ksatır + 6; i++) { for (int k = 3; k < 7; k++) { if (i != tsatır + 3 && i != tsatır + 4 && i != tsatır + ysatır + 5 && i != tsatır + ysatır + 6) { oTable.Cell(i, k).VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter; oTable.Cell(i, k).Range.Paragraphs.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft; } } }
            for (int i = 3; i <= tsatır + ysatır + ksatır + 6; i++) { if (i != tsatır + 3 && i != tsatır + 4 && i != tsatır + ysatır + 5 && i != tsatır + ysatır + 6) { oTable.Cell(i, 7).VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter; oTable.Cell(i, 2).VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter; } }
            object EndPositon = 0;
            Microsoft.Office.Interop.Word.Range rngCrsr = oWordDoc.Range(ref EndPositon, ref EndPositon);
            rngCrsr.Select();
            oWordDoc.ActiveWindow.ActivePane.View.Type = Microsoft.Office.Interop.Word.WdViewType.wdPrintView;
            oWord.Visible = true;
        }
        /*
        private void exceleYaz(string adres)
        {
            Object Template = adres ;
            Excel.Application excel = new Excel.Application();
            Workbook workbook = excel.Workbooks.Add(Template);
            Worksheet sheet1 = (Worksheet)workbook.Sheets[1];
            excel.Visible = true;

            Range myRange1 = (Range)sheet1.Cells[5,3];
            myRange1.Value2 = makinaKoduTextBox.Text;
            Range myRange2 = (Range)sheet1.Cells[6,3];
            myRange2.Value2 = adTextBox.Text;
            Range myRange3 = (Range)sheet1.Cells[7,3];
            myRange3.Value2 = birmTextBox.Text;
            
            for (int i = 11; i < kolon2.Count+11 ; i++)
            {
                for (int j = 1; j <= 28; j++)
                {
                    switch (j)
	                {
		                case 1: Range myRange01 = (Range)sheet1.Cells[i,j]; myRange01.Value2 = (i-10).ToString(); break;
                        case 2: Range myRange02 = (Range)sheet1.Cells[i, j]; myRange02.Value2 = kolon2[i - 11]; break;//istanımı
                        case 4: Range myRange03 = (Range)sheet1.Cells[i, j]; myRange03.Value2 = kolon3[i - 11]; break;//bakımperiyodu
                        case 5: Range myRange04 = (Range)sheet1.Cells[i, j]; myRange04.Value2 = kolon4[i - 11]; break;//ocak
                        case 7: Range myRange05 = (Range)sheet1.Cells[i, j]; myRange05.Value2 = kolon5[i - 11]; break;//subat
                        case 9: Range myRange06 = (Range)sheet1.Cells[i, j]; myRange06.Value2 = kolon6[i - 11]; break;//mart
                        case 11: Range myRange07 = (Range)sheet1.Cells[i, j]; myRange07.Value2 = kolon7[i - 11]; break;//nisan
                        case 13: Range myRange08 = (Range)sheet1.Cells[i, j]; myRange08.Value2 = kolon8[i - 11]; break;//mayıs
                        case 15: Range myRange09 = (Range)sheet1.Cells[i, j]; myRange09.Value2 = kolon9[i - 11]; break;//haziran
                        case 17: Range myRange10 = (Range)sheet1.Cells[i, j]; myRange10.Value2 = kolon10[i - 11]; break;//temmuz
                        case 19: Range myRange11 = (Range)sheet1.Cells[i, j]; myRange11.Value2 = kolon11[i - 11]; break;//ağustos
                        case 21: Range myRange12 = (Range)sheet1.Cells[i, j]; myRange12.Value2 = kolon12[i - 11]; break;//eylül
                        case 23: Range myRange13 = (Range)sheet1.Cells[i, j]; myRange13.Value2 = kolon13[i - 11]; break;//ekim
                        case 25: Range myRange14 = (Range)sheet1.Cells[i, j]; myRange14.Value2 = kolon14[i - 11]; break;//kasm
                        case 27: Range myRange15 = (Range)sheet1.Cells[i, j]; myRange15.Value2 = kolon15[i - 11]; break;//aralık
	                }
                }
            }
        }
        */
        private void exceleSicilYaz(string adres)
        {
            Object Template = adres;
            Excel.Application excel = new Excel.Application();
            Workbook workbook = excel.Workbooks.Add(Template);
            Worksheet sheet1 = (Worksheet)workbook.Sheets[1];
            excel.Visible = true;

            Range myRange1 = (Range)sheet1.Cells[2, 3];
            myRange1.Value2 = makinaKoduTextBox.Text;
            Range myRange2 = (Range)sheet1.Cells[3, 3];
            myRange2.Value2 = adTextBox.Text;
            Range myRange3 = (Range)sheet1.Cells[1, 3];
            myRange3.Value2 = birmTextBox.Text;

            for (int i = 6; i < açıklama.Count*2 + 6; i+=2)
            {
                double a = (i - 5) / 2;
                int satırno = Convert.ToInt32(Math.Ceiling(a));
                for (int j = 1; j <= 9; j++)
                {
                    switch (j)
                    {
                        case 1: Range myRange01 = (Range)sheet1.Cells[i, j]; myRange01.Value2 = satırno.ToString(); break;
                        case 2: Range myRange02 = (Range)sheet1.Cells[i, j]; myRange02.Value2 = tarih[satırno - 1]; break;
                        case 3: Range myRange03 = (Range)sheet1.Cells[i, j]; myRange03.Value2 = bsaat[satırno - 1]; break;
                        case 4: if (tip[satırno - 1] == "Elektrik") { Range myRange04 = (Range)sheet1.Cells[i, j]; myRange04.Value2 = "X"; } else { Range myRange04 = (Range)sheet1.Cells[i, j + 1]; myRange04.Value2 = "X"; } break;
                        case 6: Range myRange05 = (Range)sheet1.Cells[i, j]; myRange05.Value2 = tanım[satırno - 1]; break;
                        case 7: Range myRange06 = (Range)sheet1.Cells[i, j]; myRange06.Value2 = sorumlu[satırno - 1]; break;
                        case 8: Range myRange07 = (Range)sheet1.Cells[i, j]; myRange07.Value2 = açıklama[satırno - 1]; break;
                        case 9: Range myRange08 = (Range)sheet1.Cells[i, j]; myRange08.Value2 = dsaati[satırno - 1]; break;
                    }
                }
            }
        }

        private void ciktiAl_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            komut = new SqlCommand("Select [Ekipman Kodu] From makinaListesi Where ID=" + makinaListesi.seciliID, Giris.baglanti);
            Giris.baglanti.Open(); dr = komut.ExecuteReader();
            while (dr.Read()) { makinaKoduTextBox.Text = dr.GetString(0); } dr.Close(); Giris.baglanti.Close();

            komut = new SqlCommand("Select Birim,Grup,Adı From makinaListesi Where [Ekipman Kodu]='" + makinaKoduTextBox.Text + "'", Giris.baglanti);
            Giris.baglanti.Open();
            dr = komut.ExecuteReader();

            while (dr.Read())
            {
                birmTextBox.Text = dr.GetString(0);
                grupTextBox.Text = dr.GetString(1);
                adTextBox.Text = dr.GetString(2);
            }
            dr.Close();
            Giris.baglanti.Close();
        }

    }
}
