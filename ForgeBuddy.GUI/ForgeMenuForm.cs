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

namespace ForgeBuddy.GUI
{
    public partial class ForgeMenuForm : Form
    {
        // Labels
        private Label m_CurseForgeLabel;
        private Label m_ModsLabel;

        // Buttons
        private Button m_CurseForgeButton;
        private Button m_ModsButton;
        private Button m_BackButton;

        public ForgeMenuForm()
        {
            initializeComponents();
            this.Text = "ForgeBuddy";
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(m_CurseForgeButton.Right + 16, m_BackButton.Bottom + 8);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ShowInTaskbar = false;
        }

        private void initializeComponents()
        {
            // Initialize CurseForge label
            m_CurseForgeLabel = new Label();
            m_CurseForgeLabel.Text = "1. Install Forge:";
            m_CurseForgeLabel.Top = 16;
            m_CurseForgeLabel.Left = 16;
            m_CurseForgeLabel.Width = 250;
            this.Controls.Add(m_CurseForgeLabel);

            // Initialize CurseForge button
            m_CurseForgeButton = new Button();
            m_CurseForgeButton.Text = "Start Forge installation";
            m_CurseForgeButton.Top = m_CurseForgeLabel.Top - (int)(0.25 * m_CurseForgeButton.Height);
            m_CurseForgeButton.Left = m_CurseForgeLabel.Right;
            m_CurseForgeButton.Width = 180;
            m_CurseForgeButton.Click += m_CurseForgeButton_Click;
            this.Controls.Add(m_CurseForgeButton);

            // Initialize Mods label
            m_ModsLabel = new Label();
            m_ModsLabel.Text = "2. Install mods";
            m_ModsLabel.Top = m_CurseForgeLabel.Bottom + 16;
            m_ModsLabel.Left = 16;
            m_ModsLabel.Width = 180;
            this.Controls.Add(m_ModsLabel);

            // Initialize Mods Button
            m_ModsButton = new Button();
            m_ModsButton.Text = "Start Mods installation";
            m_ModsButton.Top = m_ModsLabel.Top - (int)(0.25 * m_ModsButton.Height);
            m_ModsButton.Left = m_CurseForgeButton.Left;
            m_ModsButton.Width = 180;
            m_ModsButton.Click += m_ModsButton_Click;
            this.Controls.Add(m_ModsButton);

            // Initialize Back Button
            m_BackButton = new Button();
            m_BackButton.Text = "Back";
            m_BackButton.Top = m_ModsButton.Bottom + 16;
            m_BackButton.Left = m_ModsButton.Right - m_BackButton.Width;
            m_BackButton.Click += m_CloseForm;
            this.Controls.Add(m_BackButton);


        }

        private void m_CurseForgeButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            ForgeForm form = new ForgeForm();
            form.ShowDialog();
            this.Show();
        }

        private void m_ModsButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            ModsForm form = new ModsForm();
            form.ShowDialog();
            ModInstallation.DeleteFolder();
            this.Show();
        }

        private void m_CloseForm(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
