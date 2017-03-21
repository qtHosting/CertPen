using Microsoft.Win32;
using System.Diagnostics;
using System.Windows;

namespace CertPen
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private string strPassword = Properties.Settings.Default.Password;
        private string strCodeSignTool = Properties.Settings.Default.CodeSignTool;
        private string strCertPath = Properties.Settings.Default.CertPath;
        private string strTimeStamp = Properties.Settings.Default.TimeStamp;

        public MainWindow()
        {
            InitializeComponent();
            passwordBox.Password = strPassword;
            signTool.Text = strCodeSignTool;
            certBox.Text = strCertPath;
            timeStamp.Text = strTimeStamp;
        }

        private void CertPathButtonClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            bool? blnResult = ofd.ShowDialog();

            if(blnResult ?? true)
            {
                certBox.Text = ofd.FileName;
            }
        }

        private void SignCodeButtonClick(object sender, RoutedEventArgs e)
        {
            string strCert = certBox.Text;
            string strCodePath = codePath.Text;
            string strTimeStamp = timeStamp.Text;
            string strPassword = passwordBox.Password;
            string strSignTool = signTool.Text;

            string strAlert = "\"" + strSignTool + "\" sign /f \"" + strCert + "\" /p " + strPassword + " /t " + strTimeStamp + " /v \"" + strCodePath + "\"";

            Process cmd = new Process();
            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.CreateNoWindow = true;
            cmd.StartInfo.UseShellExecute = false;

            cmd.Start();

            cmd.StandardInput.WriteLine(strAlert);
            cmd.StandardInput.Flush();
            cmd.StandardInput.Close();
            string strMessage = cmd.StandardOutput.ReadToEnd();
            MessageBox.Show(strMessage);
        }

        private void CodePathButtonClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            bool? blnResult = ofd.ShowDialog();

            if (blnResult ?? true)
            {
                codePath.Text = ofd.FileName;
            }
            
        }

        private void SelectSignToolButton(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            bool? blnResult = ofd.ShowDialog();

            if(blnResult ?? true)
            {
                signTool.Text = ofd.FileName;
            }
        }

        private void SaveSettingsButtonClick(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.Password = passwordBox.Password;
            Properties.Settings.Default.CodeSignTool = signTool.Text;
            Properties.Settings.Default.CertPath = certBox.Text;
            Properties.Settings.Default.TimeStamp = timeStamp.Text;
            Properties.Settings.Default.Save();
            MessageBox.Show("Settings saved!");
        }
    }
}
