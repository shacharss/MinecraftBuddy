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
    public partial class ShaderCategoriesForm : Form
    {
        // Variables
        private CheckBox[] m_Categories = new CheckBox[3];
        public bool[] m_CheckedValues = new bool[3];

        // Checkboxes
        private CheckBox m_FantasyCheckBox;
        private CheckBox m_RealisticCheckBox;
        private CheckBox m_VanillaCheckBox;

        // Buttons
        private Button m_DoneButton;

        public ShaderCategoriesForm(bool[] i_PreCheckedValues)
        {
            initializeComponents();
            this.Text = "Choose Categories";
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(m_VanillaCheckBox.Right + 16, m_DoneButton.Bottom + 8);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ShowInTaskbar = false;


            for (int i = 0; i < i_PreCheckedValues.Length; i++)
            {
                m_CheckedValues[i] = i_PreCheckedValues[i];
                if (i_PreCheckedValues[i] == true)
                {
                    m_Categories[i].Checked = true;
                }
            }
        }

        private void initializeComponents()
        {
            // Initialize adventure checkbox
            m_FantasyCheckBox = new CheckBox();
            m_FantasyCheckBox.Text = "Fantasy";
            m_FantasyCheckBox.Left = 16;
            m_FantasyCheckBox.Top = 16;
            m_FantasyCheckBox.Width = 100;
            this.Controls.Add(m_FantasyCheckBox);

            // Initialize creation checkbox
            m_RealisticCheckBox = new CheckBox();
            m_RealisticCheckBox.Text = "Realistic";
            m_RealisticCheckBox.Left = m_FantasyCheckBox.Right + 8;
            m_RealisticCheckBox.Top = 16;
            m_RealisticCheckBox.Width = 100;
            this.Controls.Add(m_RealisticCheckBox);

            // Initialize game map checkbox
            m_VanillaCheckBox = new CheckBox();
            m_VanillaCheckBox.Text = "Vanilla";
            m_VanillaCheckBox.Left = m_RealisticCheckBox.Right + 8;
            m_VanillaCheckBox.Top = 16;
            m_VanillaCheckBox.Width = 59;
            this.Controls.Add(m_VanillaCheckBox);

            // Initialize done button
            m_DoneButton = new Button();
            m_DoneButton.Text = "Done";
            m_DoneButton.Left = m_VanillaCheckBox.Right - m_DoneButton.Width;
            m_DoneButton.Top = m_VanillaCheckBox.Bottom + 16;
            m_DoneButton.Click += finalizeAndCloseForm;
            this.Controls.Add(m_DoneButton);

            // Initialize categories array
            m_Categories[0] = m_FantasyCheckBox;
            m_Categories[1] = m_RealisticCheckBox;
            m_Categories[2] = m_VanillaCheckBox;
        }

        private void finalizeAndCloseForm(object sender, EventArgs e)
        {
            int i = 0;
            foreach (CheckBox category in m_Categories)
            {
                if (category.Checked)
                {
                    m_CheckedValues[i] = true;
                }
                else
                {
                    m_CheckedValues[i] = false;
                }
                i++;
            }
            this.Close();
        }
    }
}
