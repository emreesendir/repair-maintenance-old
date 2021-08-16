using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class filtrelemeSeçenekleri : Form
    {

        public filtrelemeSeçenekleri()
        {
            InitializeComponent();
        }

        private void filtrelemeSeçenekleri_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            birimlerCheckedListBox.Items.Clear(); gruplarCheckedListBox.Items.Clear(); kolonlarCheckedListBox.Items.Clear();

            for (int i = 0; i < makinaListesi.birimler.Count; i++) { birimlerCheckedListBox.Items.Add(makinaListesi.birimler[i]); }
            for (int i = 0; i < makinaListesi.gruplar.Count; i++) { gruplarCheckedListBox.Items.Add(makinaListesi.gruplar[i]); }
            for (int i = 0; i < makinaListesi.kolonlar.Count; i++) { kolonlarCheckedListBox.Items.Add(makinaListesi.kolonlar[i]); }

            for (int i = 0; i < birimlerCheckedListBox.Items.Count; i++)
            {
                for (int j = 0; j < makinaListesi.filtreBirimler.Count; j++)
                {
                    if (birimlerCheckedListBox.Items[i] == makinaListesi.filtreBirimler[j]) { birimlerCheckedListBox.SetItemChecked(i,true); }
                }
            }

            for (int i = 0; i < gruplarCheckedListBox.Items.Count; i++)
            {
                for (int j = 0; j < makinaListesi.filtreGruplar.Count; j++)
                {
                    if (gruplarCheckedListBox.Items[i] == makinaListesi.filtreGruplar[j]) { gruplarCheckedListBox.SetItemChecked(i, true); }
                }
            }

            for (int i = 0; i < kolonlarCheckedListBox.Items.Count; i++)
            {
                for (int j = 0; j < makinaListesi.filtreKolonlar.Count; j++)
                {
                    if (kolonlarCheckedListBox.Items[i] == makinaListesi.filtreKolonlar[j]) { kolonlarCheckedListBox.SetItemChecked(i, true); }
                }
            }

        }

        private void filtreleButon_Click(object sender, EventArgs e)
        {
            makinaListesi.filtreBirimler.Clear();
            for (int i = 0; i < birimlerCheckedListBox.Items.Count; i++) { if (birimlerCheckedListBox.GetItemChecked(i)) { makinaListesi.filtreBirimler.Add(Convert.ToString(birimlerCheckedListBox.Items[i])); } }
            makinaListesi.filtreGruplar.Clear();
            for (int i = 0; i < gruplarCheckedListBox.Items.Count; i++) { if (gruplarCheckedListBox.GetItemChecked(i)) { makinaListesi.filtreGruplar.Add(Convert.ToString(gruplarCheckedListBox.Items[i])); } }
            makinaListesi.filtreKolonlar.Clear();
            for (int i = 0; i < kolonlarCheckedListBox.Items.Count; i++) { if (kolonlarCheckedListBox.GetItemChecked(i)) { makinaListesi.filtreKolonlar.Add(Convert.ToString(kolonlarCheckedListBox.Items[i])); } }

            this.Close();
        }

        private void birimlerTümüCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (birimlerTümüCheckBox.Checked) { for (int i = 0; i < birimlerCheckedListBox.Items.Count; i++) { birimlerCheckedListBox.SetItemChecked(i, true); } }
            else { for (int i = 0; i < birimlerCheckedListBox.Items.Count; i++) { birimlerCheckedListBox.SetItemChecked(i, false); } }
        }

        private void gruplarTümüCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (gruplarTümüCheckBox.Checked) { for (int i = 0; i < gruplarCheckedListBox.Items.Count; i++) { gruplarCheckedListBox.SetItemChecked(i, true); } }
            else { for (int i = 0; i < gruplarCheckedListBox.Items.Count; i++) { gruplarCheckedListBox.SetItemChecked(i, false); } }
        }

        private void kolonlarTümüCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (kolonlarTümüCheckBox.Checked) { for (int i = 0; i < kolonlarCheckedListBox.Items.Count; i++) { kolonlarCheckedListBox.SetItemChecked(i, true); } }
            else { for (int i = 0; i < kolonlarCheckedListBox.Items.Count; i++) { kolonlarCheckedListBox.SetItemChecked(i, false); } }
        }
    }
}