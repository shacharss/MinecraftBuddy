using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapBuddy.GUI
{
    public partial class MapCategoriesForm : Form
    {
        // Variables
        private CheckBox[] m_Categories = new CheckBox[7];
        public bool[] m_CheckedValues = new bool[7];

        // Checkboxes
        private CheckBox m_AdventureCheckBox;
        private CheckBox m_CreationCheckBox;
        private CheckBox m_GameMapCheckBox;
        private CheckBox m_ModdedWorldCheckBox;
        private CheckBox m_ParkourCheckBox;
        private CheckBox m_PuzzleCheckBox;
        private CheckBox m_SurvivalCheckBox;

        // Buttons
        private Button m_DoneButton;

        public MapCategoriesForm(bool[] i_PreCheckedValues)
        {
            initializeComponents();
            this.Text = "Choose Categories";
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(m_ModdedWorldCheckBox.Right + 16, m_DoneButton.Bottom + 8);
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
            m_AdventureCheckBox = new CheckBox();
            m_AdventureCheckBox.Text = "Adventure";
            m_AdventureCheckBox.Left = 16;
            m_AdventureCheckBox.Top = 16;
            m_AdventureCheckBox.Width = 100;
            this.Controls.Add(m_AdventureCheckBox);

            // Initialize creation checkbox
            m_CreationCheckBox = new CheckBox();
            m_CreationCheckBox.Text = "Creation";
            m_CreationCheckBox.Left = m_AdventureCheckBox.Right + 8;
            m_CreationCheckBox.Top = 16;
            m_CreationCheckBox.Width = 100;
            this.Controls.Add(m_CreationCheckBox);

            // Initialize game map checkbox
            m_GameMapCheckBox = new CheckBox();
            m_GameMapCheckBox.Text = "Game Map";
            m_GameMapCheckBox.Left = m_CreationCheckBox.Right + 8;
            m_GameMapCheckBox.Top = 16;
            m_GameMapCheckBox.Width = 100;
            this.Controls.Add(m_GameMapCheckBox);

            // Initialize modded world checkbox
            m_ModdedWorldCheckBox = new CheckBox();
            m_ModdedWorldCheckBox.Text = "Modded World";
            m_ModdedWorldCheckBox.Left = m_GameMapCheckBox.Right + 8;
            m_ModdedWorldCheckBox.Top = 16;
            m_ModdedWorldCheckBox.Width = 100;
            this.Controls.Add(m_ModdedWorldCheckBox);

            // Initilize parkour checkbox
            m_ParkourCheckBox = new CheckBox();
            m_ParkourCheckBox.Text = "Parkour";
            m_ParkourCheckBox.Left = 92;
            m_ParkourCheckBox.Top = m_AdventureCheckBox.Top + 32;
            m_ParkourCheckBox.Width = 100;
            this.Controls.Add(m_ParkourCheckBox);

            // Initialize puzzle checkbox
            m_PuzzleCheckBox = new CheckBox();
            m_PuzzleCheckBox.Text = "Puzzle";
            m_PuzzleCheckBox.Left = m_ParkourCheckBox.Right + 8;
            m_PuzzleCheckBox.Top = m_AdventureCheckBox.Top + 32;
            m_PuzzleCheckBox.Width = 100;
            this.Controls.Add(m_PuzzleCheckBox);

            // Initialize survival checkbox
            m_SurvivalCheckBox = new CheckBox();
            m_SurvivalCheckBox.Text = "Survival";
            m_SurvivalCheckBox.Left = m_PuzzleCheckBox.Right + 8;
            m_SurvivalCheckBox.Top = m_AdventureCheckBox.Top + 32;
            m_SurvivalCheckBox.Width = 100;
            this.Controls.Add(m_SurvivalCheckBox);

            // Initialize done button
            m_DoneButton = new Button();
            m_DoneButton.Text = "Done";
            m_DoneButton.Left = m_ModdedWorldCheckBox.Right - m_DoneButton.Width;
            m_DoneButton.Top = m_SurvivalCheckBox.Bottom + 8;
            m_DoneButton.Click += finalizeAndCloseForm;
            this.Controls.Add(m_DoneButton);

            // Initialize categories array
            m_Categories[0] = m_AdventureCheckBox;
            m_Categories[1] = m_CreationCheckBox;
            m_Categories[2] = m_GameMapCheckBox;
            m_Categories[3] = m_ModdedWorldCheckBox;
            m_Categories[4] = m_ParkourCheckBox;
            m_Categories[5] = m_PuzzleCheckBox;
            m_Categories[6] = m_SurvivalCheckBox;

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
