using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ForgeBuddy.GUI;
using ResourceBuddy.GUI;
using MapBuddy.GUI;

namespace MinecraftBuddy.GUI
{
    public partial class MainMenuForm : Form
    {
        // Labels
        private Label m_WelcomeLabel;

        // Buttons
        private Button m_ForgeBuddyButton;
        private Button m_ResourceBuddyButton;
        private Button m_ShaderBuddyButton;
        private Button m_MapBuddyButton;

        public MainMenuForm()
        {
            initializeComponents();
            this.Text = "MinecraftBuddy";
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(608, m_ForgeBuddyButton.Bottom + 8);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ShowInTaskbar = false;
        }

        private void initializeComponents()
        {
            // Initialize welcome label
            m_WelcomeLabel = new Label();
            m_WelcomeLabel.Text = "Welcome to MinecraftBuddy, select an app to proceed";
            m_WelcomeLabel.Width = 275;
            m_WelcomeLabel.Top = 16;
            m_WelcomeLabel.Left = 166;
            this.Controls.Add(m_WelcomeLabel);
        
            // Initialize ForgeBuddy button
            m_ForgeBuddyButton = new Button();
            m_ForgeBuddyButton.Text = "ForgeBuddy";
            m_ForgeBuddyButton.Top = m_WelcomeLabel.Bottom + 16;
            m_ForgeBuddyButton.Left = 16;
            m_ForgeBuddyButton.Width = 125;
            m_ForgeBuddyButton.Click += launchForgeBuddy;
            this.Controls.Add(m_ForgeBuddyButton);

            // Initialize ResourceBuddy button
            m_ResourceBuddyButton = new Button();
            m_ResourceBuddyButton.Text = "ResourceBuddy";
            m_ResourceBuddyButton.Top = m_WelcomeLabel.Bottom + 16;
            m_ResourceBuddyButton.Left = m_ForgeBuddyButton.Right + 25;
            m_ResourceBuddyButton.Width = 125;
            m_ResourceBuddyButton.Click += launchResourceBuddy;
            this.Controls.Add(m_ResourceBuddyButton);

            // Initialize ShaderBuddy button
            m_ShaderBuddyButton = new Button();
            m_ShaderBuddyButton.Text = "ShaderBuddy";
            m_ShaderBuddyButton.Top = m_WelcomeLabel.Bottom + 16;
            m_ShaderBuddyButton.Left = m_ResourceBuddyButton.Right + 25;
            m_ShaderBuddyButton.Width = 125;
            this.Controls.Add(m_ShaderBuddyButton);

            // Initialize MapBuddy button
            m_MapBuddyButton = new Button();
            m_MapBuddyButton.Text = "MapBuddy";
            m_MapBuddyButton.Top = m_WelcomeLabel.Bottom + 16;
            m_MapBuddyButton.Left = m_ShaderBuddyButton.Right + 25;
            m_MapBuddyButton.Width = 125;
            m_MapBuddyButton.Click += launchMapBuddy;
            this.Controls.Add(m_MapBuddyButton);
        }

        private void launchForgeBuddy(object sender, EventArgs e)
        {
            this.Hide();
            ForgeMenuForm form = new ForgeMenuForm();
            form.ShowDialog();
            this.Show();
        }

        private void launchResourceBuddy(object sender, EventArgs e)
        {
            this.Hide();
            ResourceMenuForm form = new ResourceMenuForm();
            form.ShowDialog();
            this.Show();
        }

        private void launchMapBuddy(object sender, EventArgs e)
        {
            this.Hide();
            MapMenuForm form = new MapMenuForm();
            form.ShowDialog();
            this.Show();
        }

    }
}
