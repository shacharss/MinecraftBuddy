using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ForgeBuddy.LOGIC;
using ForgeBuddy.KEYS;

namespace ForgeBuddy.GUI
{
    public partial class ForgeForm : Form
    {
        // Variables
        private bool m_DownloadCompleted = false;

        // Labels
        private Label m_PickMinecraftVersionLabel;
        private Label m_PickForgeVersionLabel;
        private Label m_DownloadForgeLabel;
        private Label m_InstallForgeLabel;

        // Buttons
        private Button m_DownloadForgeButton;
        private Button m_InstallForgeButton;
        private Button m_BackButton;

        // Dropdowns
        private ComboBox m_PickMinecraftVersionCombo;
        private ComboBox m_PickForgeVersionCombo;

        public ForgeForm()
        {
            initializeComponents();
            this.Text = "Forge Installation";
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(m_DownloadForgeButton.Right + 16, m_BackButton.Bottom + 8);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ShowInTaskbar = false;
        }
        private void initializeComponents()
        {
            // Initialize Minecraft version label
            m_PickMinecraftVersionLabel = new Label();
            m_PickMinecraftVersionLabel.Text = "1. Pick Minecraft version:";
            m_PickMinecraftVersionLabel.Top = 16;
            m_PickMinecraftVersionLabel.Left = 16;
            m_PickMinecraftVersionLabel.Width = 150;
            this.Controls.Add(m_PickMinecraftVersionLabel);

            // Initialize Minecraft version dropdown
            m_PickMinecraftVersionCombo = new ComboBox();
            m_PickMinecraftVersionCombo.Text = "Pick Minecraft version";
            m_PickMinecraftVersionCombo.Left = m_PickMinecraftVersionLabel.Right + 32;
            m_PickMinecraftVersionCombo.Top = m_PickMinecraftVersionLabel.Top - (int)(0.25 * m_PickMinecraftVersionLabel.Height);
            m_PickMinecraftVersionCombo.Width = 150;
            m_PickMinecraftVersionCombo.MaxLength = 11;
            m_PickMinecraftVersionCombo.MaxDropDownItems = 7;
            m_PickMinecraftVersionCombo.IntegralHeight = false;

            m_PickMinecraftVersionCombo.SelectedValueChanged += updateDownloadForgeButtonText;
            foreach (string version in Versions.sr_ListMinecraftVersions)
            {
                m_PickMinecraftVersionCombo.Items.Add(version);
            }

            this.Controls.Add(m_PickMinecraftVersionCombo);

            // Initialize Forge version label
            m_PickForgeVersionLabel = new Label();
            m_PickForgeVersionLabel.Text = "2. Pick Forge version:";
            m_PickForgeVersionLabel.Top = m_PickMinecraftVersionLabel.Bottom + 16;
            m_PickForgeVersionLabel.Left = 16;
            m_PickForgeVersionLabel.Width = 150;
            this.Controls.Add(m_PickForgeVersionLabel);

            // Initialize Forge version dropdown
            m_PickForgeVersionCombo = new ComboBox();
            m_PickForgeVersionCombo.Text = "Pick Forge version";
            m_PickForgeVersionCombo.Top = m_PickForgeVersionLabel.Top - (int)(0.25 * m_PickForgeVersionLabel.Height);
            m_PickForgeVersionCombo.Left = m_PickForgeVersionLabel.Right + 32;
            m_PickForgeVersionCombo.Width = 150;
            m_PickForgeVersionCombo.MaxLength = 11;
            m_PickForgeVersionCombo.MaxDropDownItems = 2;
            m_PickForgeVersionCombo.IntegralHeight = false;
            m_PickForgeVersionCombo.Items.Add("Latest");
            m_PickForgeVersionCombo.Items.Add("Recommended");
            this.Controls.Add(m_PickForgeVersionCombo);

            // Initialize download label
            m_DownloadForgeLabel = new Label();
            m_DownloadForgeLabel.Text = "3. Download forge: ";
            m_DownloadForgeLabel.Top = m_PickForgeVersionLabel.Bottom + 16;
            m_DownloadForgeLabel.Left = 16;
            m_DownloadForgeLabel.Width = 125;
            this.Controls.Add(m_DownloadForgeLabel);

            // Initialize download button
            m_DownloadForgeButton = new Button();
            m_DownloadForgeButton.Text = "Select Version";
            m_DownloadForgeButton.Top = m_DownloadForgeLabel.Top - (int)(0.25 * m_DownloadForgeLabel.Height);
            m_DownloadForgeButton.Left = m_PickMinecraftVersionCombo.Left;
            m_DownloadForgeButton.Width = 150;
            m_DownloadForgeButton.Click += downloadForgeVersion;
            this.Controls.Add(m_DownloadForgeButton);

            // Initialize install label
            m_InstallForgeLabel = new Label();
            m_InstallForgeLabel.Text = "4. Follow installation wizard:";
            m_InstallForgeLabel.Top = m_DownloadForgeLabel.Bottom + 16;
            m_InstallForgeLabel.Left = 16;
            m_InstallForgeLabel.Width = 160;
            this.Controls.Add(m_InstallForgeLabel);

            // Initialize install button
            m_InstallForgeButton = new Button();
            m_InstallForgeButton.Text = "Open Forge wizard";
            m_InstallForgeButton.Width = 150;
            m_InstallForgeButton.Left = m_DownloadForgeButton.Right - m_InstallForgeButton.Width;
            m_InstallForgeButton.Top = m_InstallForgeLabel.Top - (int)(0.25 * m_InstallForgeButton.Height);
            m_InstallForgeButton.Click += launchForge;
            this.Controls.Add(m_InstallForgeButton);

            // Initialize back button
            m_BackButton = new Button();
            m_BackButton.Text = "Back";
            m_BackButton.Left = m_DownloadForgeButton.Right - m_BackButton.Width;
            m_BackButton.Top = m_InstallForgeLabel.Bottom + 8;
            m_BackButton.Click += backButtonCloseForm;
            this.Controls.Add(m_BackButton);

        }

        private void updateDownloadForgeButtonText(object sender, EventArgs e)
        {
            m_DownloadForgeButton.Text = "Download Forge " + m_PickMinecraftVersionCombo.SelectedItem as string;
        }

        private void downloadForgeVersion(object sender, EventArgs e)
        {
            string minecraftVersion = m_PickMinecraftVersionCombo.SelectedItem as string;
            string forgeVersion = m_PickForgeVersionCombo.SelectedItem as string;
            if (minecraftVersion == null)
            {
                MessageBox.Show("Please select a Minecraft version first!");
            }
            else if (forgeVersion == null)
            {
                MessageBox.Show("Please select a Forge version first!");
            }
            else
            {
                DownloadForm download = new DownloadForm(minecraftVersion, forgeVersion);
                download.ShowDialog();
                m_DownloadCompleted = true;
            }
        }

        private void launchForge(object sender, EventArgs e)
        {
            string minecraftVersion = m_PickMinecraftVersionCombo.SelectedItem as string;
            string forgeVersion = m_PickForgeVersionCombo.SelectedItem as string;
            if (minecraftVersion == null)
            {
                MessageBox.Show("Please select a Minecraft version first!");
            }
            else if (forgeVersion == null)
            {
                MessageBox.Show("Please select a Forge version first!");
            }
            else if (m_DownloadCompleted == false)
            {
                MessageBox.Show("Please download forge first!");
            }
            else
            {
                this.Hide();
                ForgeInstallation.startForge();
                this.Show();
            }
        }

        private void backButtonCloseForm(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
