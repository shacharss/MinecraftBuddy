using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MinecraftBuddy.KEYS;
using ShaderBuddy.LOGIC;


namespace ShaderBuddy.GUI
{
    public partial class OptifineForm : Form
    {
        // Variables
        private bool m_DownloadCompleted = false;

        // Labels
        private Label m_PickMinecraftVersionLabel;
        private Label m_DownloadOptifineLabel;
        private Label m_InstallOptifineLabel;

        // Buttons
        private Button m_DownloadOptifineButton;
        private Button m_InstallOptifineButton;
        private Button m_BackButton;

        // Dropdowns
        private ComboBox m_PickMinecraftVersionCombo;

        public OptifineForm()
        {
            initializeComponents();
            this.Text = "Optifine Installation";
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(m_DownloadOptifineButton.Right + 16, m_BackButton.Bottom + 8);
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

            m_PickMinecraftVersionCombo.SelectedValueChanged += updateDownloadOptifineButtonText;
            foreach (string version in Versions.sr_OptifineMinecraftVersions)
            {
                m_PickMinecraftVersionCombo.Items.Add(version);
            }

            this.Controls.Add(m_PickMinecraftVersionCombo);

            // Initialize download label
            m_DownloadOptifineLabel = new Label();
            m_DownloadOptifineLabel.Text = "3. Download Optifine: ";
            m_DownloadOptifineLabel.Top = m_PickMinecraftVersionLabel.Bottom + 16;
            m_DownloadOptifineLabel.Left = 16;
            m_DownloadOptifineLabel.Width = 125;
            this.Controls.Add(m_DownloadOptifineLabel);

            // Initialize download button
            m_DownloadOptifineButton = new Button();
            m_DownloadOptifineButton.Text = "Select Version";
            m_DownloadOptifineButton.Top = m_DownloadOptifineLabel.Top - (int)(0.25 * m_DownloadOptifineLabel.Height);
            m_DownloadOptifineButton.Left = m_PickMinecraftVersionCombo.Left;
            m_DownloadOptifineButton.Width = 150;
            m_DownloadOptifineButton.Click += downloadOptifineVersion;
            this.Controls.Add(m_DownloadOptifineButton);

            // Initialize install label
            m_InstallOptifineLabel = new Label();
            m_InstallOptifineLabel.Text = "4. Follow installation wizard:";
            m_InstallOptifineLabel.Top = m_DownloadOptifineLabel.Bottom + 16;
            m_InstallOptifineLabel.Left = 16;
            m_InstallOptifineLabel.Width = 160;
            this.Controls.Add(m_InstallOptifineLabel);

            // Initialize install button
            m_InstallOptifineButton = new Button();
            m_InstallOptifineButton.Text = "Open Optifine wizard";
            m_InstallOptifineButton.Width = 150;
            m_InstallOptifineButton.Left = m_DownloadOptifineButton.Right - m_InstallOptifineButton.Width;
            m_InstallOptifineButton.Top = m_InstallOptifineLabel.Top - (int)(0.25 * m_InstallOptifineButton.Height);
            m_InstallOptifineButton.Click += launchOptifine;
            this.Controls.Add(m_InstallOptifineButton);

            // Initialize back button
            m_BackButton = new Button();
            m_BackButton.Text = "Back";
            m_BackButton.Left = m_DownloadOptifineButton.Right - m_BackButton.Width;
            m_BackButton.Top = m_InstallOptifineLabel.Bottom + 8;
            m_BackButton.Click += backButtonCloseForm;
            this.Controls.Add(m_BackButton);

        }

        private void updateDownloadOptifineButtonText(object sender, EventArgs e)
        {
            m_DownloadOptifineButton.Text = "Download Optifine " + m_PickMinecraftVersionCombo.SelectedItem as string;
        }

        private void downloadOptifineVersion(object sender, EventArgs e)
        {
            string minecraftVersion = m_PickMinecraftVersionCombo.SelectedItem as string;
            if (minecraftVersion == null)
            {
                MessageBox.Show("Please select a Minecraft version first!");
            }
            else
            {
                OptifineDownloadForm download = new OptifineDownloadForm(minecraftVersion);
                download.ShowDialog();
                m_DownloadCompleted = true;
            }
        }

        private void launchOptifine(object sender, EventArgs e)
        {
            string minecraftVersion = m_PickMinecraftVersionCombo.SelectedItem as string;
            if (minecraftVersion == null)
            {
                MessageBox.Show("Please select a Minecraft version first!");
            }
            else if (m_DownloadCompleted == false)
            {
                MessageBox.Show("Please download Optifine first!");
            }
            else
            {
                this.Hide();
                OptifineInstallation.startOptifine();
                this.Show();
            }
        }

        private void backButtonCloseForm(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
