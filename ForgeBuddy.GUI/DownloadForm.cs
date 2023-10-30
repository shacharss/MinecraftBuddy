using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ForgeBuddy.LOGIC;
using System.Net;
using System.Threading;

namespace ForgeBuddy.GUI
{
    public partial class DownloadForm : Form
    {
        // Variables
        private readonly string r_MinecraftVersion;
        private readonly string r_ForgeVersion;
        private WebClient m_Client = new WebClient();

        // Labels
        private Label m_DownloadLabel;

        // Progress bars
        private ProgressBar m_ProgressBar;

        public DownloadForm(string io_MinecraftVersion, string io_ForgeVersion)
        {
            r_MinecraftVersion = io_MinecraftVersion;
            r_ForgeVersion = io_ForgeVersion;
            initializeComponents();
            this.Text = "Downloading...";
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.ClientSize = new System.Drawing.Size(m_ProgressBar.Right + 16, m_ProgressBar.Bottom + 16);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ShowInTaskbar = false;
            ForgeInstallation.DownloadForgeVersion(r_MinecraftVersion, r_ForgeVersion, m_Client);
            m_Client.DownloadProgressChanged += updateProgressBar;
            m_Client.DownloadFileCompleted += completeAndClose;
        }

        private void initializeComponents()
        {
            // Initialize download label
            m_DownloadLabel = new Label();
            m_DownloadLabel.Text = "Download %: 0.00";
            m_DownloadLabel.Top = 16;
            m_DownloadLabel.Left = 16;
            m_DownloadLabel.AutoSize = false;
            m_DownloadLabel.TextAlign = ContentAlignment.MiddleCenter;
            m_DownloadLabel.Size = new System.Drawing.Size(500, 30);
            this.Controls.Add(m_DownloadLabel);

            // Initialize download bar
            m_ProgressBar = new ProgressBar();
            m_ProgressBar.Top = m_DownloadLabel.Bottom;
            m_ProgressBar.Left = 16;
            m_ProgressBar.Width = 500;
            this.Controls.Add(m_ProgressBar);
        }

        private void updateProgressBar(object sender, DownloadProgressChangedEventArgs e)
        {

            double remainingBytes;
            double totalBytes;

            bool parseSucceeded = double.TryParse(e.BytesReceived.ToString(), out remainingBytes);
            parseSucceeded = double.TryParse(e.TotalBytesToReceive.ToString(), out totalBytes);

            double percentage = 100 * remainingBytes / totalBytes;
            m_DownloadLabel.Text = "Download %: " + percentage;
            m_ProgressBar.Value = int.Parse(Math.Truncate(percentage).ToString());
        }

        private void completeAndClose(object sender, EventArgs e)
        {
            m_ProgressBar.Value = 100;
            MessageBox.Show("Download Complete!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
