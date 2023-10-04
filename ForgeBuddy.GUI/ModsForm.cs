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
using MinecraftBuddy.KEYS;

namespace ForgeBuddy.GUI
{
    public partial class ModsForm : Form
    {
        // Variables
        private bool m_SearchInstructionsReceived = false;
        private bool m_VersionPicked = false;

        // Labels
        private Label m_PickVersionLabel;
        private Label m_SearchLabel;
        private Label m_MoveLabel;

        // Buttons 
        private Button m_SearchButton;
        private Button m_MoveButton;
        private Button m_BackButton;

        // DropDowns 
        private ComboBox m_PickVersionCombo;

        public ModsForm()
        {
            initializeComponents();
            this.Text = "Mods Installation";
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(m_PickVersionCombo.Right + 16, m_BackButton.Bottom + 8);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ShowInTaskbar = false;
        }

        private void initializeComponents()
        {
            // Initialize pick version label
            m_PickVersionLabel = new Label();
            m_PickVersionLabel.Text = "1. Choose mod version: ";
            m_PickVersionLabel.Top = 16;
            m_PickVersionLabel.Left = 16;
            m_PickVersionLabel.Width = 150;
            this.Controls.Add(m_PickVersionLabel);

            // Initialize pick version combobox
            m_PickVersionCombo = new ComboBox();
            m_PickVersionCombo.Text = "Pick mod version";
            m_PickVersionCombo.Top = m_PickVersionLabel.Top - (int)(0.25 * m_PickVersionLabel.Height);
            m_PickVersionCombo.Left = m_PickVersionLabel.Right;
            m_PickVersionCombo.Width = 150;
            m_PickVersionCombo.MaxLength = 11;
            m_PickVersionCombo.MaxDropDownItems = 7;
            m_PickVersionCombo.IntegralHeight = false;
            m_PickVersionCombo.SelectedValueChanged += updateSearchButtonText;
            m_PickVersionCombo.SelectedValueChanged += updateVersionPickedBool;

            foreach (string version in Versions.sr_ListMinecraftVersions)
            {
                if (version != "1.7.10_pre4")
                {
                    m_PickVersionCombo.Items.Add(version);
                }
            }
            this.Controls.Add(m_PickVersionCombo);

            // Initialize search label
            m_SearchLabel = new Label();
            m_SearchLabel.Text = "2. Search for mods: ";
            m_SearchLabel.Top = m_PickVersionLabel.Bottom + 16;
            m_SearchLabel.Left = 16;
            m_SearchLabel.Width = 150;
            this.Controls.Add(m_SearchLabel);

            // Initialize search button
            m_SearchButton = new Button();
            m_SearchButton.Text = "Search for mods";
            m_SearchButton.Top = m_SearchLabel.Top - (int)(0.25 * m_SearchLabel.Height);
            m_SearchButton.Left = m_SearchLabel.Right;
            m_SearchButton.Width = 150;
            m_SearchButton.Click += searchForMods;
            this.Controls.Add(m_SearchButton);

            // Initialize move label
            m_MoveLabel = new Label();
            m_MoveLabel.Text = "3. Setup mods folder: ";
            m_MoveLabel.Top = m_SearchLabel.Bottom + 16;
            m_MoveLabel.Left = 16;
            m_MoveLabel.Width = 150;
            this.Controls.Add(m_MoveLabel);

            // Initialize move button 
            m_MoveButton = new Button();
            m_MoveButton.Text = "Click to move mods";
            m_MoveButton.Top = m_MoveLabel.Top - (int)(0.25 * m_MoveLabel.Height);
            m_MoveButton.Left = m_MoveLabel.Right;
            m_MoveButton.Width = 150;
            m_MoveButton.Click += moveMods;
            this.Controls.Add(m_MoveButton);

            // Initialize back button
            m_BackButton = new Button();
            m_BackButton.Text = "Back";
            m_BackButton.Top = m_MoveButton.Bottom + 8;
            m_BackButton.Left = m_MoveButton.Right - m_BackButton.Width;
            m_BackButton.Click += backButtonCloseForm;
            this.Controls.Add(m_BackButton);
        }

        private void updateSearchButtonText(object sender, EventArgs e)
        {
            m_SearchButton.Text = "Search for " + m_PickVersionCombo.SelectedItem as string + " mods";
        }

        private void updateVersionPickedBool(object sender, EventArgs e)
        {
            m_VersionPicked = true;
        }

        private void searchForMods(object sender, EventArgs e)
        {
            if (m_VersionPicked == false)
            {
                MessageBox.Show("Please pick a version first", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else
            {
                if (m_SearchInstructionsReceived == false)
                {
                    MessageBox.Show("Download selected mods to \"Place Mods Here\" folder in desktop, then proceed to next step.", "Instruction", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    m_SearchInstructionsReceived = true;
                }
                ModInstallation.CreateDesktopFolder();
                ModInstallation.ModSearch(m_PickVersionCombo.SelectedItem as string);
            }
        }

        private void moveMods(object sender, EventArgs e)
        {
            if (!ModInstallation.MoveModsAndDeleteFolder())
            {
                MessageBox.Show("Error moving mods, is minecraft installed?", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Success");
            }
        }

        private void backButtonCloseForm(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
