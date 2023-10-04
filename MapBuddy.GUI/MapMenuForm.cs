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
using MapBuddy.LOGIC;

namespace MapBuddy.GUI
{
    public partial class MapMenuForm : Form
    {
        // Variables
        private bool m_VersionPicked = false;
        private bool m_InformationReceived = false;
        private bool[] m_ChosenCategories = new bool[7];

        // Labels
        private Label m_PickMinecraftVersionLabel;
        private Label m_ChooseCategoriesLabel;
        private Label m_ChooseMapPackLabel;
        private Label m_UploadMapPackLabel;

        // Buttons
        private Button m_ChooseMapPackButton;
        private Button m_ChooseCategoriesButton;
        private Button m_UploadMapPackButton;
        private Button m_BackButton;

        // Dropdowns
        private ComboBox m_PickMinecraftVersionCombo;

        public MapMenuForm()
        {
            initializeComponents();
            this.Text = "MapBuddy";
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
            m_PickMinecraftVersionCombo.Width = 150;
            m_PickMinecraftVersionCombo.MaxLength = 11;
            m_PickMinecraftVersionCombo.MaxDropDownItems = 7;
            m_PickMinecraftVersionCombo.IntegralHeight = false;

            m_PickMinecraftVersionCombo.SelectedValueChanged += updateChooseMapPackButtonText;
            foreach (string version in Versions.sr_ListMinecraftVersions)
            {
                if (version != "1.7.10_pre4")
                {
                    m_PickMinecraftVersionCombo.Items.Add(version);
                }
            }

            this.Controls.Add(m_PickMinecraftVersionCombo);

            // Initialize choose categories label
            m_ChooseCategoriesLabel = new Label();
            m_ChooseCategoriesLabel.Text = "1.5. Choose Map Categories:";
            m_ChooseCategoriesLabel.Top = m_PickMinecraftVersionLabel.Bottom + 16;
            m_ChooseCategoriesLabel.Left = 32;
            m_ChooseCategoriesLabel.Width = 150;
            this.Controls.Add(m_ChooseCategoriesLabel);

            // Initialize choose categories button
            m_ChooseCategoriesButton = new Button();
            m_ChooseCategoriesButton.Text = "Choose Map Categories";
            m_ChooseCategoriesButton.Top = m_PickMinecraftVersionCombo.Bottom + 16;
            m_ChooseCategoriesButton.Left = m_PickMinecraftVersionCombo.Left;
            m_ChooseCategoriesButton.Width = 150;
            m_ChooseCategoriesButton.Click += openCategoriesForm;
            this.Controls.Add(m_ChooseCategoriesButton);

            // Initialize choose Map pack label
            m_ChooseMapPackLabel = new Label();
            m_ChooseMapPackLabel.Text = "2. Choose Map Pack:";
            m_ChooseMapPackLabel.Top = m_ChooseCategoriesLabel.Bottom + 16;
            m_ChooseMapPackLabel.Left = 16;
            m_ChooseMapPackLabel.Width = 150;
            this.Controls.Add(m_ChooseMapPackLabel);

            // Initialize choose Map pack button
            m_ChooseMapPackButton = new Button();
            m_ChooseMapPackButton.Text = "Find Map packs";
            m_ChooseMapPackButton.Top = m_ChooseCategoriesButton.Bottom + 16;
            m_ChooseMapPackButton.Left = m_ChooseMapPackLabel.Right + 32;
            m_ChooseMapPackButton.Width = 150;
            m_ChooseMapPackButton.Click += searchMapPacks;
            this.Controls.Add(m_ChooseMapPackButton);

            // Initialize upload Map pack label
            m_UploadMapPackLabel = new Label();
            m_UploadMapPackLabel.Text = "3. Upload Map Pack:";
            m_UploadMapPackLabel.Top = m_ChooseMapPackLabel.Bottom + 16;
            m_UploadMapPackLabel.Left = 16;
            m_UploadMapPackLabel.Width = 150;
            this.Controls.Add(m_UploadMapPackLabel);

            // Initialize choose Map pack button
            m_UploadMapPackButton = new Button();
            m_UploadMapPackButton.Text = "Upload Map pack";
            m_UploadMapPackButton.Top = m_ChooseMapPackButton.Bottom + 16;
            m_UploadMapPackButton.Left = m_UploadMapPackLabel.Right + 32;
            m_UploadMapPackButton.Width = 150;
            m_UploadMapPackButton.Click += uploadMapPacks;
            this.Controls.Add(m_UploadMapPackButton);

            // Initialize back button
            m_BackButton = new Button();
            m_BackButton.Text = "Back";
            m_BackButton.Left = m_UploadMapPackButton.Right - m_BackButton.Width;
            m_BackButton.Top = m_UploadMapPackButton.Bottom + 8;
            m_BackButton.Click += backButtonCloseForm;
            this.Controls.Add(m_BackButton);

        }

        private void updateChooseMapPackButtonText(object sender, EventArgs e)
        {
            m_VersionPicked = true;
            m_ChooseMapPackButton.Text = "Find " + m_PickMinecraftVersionCombo.SelectedItem as string + " Map packs";
        }

        private void openCategoriesForm(object sender, EventArgs e)
        {
            CategoriesForm form = new CategoriesForm();
            this.Hide();
            form.ShowDialog();
            m_ChosenCategories = form.m_CheckedValues;
            this.Show();
        }

        private void searchMapPacks(object sender, EventArgs e)
        {
            if (m_VersionPicked == false)
            {
                MessageBox.Show("Please pick a version first", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else
            {
                MapInstallation.MapPackSearch(m_PickMinecraftVersionCombo.SelectedItem as string, m_ChosenCategories);
            }
        }

        private void uploadMapPacks(object sender, EventArgs e)
        {
            if (m_InformationReceived == false)
            {
                m_InformationReceived = true;
                MessageBox.Show("Chosen file will be moved to appropriate location", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            MapInstallation.UploadMapPack();
        }

        private void backButtonCloseForm(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
