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
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;

namespace WindowsFormsApplication1
{
    public partial class yedekleme : Form
    {
        public yedekleme()
        {
            InitializeComponent();
        }

        private void yedekleme_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            
        }

        public void BackupDatabase(String databaseName, String userName, String password, String serverName, String destinationPath)
        {
            //try
            //{
                ServerConnection connection = new ServerConnection(serverName, userName, password);
                Server sqlServer = new Server(connection);
                BackupDeviceItem deviceItem = new BackupDeviceItem(destinationPath, DeviceType.File);
                Backup sqlBackup = new Backup();
                sqlBackup.Devices.Add(deviceItem);
                sqlBackup.Action = BackupActionType.Database;
                sqlBackup.BackupSetDescription = "ArsivDataBase:" + DateTime.Now.ToShortDateString();
                sqlBackup.BackupSetName = DateTime.Today.ToString("YYYY.MM.DD") + " backup";
                sqlBackup.Database = databaseName;
                sqlBackup.Initialize = true;
                sqlBackup.Checksum = true;
                sqlBackup.ContinueAfterError = true;
                sqlBackup.Incremental = false;
                sqlBackup.ExpirationDate = DateTime.Now.AddDays(3);
                sqlBackup.LogTruncation = BackupTruncateLogType.Truncate;
                sqlBackup.FormatMedia = false;
                sqlBackup.SqlBackup(sqlServer);
                MessageBox.Show("Yedekleme oluşturuldu!");
            //}
            //catch (Exception) { MessageBox.Show("Yedekleme oluşturulamadı!"); }            
        }

        public void RestoreDatabase(String databaseName, String filePath, String serverName, String userName, String password, String dataFilePath)
        {
            String dataFileLocation = dataFilePath + databaseName + ".mdf";
            String logFileLocation = dataFilePath + databaseName + "_Log.ldf";
            BackupDeviceItem deviceItem = new BackupDeviceItem(filePath, DeviceType.File);
            ServerConnection connection = new ServerConnection(serverName, userName, password);
            Server sqlServer = new Server(connection);
            if (!sqlServer.Databases.Contains(databaseName))
            {
                sqlServer.Databases.Add(new Database(sqlServer, databaseName));
                sqlServer.Refresh();
            }

            Restore sqlRestore = new Restore();
            sqlRestore.Devices.Add(deviceItem);
            sqlRestore.Database = databaseName;
            sqlRestore.RelocateFiles.Add(new RelocateFile(databaseName, dataFileLocation));
            sqlRestore.RelocateFiles.Add(new RelocateFile(databaseName + "_log", logFileLocation));
            sqlRestore.ReplaceDatabase = true;
            sqlRestore.Action = RestoreActionType.Database;
            sqlRestore.SqlRestore(sqlServer);
        }

        private void yedekleButon_Click(object sender, EventArgs e)
        {
            BackupDatabase("basakBos","sa","bakım2016",".",@yedekleTextBox.Text);
        }

    }
}
