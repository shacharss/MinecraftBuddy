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
    public partial class ShaderForm : Form
    {
        // Variables
        private bool m_VersionPicked = false;
        private bool m_InformationReceived = false;
        private bool[] m_ChosenShaderCategories = new bool[3];

        // Labels
        private Label m_PickMinecraftVersionLabel;
        private Label m_ChooseShaderCategoriesLabel;
        private Label m_ChooseShaderPackLabel;
        private Label m_UploadShaderPackLabel;

        // Buttons
        private Button m_ChooseShaderPackButton;
        private Button m_ChooseCategoriesButton;
        private Button m_UploadShaderPackButton;
        private Button m_BackButton;

        // Dropdowns
        private ComboBox m_PickMinecraftVersionCombo;

        public ShaderForm()
        {
            initializeComponents();
            this.Text = "ShaderBuddy";
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

            m_PickMinecraftVersionCombo.SelectedValueChanged += updateChooseShaderPackButtonText;
            m_PickMinecraftVersionCombo.Items.Add(Versions.sr_AllVersion);
            foreach (string version in Versions.sr_OptifineMinecraftVersions)
            {
                if (version != "1.7.10_pre4")
                {
                    m_PickMinecraftVersionCombo.Items.Add(version);
                }
            }

            this.Controls.Add(m_PickMinecraftVersionCombo);

            // Initialize choose shader categories label
            m_ChooseShaderCategoriesLabel = new Label();
            m_ChooseShaderCategoriesLabel.Text = "1.5. Choose Shader Categories:";
            m_ChooseShaderCategoriesLabel.Top = m_PickMinecraftVersionLabel.Bottom + 16;
            m_ChooseShaderCategoriesLabel.Left = 32;
            m_ChooseShaderCategoriesLabel.Width = 150;
            this.Controls.Add(m_ChooseShaderCategoriesLabel);

            // Initialize choose shader categories button
            m_ChooseCategoriesButton = new Button();
            m_ChooseCategoriesButton.Text = "Choose Shader Categories";
            m_ChooseCategoriesButton.Top = m_PickMinecraftVersionCombo.Bottom + 16;
            m_ChooseCategoriesButton.Left = m_PickMinecraftVersionCombo.Left;
            m_ChooseCategoriesButton.Width = 150;
            m_ChooseCategoriesButton.Click += openShaderCategoriesForm;
            this.Controls.Add(m_ChooseCategoriesButton);

            // Initialize choose Shader pack label
            m_ChooseShaderPackLabel = new Label();
            m_ChooseShaderPackLabel.Text = "2. Choose Shader Pack:";
            m_ChooseShaderPackLabel.Top = m_ChooseShaderCategoriesLabel.Bottom + 16;
            m_ChooseShaderPackLabel.Left = 16;
            m_ChooseShaderPackLabel.Width = 150;
            this.Controls.Add(m_ChooseShaderPackLabel);

            // Initialize choose Shader pack button
            m_ChooseShaderPackButton = new Button();
            m_ChooseShaderPackButton.Text = "Find Shader packs";
            m_ChooseShaderPackButton.Top = m_ChooseCategoriesButton.Bottom + 16;
            m_ChooseShaderPackButton.Left = m_ChooseShaderPackLabel.Right + 32;
            m_ChooseShaderPackButton.Width = 150;
            m_ChooseShaderPackButton.Click += searchShaderPacks;
            this.Controls.Add(m_ChooseShaderPackButton);

            // Initialize upload Shader pack label
            m_UploadShaderPackLabel = new Label();
            m_UploadShaderPackLabel.Text = "3. Upload Shader Pack:";
            m_UploadShaderPackLabel.Top = m_ChooseShaderPackLabel.Bottom + 16;
            m_UploadShaderPackLabel.Left = 16;
            m_UploadShaderPackLabel.Width = 150;
            this.Controls.Add(m_UploadShaderPackLabel);

            // Initialize choose Shader pack button
            m_UploadShaderPackButton = new Button();
            m_UploadShaderPackButton.Text = "Upload Shader pack";
            m_UploadShaderPackButton.Top = m_ChooseShaderPackButton.Bottom + 16;
            m_UploadShaderPackButton.Left = m_UploadShaderPackLabel.Right + 32;
            m_UploadShaderPackButton.Width = 150;
            m_UploadShaderPackButton.Click += uploadShaderPacks;
            this.Controls.Add(m_UploadShaderPackButton);

            // Initialize back button
            m_BackButton = new Button();
            m_BackButton.Text = "Back";
            m_BackButton.Left = m_UploadShaderPackButton.Right - m_BackButton.Width;
            m_BackButton.Top = m_UploadShaderPackButton.Bottom + 8;
            m_BackButton.Click += backButtonCloseForm;
            this.Controls.Add(m_BackButton);

        }

        private void updateChooseShaderPackButtonText(object sender, EventArgs e)
        {
            m_VersionPicked = true;
            m_ChooseShaderPackButton.Text = "Find " + m_PickMinecraftVersionCombo.SelectedItem as string + " Shader packs";
        }

        private void openShaderCategoriesForm(object sender, EventArgs e)
        {
            ShaderCategoriesForm form = new ShaderCategoriesForm(m_ChosenShaderCategories);
            this.Hide();
            form.ShowDialog();
            m_ChosenShaderCategories = form.m_CheckedValues;
            this.Show();
        }

        private void searchShaderPacks(object sender, EventArgs e)
        {
            if (m_VersionPicked == false)
            {
                MessageBox.Show("Please pick a version first", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else
            {
                ShaderInstallation.ShaderSearch(m_PickMinecraftVersionCombo.SelectedItem as string, m_ChosenShaderCategories);
            }
        }

        private void uploadShaderPacks(object sender, EventArgs e)
        {
            if (m_InformationReceived == false)
            {
                m_InformationReceived = true;
                MessageBox.Show("Chosen file will be moved to appropriate location", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            ShaderInstallation.UploadShaderPack();
        }

        private void backButtonCloseForm(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
