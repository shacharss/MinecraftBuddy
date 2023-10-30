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
using ResourceBuddy.LOGIC;

namespace ResourceBuddy.GUI
{
    public partial class ResourceMenuForm : Form
    {
        // Variables
        private bool m_VersionPicked = false;
        private bool m_InformationReceived = false;
        private bool[] m_ChosenResourceCategories = new bool[16];

        // Labels
        private Label m_PickMinecraftVersionLabel;
        private Label m_ChooseResourceCategoriesLabel;
        private Label m_ChooseResourcePackLabel;
        private Label m_UploadResourcePackLabel;

        // Buttons
        private Button m_ChooseResourceCategoriesButton;
        private Button m_ChooseResourcePackButton;
        private Button m_UploadResourcePackButton;
        private Button m_BackButton;

        // Dropdowns
        private ComboBox m_PickMinecraftVersionCombo;

        public ResourceMenuForm()
        {
            initializeComponents();
            this.Text = "ResourceBuddy";
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(m_PickMinecraftVersionCombo.Right + 16, m_BackButton.Bottom + 8);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ShowInTaskbar = false;
        }

        private void initializeComponents()
        {
            // Initialize pick Minecraft version label
            m_PickMinecraftVersionLabel = new Label();
            m_PickMinecraftVersionLabel.Text = "1. Pick Minecraft Version:";
            m_PickMinecraftVersionLabel.Top = 16;
            m_PickMinecraftVersionLabel.Left = 16;
            m_PickMinecraftVersionLabel.Width = 150;
            this.Controls.Add(m_PickMinecraftVersionLabel);

            // Initialize pick Minecraft version dropdown
            m_PickMinecraftVersionCombo = new ComboBox();
            m_PickMinecraftVersionCombo.Text = "Pick Minecraft version";
            m_PickMinecraftVersionCombo.Left = m_PickMinecraftVersionLabel.Right + 32;
            m_PickMinecraftVersionCombo.Top = m_PickMinecraftVersionLabel.Top - (int)(0.25 * m_PickMinecraftVersionLabel.Height);
            m_PickMinecraftVersionCombo.Width = 200;
            m_PickMinecraftVersionCombo.MaxLength = 11;
            m_PickMinecraftVersionCombo.MaxDropDownItems = 7;
            m_PickMinecraftVersionCombo.IntegralHeight = false;

            m_PickMinecraftVersionCombo.SelectedValueChanged += updateChooseResourcePackButtonText;
            m_PickMinecraftVersionCombo.Items.Add(Versions.sr_AllVersion);
            foreach (string version in Versions.sr_ListMinecraftVersions)
            {
                if (version != "1.7.10_pre4")
                {
                    m_PickMinecraftVersionCombo.Items.Add(version);
                }
            }

            this.Controls.Add(m_PickMinecraftVersionCombo);

            // Initialize choose resource categories label
            m_ChooseResourceCategoriesLabel = new Label();
            m_ChooseResourceCategoriesLabel.Text = "1.5. Choose Resource Pack Categories";
            m_ChooseResourceCategoriesLabel.Top = m_PickMinecraftVersionLabel.Bottom + 16;
            m_ChooseResourceCategoriesLabel.Left = 32;
            m_ChooseResourceCategoriesLabel.Width = 150;
            this.Controls.Add(m_ChooseResourceCategoriesLabel);

            // Intialize choose resource categories button
            m_ChooseResourceCategoriesButton = new Button();
            m_ChooseResourceCategoriesButton.Text = "Choose Resource Pack Categories";
            m_ChooseResourceCategoriesButton.Top = m_PickMinecraftVersionCombo.Bottom + 16;
            m_ChooseResourceCategoriesButton.Left = m_PickMinecraftVersionCombo.Left;
            m_ChooseResourceCategoriesButton.Width = 200;
            m_ChooseResourceCategoriesButton.Click += openResourcePackCategoriesForm;
            this.Controls.Add(m_ChooseResourceCategoriesButton);

            // Initialize choose resource pack label
            m_ChooseResourcePackLabel = new Label();
            m_ChooseResourcePackLabel.Text = "2. Choose Resource Pack:";
            m_ChooseResourcePackLabel.Top = m_ChooseResourceCategoriesLabel.Bottom + 16;
            m_ChooseResourcePackLabel.Left = 16;
            m_ChooseResourcePackLabel.Width = 150;
            this.Controls.Add(m_ChooseResourcePackLabel);

            // Initialize choose resource pack button
            m_ChooseResourcePackButton = new Button();
            m_ChooseResourcePackButton.Text = "Find resource packs";
            m_ChooseResourcePackButton.Top = m_ChooseResourceCategoriesButton.Bottom + 16;
            m_ChooseResourcePackButton.Left = m_ChooseResourcePackLabel.Right + 32;
            m_ChooseResourcePackButton.Width = 200;
            m_ChooseResourcePackButton.Click += searchResourcePacks;
            this.Controls.Add(m_ChooseResourcePackButton);

            // Initialize upload resource pack label
            m_UploadResourcePackLabel = new Label();
            m_UploadResourcePackLabel.Text = "3. Upload Resource Pack:";
            m_UploadResourcePackLabel.Top = m_ChooseResourcePackLabel.Bottom + 16;
            m_UploadResourcePackLabel.Left = 16;
            m_UploadResourcePackLabel.Width = 150;
            this.Controls.Add(m_UploadResourcePackLabel);

            // Initialize choose resource pack button
            m_UploadResourcePackButton = new Button();
            m_UploadResourcePackButton.Text = "Upload resource pack";
            m_UploadResourcePackButton.Top = m_ChooseResourcePackButton.Bottom + 16;
            m_UploadResourcePackButton.Left = m_UploadResourcePackLabel.Right + 32;
            m_UploadResourcePackButton.Width = 200;
            m_UploadResourcePackButton.Click += uploadResourcePacks;
            this.Controls.Add(m_UploadResourcePackButton);

            // Initialize back button
            m_BackButton = new Button();
            m_BackButton.Text = "Back";
            m_BackButton.Left = m_UploadResourcePackButton.Right - m_BackButton.Width;
            m_BackButton.Top = m_UploadResourcePackButton.Bottom + 8;
            m_BackButton.Click += backButtonCloseForm;
            this.Controls.Add(m_BackButton);

        }

        private void updateChooseResourcePackButtonText(object sender, EventArgs e)
        {
            m_VersionPicked = true;
            m_ChooseResourcePackButton.Text = "Find " + m_PickMinecraftVersionCombo.SelectedItem as string + " resource packs";
        }

        private void openResourcePackCategoriesForm(object sender, EventArgs e)
        {
            ResourceCategoriesForm form = new ResourceCategoriesForm(m_ChosenResourceCategories);
            this.Hide();
            form.ShowDialog();
            m_ChosenResourceCategories = form.m_CheckedValues;
            this.Show();
        }

        private void searchResourcePacks(object sender, EventArgs e)
        {
            if (m_VersionPicked == false)
            {
                MessageBox.Show("Please pick a version first", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else
            {
                ResourceInstallation.ResourcePackSearch(m_PickMinecraftVersionCombo.SelectedItem as string, m_ChosenResourceCategories);
            }
        }

        private void uploadResourcePacks(object sender, EventArgs e)
        {
            if (m_InformationReceived == false)
            {
                m_InformationReceived = true;
                MessageBox.Show("Chosen file will be moved to appropriate location", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            ResourceInstallation.UploadResourcePack();
        }

        private void backButtonCloseForm(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
