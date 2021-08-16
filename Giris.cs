using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace WindowsFormsApplication1
{
    public partial class Giris : Form
    {
        public static SqlConnection baglanti = new SqlConnection("Server=.; Database=basakBos; User Id=sa; password=bakım2016");
        SqlCommand komut;
        SqlDataReader dr;
        public static string kullanıcıAdı = "", yetki = "";

        public Giris()
        {
            InitializeComponent();
        }

        private void Giris_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            /*
            //HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Microsoft SQL Server\Instance Names
            //Eğer bu bilgisayarda SQL SERVER veya SQLSERVEREXPRESS sürümü yüklendi ise yukarıda regedit bölümünde yüklü SQL SERVER instance'leri yer alacaktır.           
            string[] yuklusqller = (string[])Registry.LocalMachine.OpenSubKey("Software").OpenSubKey("Microsoft").OpenSubKey("Microsoft SQL Server").GetValue("InstalledInstances");
            //Eğer kullanıcının bilgisayarında SQLExpress yüklü değilse
            var yukluozellikler = (from s in yuklusqller
                                   where s.Contains("SQLEXPRESS")
                                   select s).FirstOrDefault();
            if (yukluozellikler == null)
            {
                DialogResult sonuc = MessageBox.Show("Programı kullanabilmek için SQLEXPRESS yüklenmelidir. Yüklemek istiyor musunuz?", "UYARI", MessageBoxButtons.YesNo);
                if (sonuc == DialogResult.Yes)
                {
                    string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\SQLEXPR.exe";
                    Process p = new Process();
                    p.StartInfo.FileName = path;
                    //Aşağıdaki argumanları (parametreleri) SQLEXPRESS setup dosyama göndererek kurulumu başlatırsam kullanıcıya kurulum yeri v.s gibi bilgileri sormayacak ve doğrudan kuruluma geçecektir.
                    p.StartInfo.Arguments = "/qb INSTANCENAME=\".\" INSTALLSQLDIR=\"C:\\Program Files\\Microsoft SQL Server\" INSTALLSQLSHAREDDIR=\"C:\\Program Files\\Microsoft SQL Server\" INSTALLSQLDATADIR=\"C:\\Program Files\\Microsoft SQL Server\" ADDLOCAL=\"All\" SQLAUTOSTART=1 SQLBROWSERAUTOSTART=0 SQLBROWSERACCOUNT=\"NT AUTHORITY\\SYSTEM\" SQLACCOUNT=\"NT AUTHORITY\\SYSTEM\" SECURITYMODE=SQL SAPWD=\"\" SQLCOLLATION=\"SQL_Latin1_General_Cp1_CS_AS\" DISABLENETWORKPROTOCOLS=0 ERRORREPORTING=1 ENABLERANU=0 /SQLSVCACCOUNT=\"\".\\sa\"\" /SQLSVCPASSWORD=\"\"bakım2016\"\"\"";
                    //Process için pencere oluşturma.
                    p.StartInfo.CreateNoWindow = true;
                    //Process gizli çalışsın.
                    p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    p.Start();
                    //İşlem bitene kadar bekle
                    p.WaitForExit();

                    Giris.baglanti.Open();
                    komut.CommandText = "CREATE DATABASE basakBos ON (FILENAME = '" + Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "\\Basak- BOS v1.0\\DBImage\\basakBos.mdf" + "'),  (FILENAME = '" + Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "\\Basak- BOS v1.0\\DBImage\\basakBos_log.ldf" + "') FOR ATTACH";
                    komut.ExecuteNonQuery();
                    Giris.baglanti.Close();
                }
                else
                {
                    //Eğer SQLEXPRESS'i kurmak istemiyorsa programı sonlandırıyorum.
                    this.Close();
                }
            }*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            while (true)
            {
                kullanıcıGirisi sifreGiris = new kullanıcıGirisi();
                DialogResult diar = sifreGiris.ShowDialog();
                if (diar == DialogResult.Yes)
                {
                    if (kullanıcıGirisi.girisOnay) { anaMenu menu = new anaMenu(); menu.Show(); this.Hide();  break; }
                }
                else break;
            }
        }

        public static void kullanıcıCikisi()
        {
            sistemAyarları.kayitEkle(Giris.kullanıcıAdı, "Kullanıcı Çıkış Yaptı");
            kullanıcıAdı = "";
            yetki = "";
        }

        private void Giris_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
