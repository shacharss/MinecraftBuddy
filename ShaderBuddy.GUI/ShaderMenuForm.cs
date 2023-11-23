using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShaderBuddy.GUI
{
    public partial class ShaderMenuForm : Form
    {
        // Labels
        private Label m_OptifineLabel;
        private Label m_ShadersLabel;

        // Buttons
        private Button m_OptifineButton;
        private Button m_ModsButton;
        private Button m_BackButton;

        public ShaderMenuForm()
        {
            initializeComponents();
            this.Text = "ForgeBuddy";
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(m_OptifineButton.Right + 16, m_BackButton.Bottom + 8);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ShowInTaskbar = false;
        }

        private void initializeComponents()
        {
            // Initialize CurseForge label
            m_OptifineLabel = new Label();
            m_OptifineLabel.Text = "1. Install Optifine:";
            m_OptifineLabel.Top = 16;
            m_OptifineLabel.Left = 16;
            m_OptifineLabel.Width = 250;
            this.Controls.Add(m_OptifineLabel);

            // Initialize CurseForge button
            m_OptifineButton = new Button();
            m_OptifineButton.Text = "Start Optifine installation";
            m_OptifineButton.Top = m_OptifineLabel.Top - (int)(0.25 * m_OptifineButton.Height);
            m_OptifineButton.Left = m_OptifineLabel.Right;
            m_OptifineButton.Width = 180;
            m_OptifineButton.Click += m_OptifineButton_Click;
            this.Controls.Add(m_OptifineButton);

            // Initialize Mods label
            m_ShadersLabel = new Label();
            m_ShadersLabel.Text = "2. Install Shaders";
            m_ShadersLabel.Top = m_OptifineLabel.Bottom + 16;
            m_ShadersLabel.Left = 16;
            m_ShadersLabel.Width = 180;
            this.Controls.Add(m_ShadersLabel);

            // Initialize Mods Button
            m_ModsButton = new Button();
            m_ModsButton.Text = "Start Shaders installation";
            m_ModsButton.Top = m_ShadersLabel.Top - (int)(0.25 * m_ModsButton.Height);
            m_ModsButton.Left = m_OptifineButton.Left;
            m_ModsButton.Width = 180;
            m_ModsButton.Click += m_ShadersButton_Click;
            this.Controls.Add(m_ModsButton);

            // Initialize Back Button
            m_BackButton = new Button();
            m_BackButton.Text = "Back";
            m_BackButton.Top = m_ModsButton.Bottom + 16;
            m_BackButton.Left = m_ModsButton.Right - m_BackButton.Width;
            m_BackButton.Click += m_CloseForm;
            this.Controls.Add(m_BackButton);
        }

        private void m_OptifineButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            OptifineForm form = new OptifineForm();
            form.ShowDialog();
            this.Show();
        }

        private void m_ShadersButton_Click(object sender, EventArgs e)
        {
            //
        }

        private void m_CloseForm(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
