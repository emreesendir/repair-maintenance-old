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
    public partial class isPlanıListeleme : Form
    {
        public static bool yenile = false;

        public isPlanıListeleme()
        {
            InitializeComponent();
        }

        private void isPlanıListeleme_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            pGosterCheckBox.Checked = isPlanı.pbakımen;
            dBakımCheckBox.Checked = isPlanı.dbakımen;
            yapilmamisCheckBox.Checked = isPlanı.bakımyapılmamis;
            ileriTarihDateTimePicker.Value = isPlanı.listetarihi;
        }

        private void pGosterCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (pGosterCheckBox.Checked) { yapilmamisCheckBox.Enabled = true; }
            else { yapilmamisCheckBox.Enabled = false; }
        }

        private void listeleButon_Click(object sender, EventArgs e)
        {
            isPlanı.pbakımen = pGosterCheckBox.Checked;
            isPlanı.dbakımen = dBakımCheckBox.Checked;
            isPlanı.bakımyapılmamis = yapilmamisCheckBox.Checked;
            isPlanı.listetarihi = ileriTarihDateTimePicker.Value;
            yenile = true;
            this.Close();
        }
    }
}
