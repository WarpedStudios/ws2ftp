using System.Diagnostics;
using WinSCP;
using System.Net;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
//ALSO USES WINDOWS FORMS

namespace ws2ftp_2022
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // REQURED WHEN NOT USING WINSCP .NET LIBRARIES
            var webClient = new WebClient();
            string cdnDir = @"C:\...";
            string wscomPath = @"C:\...\WinSCP.com";
            string wsexePath = @"C:\...\WinSCP.exe";
            if (!System.IO.Directory.Exists(cdnDir))
            {
                System.IO.Directory.CreateDirectory(cdnDir);
            }
            if (!System.IO.File.Exists(wscomPath))
            {
                webClient.DownloadFile("http://DOWNLOADLOCATION/WinSCP.com", wscomPath);
            }
            if (!System.IO.File.Exists(wsexePath))
            {
                webClient.DownloadFile("http://DOWNLOADLOCATION/WinSCP.exe", wsexePath);
            }
            // DO NOT NEED AS PRIVATE KEY FILE NOT USED TO AUTHENTICATE
            //string cdnKey = @"C:\...\KEY.ppk";
            //if (System.IO.File.Exists(cdnKey))
            //{
            //    System.IO.File.Delete(cdnKey);
            //}
            //using (StreamWriter sr = File.AppendText(cdnKey))
            //{
            //    sr.WriteLine("PRIVATE KEY SHA-256");
            //    sr.Close();
            //}
            //if (!System.IO.File.Exists(cdnKey))
            //{
            //    using (StreamWriter sr = File.AppendText(cdnKey))
            //    {
            //        sr.WriteLine("PRIVATE KEY SHA-256");
            //       sr.Close();
            //    }
            //}
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string savePath = @"C:\...\tmp_filePath.txt";
            using OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = @"C:\";
            openFileDialog.Filter = "All files (*.*)|*.*";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = (openFileDialog.FileName);
                if (System.IO.File.Exists(savePath))
                {
                    System.IO.File.Delete(savePath);
                    using (StreamWriter sr = File.AppendText(savePath))
                    {
                        sr.WriteLine(openFileDialog.FileName);
                    }
                }
                if (!System.IO.File.Exists(savePath))
                {
                    using (StreamWriter sr = File.AppendText(savePath))
                    {
                        sr.WriteLine(openFileDialog.FileName);
                    }
                }
            }
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            //WINSCP .NET CODE BELOW
            //textBox2.Text = "";
            //string tmpSavePath = @"C:\...\tmp_filePath.txt";
            //string filePath = (File.ReadAllText(tmpSavePath));
            //textBox2.Text = filePath;
            //if (textBox2.Text.Length > 0)
            //{
            //    textBox2.AppendText(Environment.NewLine);
            //    textBox2.AppendText("Upload started for " + filePath);
            //}
            //try
            //{
            //    SessionOptions sessionOptions = new SessionOptions
            //    {
            //        Protocol = Protocol.Scp,
            //        HostName = "IP",
            //        UserName = "USERNAME",
            //        Password = "HASHPASSWORD",
            //        SshHostKeyFingerprint = "SSHFINGERPRINT"
            //    };
            //    using (Session session = new Session())
            //    {
            //        session.Open(sessionOptions);
            //        TransferOptions transferOptions = new TransferOptions();
            //        transferOptions.TransferMode = TransferMode.Binary;
            //        TransferOperationResult transferResult;
            //        transferResult = session.PutFiles($"{filePath}", "REMOTEPATH/*.*", false, (transferOptions));
            //        transferResult.Check();
            //        foreach (TransferEventArgs transfer in transferResult.Transfers)
            //        {
            //            textBox2.Text = "Success: {0}" + (transfer.FileName);
            //        }
            //    }
            //}
            //catch
            //{
            //    textBox2.Text = "Error: {1}" + filePath;
            //}
            string wscomPath = "C:\\...\\WinSCP.com";
            string tmpSavePath = @"C:\...\tmp_filePath.txt";
            string filePath = (File.ReadAllText(tmpSavePath));
            string cdnHost = @"IP";
            string cdnUsr = "USERNAME";
            string cdnPass = @"HASHPASSWORD";
            string currentTime = DateTime.Now.ToString("yyyy-MM-d-HH-m-s");
            string tmpScript = @"C:\...\upload_" + currentTime + ".script";
            using (StreamWriter sr = File.AppendText(tmpScript))
            {
                sr.WriteLine(@"open scp://" + cdnUsr + ":" + cdnPass + "@" + cdnHost + "\n" +
                    "cd /REMOTEDIRECTORY/.../ \n" +
                    "put " + (File.ReadAllText(tmpSavePath)) + "\n" +
                    "ls\n" +
                    "close\n" +
                    "pause\n" +
                    "end");
                sr.Close();
            }
            ProcessStartInfo ProcessInfo;
            ProcessInfo = new ProcessStartInfo(wscomPath, " /script=" + (tmpScript));
            ProcessInfo.CreateNoWindow = true;
            ProcessInfo.UseShellExecute = true;
            _ = Process.Start(ProcessInfo);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            string wscomPath = "C:\\...\\WinSCP.com";
            string tmpSavePath = @"C:\...\tmp_filePath.txt";
            string filePath = (File.ReadAllText(tmpSavePath));
            string cdnHost = @"IP";
            string cdnUsr = "USERNAME";
            string cdnPass = @"HASHPASSWORD";
            string currentTime = DateTime.Now.ToString("yyyy-MM-d-HH-m-s");
            string tmpScript = @"C:\...\upload_" + currentTime + ".script";
            using (StreamWriter sr = File.AppendText(tmpScript))
            {
                sr.WriteLine(@"open scp://" + cdnUsr + ":" + cdnPass + "@" + cdnHost + "\n" +
                    "cd /REMOTEDIRECTORY/.../ \n" +
                    "put " + (File.ReadAllText(tmpSavePath)) + "\n" +
                    "ls\n" +
                    "close\n" +
                    "pause\n" +
                    "end");
                sr.Close();
            }
            ProcessStartInfo ProcessInfo;
            ProcessInfo = new ProcessStartInfo(wscomPath, " /script=" + (tmpScript));
            ProcessInfo.CreateNoWindow = true;
            ProcessInfo.UseShellExecute = true;
            _ = Process.Start(ProcessInfo);
            //textBox2.Text = "";
            //string tmpSavePath = @"C:\...\tmp_filePath.txt";
            //string filePath = (File.ReadAllText(tmpSavePath));
            //if (textBox2.Text.Length > 0)
            //{
            //    textBox2.AppendText(Environment.NewLine);
            //    textBox2.AppendText("Upload started for " + filePath);
            //}
            //try
            //{
            //    SessionOptions sessionOptions = new SessionOptions
            //    {
            //        Protocol = Protocol.Scp,
            //        HostName = "IP",
            //        UserName = "USERNAME",
            //        Password = "HASHPASSWORD",
            //        SshHostKeyFingerprint = "SSHFINGERPRINT"
            //    };
            //    using (Session session = new Session())
            //    {
            //        session.Open(sessionOptions);
            //        TransferOptions transferOptions = new TransferOptions();
            //        transferOptions.TransferMode = TransferMode.Binary;
            //        TransferOperationResult transferResult;
            //        transferResult = session.PutFiles(filePath, "/REMOTEDIRECTORY/*.*", false, transferOptions);
            //        transferResult.Check();
            //        foreach (TransferEventArgs transfer in transferResult.Transfers)
            //        {
            //            textBox2.Text = "Success: {1}" + (transfer.FileName);
            //        }
            //    }
            //}
            //catch
            //{
            //    textBox2.Text = "Error: {0}";
            //}
        }
        private void button3_Click(object sender, EventArgs e)
        {
            string wscomPath = "C:\\...\\WinSCP.com";
            string tmpSavePath = @"C:\...\tmp_filePath.txt";
            string filePath = (File.ReadAllText(tmpSavePath));
            string cdnHost = @"IP";
            string cdnUsr = "USERNAME";
            string cdnPass = @"HASHPASSWORD";
            string currentTime = DateTime.Now.ToString("yyyy-MM-d-HH-m-s");
            string tmpScript = @"C:\...\upload_" + currentTime + ".script";
            using (StreamWriter sr = File.AppendText(tmpScript))
            {
                sr.WriteLine(@"open scp://" + cdnUsr + ":" + cdnPass + "@" + cdnHost + "\n" +
                    "cd /REMOTEDIRECTORY/.../ \n" +
                    "put " + (File.ReadAllText(tmpSavePath)) + "\n" +
                    "ls\n" +
                    "close\n" +
                    "pause\n" +
                    "end");
                sr.Close();
            }
            ProcessStartInfo ProcessInfo;
            ProcessInfo = new ProcessStartInfo(wscomPath, " /script=" + (tmpScript));
            ProcessInfo.CreateNoWindow = true;
            ProcessInfo.UseShellExecute = true;
            _ = Process.Start(ProcessInfo);
            textBox2.Text = "This textbox and progress bar below will be used in the next version of ws2ftp utilizing the WinSCP .NET library.";
            //textBox2.Text = "";
            //string tmpSavePath = @"C:\...\tmp_filePath.txt";
            //string filePath = (File.ReadAllText(tmpSavePath));
            //if (textBox2.Text.Length > 0)
            //{
            //    textBox2.AppendText(Environment.NewLine);
            //    textBox2.AppendText("Upload started for " + filePath);
            //}
            //try
            //{
            //    SessionOptions sessionOptions = new SessionOptions
            //    {
            //        Protocol = Protocol.Scp,
            //        HostName = "IP",
            //        UserName = "USERNAME",
            //        Password = "HASHPASSWORD",
            //        SshHostKeyFingerprint = "SSHFINGERPRINT"
            //    };
            //    using (Session session = new Session())
            //    {
            //        session.Open(sessionOptions);
            //        TransferOptions transferOptions = new TransferOptions();
            //        transferOptions.TransferMode = TransferMode.Binary;
            //        TransferOperationResult transferResult;
            //        transferResult = session.PutFiles(filePath, "/REMOTEDIRECTORY/*.*", false, transferOptions);
            //        transferResult.Check();
            //        foreach (TransferEventArgs transfer in transferResult.Transfers)
            //        {
            //            textBox2.Text = "Success: {1}" + (transfer.FileName);
            //        }
            //    }
            //}
            //catch
            //{
            //    textBox2.Text = "Error: {0}";
            //}
        }
        private void label6_Click(object sender, EventArgs e)
        { }
        private void pictureBox1_Click(object sender, EventArgs e)
        { }
        private void textBox2_TextChanged(object sender, EventArgs e)
        { }
        private void progressBar1_Click(object sender, EventArgs e)
        { }
        private void label1_Click(object sender, EventArgs e)
        { }
        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        { }
        private void label3_Click(object sender, EventArgs e)
        { }
        private void Form1_Load(object sender, EventArgs e)
        { }
        private void textBox1_TextChanged(object sender, EventArgs e)
        { }
        private void label5_Click(object sender, EventArgs e)
        { }
        private void Form1_Load_1(object sender, EventArgs e)
        { }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", "https://twitter.com/warpedlive");
        }
    }
}
