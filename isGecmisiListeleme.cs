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
    public partial class isGecmisiListeleme : Form
    {
        SqlCommand komut;
        SqlDataReader dr;

        public static bool yenile = false;

        public isGecmisiListeleme()
        {
            InitializeComponent();
        }

        private void isGecmisiListeleme_Load(object sender, EventArgs e)
        {
            yenile = true;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            ilkDateTimePicker.Value = isGecmisi.ilkTarih;
            sonDateTimePicker.Value = isGecmisi.sonTarih;

            for (int i = 0; i < isGecmisi.atölyeler.Count; i++) { atölyeCheckedListBox.Items.Add(isGecmisi.atölyeler[i]); }
            for (int i = 0; i < isGecmisi.türler.Count; i++) { islemTürüCheckedListBox.Items.Add(isGecmisi.türler[i]); }

            for (int i = 0; i < atölyeCheckedListBox.Items.Count; i++)
            {
                for (int j = 0; j < isGecmisi.filtreAtölyeler.Count; j++)
                {
                    if (atölyeCheckedListBox.Items[i] == isGecmisi.filtreAtölyeler[j]) { atölyeCheckedListBox.SetItemChecked(i, true); }
                }
            }

            for (int i = 0; i < islemTürüCheckedListBox.Items.Count; i++)
            {
                for (int j = 0; j < isGecmisi.filtreTürler.Count; j++)
                {
                    if (islemTürüCheckedListBox.Items[i] == isGecmisi.filtreTürler[j]) { islemTürüCheckedListBox.SetItemChecked(i, true); }
                }
            }
            string seciliEkipmanKodu = "";
            ekipmanCheckBox.Checked = isGecmisi.ekipmanAtölyeModu;
            tarihTümüCheckBox.Checked = !isGecmisi.tarihModu;
            if (isGecmisi.seciliEkipmanID != "")
            {
                komut = new SqlCommand("Select [Ekipman Kodu] From makinaListesi Where ID=" + isGecmisi.seciliEkipmanID, Giris.baglanti);
                Giris.baglanti.Open(); dr = komut.ExecuteReader();
                while (dr.Read()) { seciliEkipmanKodu = dr.GetString(0); } dr.Close(); Giris.baglanti.Close();
                if (ekipmanCheckBox.Checked) { ekipmanKoduTextBox.Text = seciliEkipmanKodu; araButon.PerformClick(); }
            }

            if (ekipmanCheckBox.Checked) { atölyePanel.Enabled = false; ekipmanPanel.Enabled = true; isGecmisi.ekipmanAtölyeModu = true; }
            else { atölyePanel.Enabled = true; ekipmanPanel.Enabled = false; isGecmisi.ekipmanAtölyeModu = false; }
            if (tarihTümüCheckBox.Checked) { isGecmisi.tarihModu = false; ilkDateTimePicker.Enabled = false; sonDateTimePicker.Enabled = false; }
            else { isGecmisi.tarihModu = true; ilkDateTimePicker.Enabled = true; sonDateTimePicker.Enabled = true; }
        }

        private void listeleButon_Click(object sender, EventArgs e)
        {
            if (!tarihTümüCheckBox.Checked)
            {
                if (sonDateTimePicker.Value.Subtract(ilkDateTimePicker.Value).Days >= 0 && sonDateTimePicker.Value <= DateTime.Now)
                {
                    isGecmisi.ilkTarih = ilkDateTimePicker.Value;
                    isGecmisi.sonTarih = sonDateTimePicker.Value;
                }
                else { MessageBox.Show("İşlem gerçekleştirilemedi girdiğiniz tarih değerlerini kontrol ediniz!"); yenile = false; this.Close(); }
            }

            if (ekipmanCheckBox.Checked)
            {
                if (birimTextBox.Text != "")
                {
                    komut = new SqlCommand("Select ID From makinaListesi Where [Ekipman Kodu]='" + ekipmanKoduTextBox.Text + "'", Giris.baglanti);
                    Giris.baglanti.Open(); dr = komut.ExecuteReader();
                    while (dr.Read()) { isGecmisi.seciliEkipmanID = dr.GetInt32(0).ToString(); } dr.Close(); Giris.baglanti.Close();
                }
                else { MessageBox.Show("Geçersiz Ekipman!"); yenile = false; this.Close(); }
            }
            else
            {
                isGecmisi.filtreAtölyeler.Clear();
                for (int i = 0; i < atölyeCheckedListBox.Items.Count; i++) { if (atölyeCheckedListBox.GetItemChecked(i)) { isGecmisi.filtreAtölyeler.Add(Convert.ToString(atölyeCheckedListBox.Items[i])); } }
            }

            isGecmisi.filtreTürler.Clear();
            for (int i = 0; i < islemTürüCheckedListBox.Items.Count; i++) { if (islemTürüCheckedListBox.GetItemChecked(i)) { isGecmisi.filtreTürler.Add(Convert.ToString(islemTürüCheckedListBox.Items[i])); } }
            this.Close();
        }

        private void ekipmanCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (ekipmanCheckBox.Checked) { atölyePanel.Enabled = false; ekipmanPanel.Enabled = true; isGecmisi.ekipmanAtölyeModu = true; }
            else { atölyePanel.Enabled = true; ekipmanPanel.Enabled = false; isGecmisi.ekipmanAtölyeModu = false; }
        }

        private void tarihTümüCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (tarihTümüCheckBox.Checked) { isGecmisi.tarihModu = false; ilkDateTimePicker.Enabled = false; sonDateTimePicker.Enabled = false; }
            else { isGecmisi.tarihModu = true; ilkDateTimePicker.Enabled = true; sonDateTimePicker.Enabled = true; }
        }

        private void araButon_Click(object sender, EventArgs e)
        {
            if (ekipmanKoduTextBox.Text != "")
            {
                komut = new SqlCommand("Select Birim,Adı,Grup From makinaListesi Where [Ekipman Kodu]='" + ekipmanKoduTextBox.Text + "'", Giris.baglanti);
                Giris.baglanti.Open(); dr = komut.ExecuteReader();
                while (dr.Read()) { birimTextBox.Text = dr.GetString(0); ekipmanAdıTextBox.Text = dr.GetString(1); grupTextBox.Text = dr.GetString(2); } dr.Close(); Giris.baglanti.Close();
                if (birimTextBox.Text == "") { MessageBox.Show("Geçersiz Ekipman Kodu!"); }
            }
            else { MessageBox.Show("Ekipman Kodu Giriniz!"); }
        }

        private void atölyeTümüCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (atölyeTümüCheckBox.Checked) { for (int i = 0; i < atölyeCheckedListBox.Items.Count; i++) { atölyeCheckedListBox.SetItemChecked(i, true); } }
            else { for (int i = 0; i < atölyeCheckedListBox.Items.Count; i++) { atölyeCheckedListBox.SetItemChecked(i, false); } }
        }

        private void islemTürüTümüCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (islemTürüTümüCheckBox.Checked) { for (int i = 0; i < islemTürüCheckedListBox.Items.Count; i++) { islemTürüCheckedListBox.SetItemChecked(i, true); } }
            else { for (int i = 0; i < islemTürüCheckedListBox.Items.Count; i++) { islemTürüCheckedListBox.SetItemChecked(i, false); } }
        }

        private void ekipmanKoduTextBox_TextChanged(object sender, EventArgs e)
        {
            birimTextBox.Clear(); grupTextBox.Clear(); ekipmanAdıTextBox.Clear();
        }
    }
}
