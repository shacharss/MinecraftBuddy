using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ResourceBuddy.GUI
{
    public partial class ResourceCategoriesForm : Form
    {
        // Variables
        private CheckBox[] m_Categories = new CheckBox[16];
        public bool[] m_CheckedValues = new bool[16];

        // Checkboxes
        private CheckBox m_128x;
        private CheckBox m_16x;
        private CheckBox m_256x;
        private CheckBox m_32x;
        private CheckBox m_512x;
        private CheckBox m_64x;
        private CheckBox m_Animated;
        private CheckBox m_DataPacks;
        private CheckBox m_FontPacks;
        private CheckBox m_Medieval;
        private CheckBox m_Miscellaneous;
        private CheckBox m_ModSupport;
        private CheckBox m_Modern;
        private CheckBox m_PhotoRealistic;
        private CheckBox m_Steampunk;
        private CheckBox m_Traditional;

        // Buttons
        private Button m_DoneButton;

        public ResourceCategoriesForm(bool[] i_PreCheckedValues)
        {
            initializeComponents();
            this.Text = "Choose Categories";
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(m_512x.Right + 16, m_DoneButton    .Bottom + 8);
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
            // Initialize 128x checkbox
            m_128x = new CheckBox();
            m_128x.Text = "128x";
            m_128x.Top = 16;
            m_128x.Left = 16;
            m_128x.Width = 100;
            this.Controls.Add(m_128x);

            // Initialize 16x checkbox
            m_16x = new CheckBox();
            m_16x.Text = "16x";
            m_16x.Top = 16;
            m_16x.Left = m_128x.Right + 8;
            m_16x.Width = 100;
            this.Controls.Add(m_16x);

            // Initialize 256x checkbox
            m_256x = new CheckBox();
            m_256x.Text = "256x";
            m_256x.Top = 16;
            m_256x.Left = m_16x.Right + 8;
            m_256x.Width = 100;
            this.Controls.Add(m_256x);

            // Initialize 32x checkbox
            m_32x = new CheckBox();
            m_32x.Text = "32x";
            m_32x.Top = 16;
            m_32x.Left = m_256x.Right + 8;
            m_32x.Width = 100;
            this.Controls.Add(m_32x);

            // Initialize 512x checkbox
            m_512x = new CheckBox();
            m_512x.Text = "512x";
            m_512x.Top = 16;
            m_512x.Left = m_32x.Right + 8;
            m_512x.Width = 100;
            this.Controls.Add(m_512x);

            // Initialize 64x checkbox
            m_64x = new CheckBox();
            m_64x.Text = "64x";
            m_64x.Top = m_16x.Top + 32;
            m_64x.Left = m_16x.Left;
            m_64x.Width = 100;
            this.Controls.Add(m_64x);

            // Initialize animated checkbox
            m_Animated = new CheckBox();
            m_Animated.Text = "Animated";
            m_Animated.Top = m_16x.Top + 32;
            m_Animated.Left = m_64x.Right + 8;
            m_Animated.Width = 100;
            this.Controls.Add(m_Animated);

            // Initialize data packs checkbox
            m_DataPacks = new CheckBox();
            m_DataPacks.Text = "Data Packs";
            m_DataPacks.Top = m_16x.Top + 32;
            m_DataPacks.Left = m_Animated.Right + 8;
            m_DataPacks.Width = 100;
            this.Controls.Add(m_DataPacks);

            // Initialize font packs checkbox
            m_FontPacks = new CheckBox();
            m_FontPacks.Text = "Font Packs";
            m_FontPacks.Top = m_64x.Top + 32;
            m_FontPacks.Left = 16;
            m_FontPacks.Width = 100;
            this.Controls.Add(m_FontPacks);

            // Initialize medieval checkbox
            m_Medieval = new CheckBox();
            m_Medieval.Text = "Medieval";
            m_Medieval.Top = m_64x.Top + 32;
            m_Medieval.Left = m_FontPacks.Right + 8;
            m_Medieval.Width = 100;
            this.Controls.Add(m_Medieval);

            // Initialize miscellaneous checkbox
            m_Miscellaneous = new CheckBox();
            m_Miscellaneous.Text = "Miscellaneous";
            m_Miscellaneous.Top = m_64x.Top + 32;
            m_Miscellaneous.Left = m_Medieval.Right + 8;
            m_Miscellaneous.Width = 100;
            this.Controls.Add(m_Miscellaneous);

            // Initialize mod support checkbox
            m_ModSupport = new CheckBox();
            m_ModSupport.Text = "Mod Support";
            m_ModSupport.Top = m_64x.Top + 32;
            m_ModSupport.Left = m_Miscellaneous.Right + 8;
            m_ModSupport.Width = 100;
            this.Controls.Add(m_ModSupport);

            // Initialize modern checkbox
            m_Modern = new CheckBox();
            m_Modern.Text = "Modern";
            m_Modern.Top = m_64x.Top + 32;
            m_Modern.Left = m_ModSupport.Right + 8;
            m_Modern.Width = 100;
            this.Controls.Add(m_Modern);

            // Initialize photo realistic checkbox
            m_PhotoRealistic = new CheckBox();
            m_PhotoRealistic.Text = "Photo Realistic";
            m_PhotoRealistic.Left = m_Medieval.Left;
            m_PhotoRealistic.Top = m_FontPacks.Top + 32;
            m_PhotoRealistic.Width = 100;
            this.Controls.Add(m_PhotoRealistic);

            //Initialize steampunk checkbox
            m_Steampunk = new CheckBox();
            m_Steampunk.Text = "Steampunk";
            m_Steampunk.Left = m_PhotoRealistic.Right + 8;
            m_Steampunk.Top = m_FontPacks.Top + 32;
            m_Steampunk.Width = 100;
            this.Controls.Add(m_Steampunk);

            //Initialize traditional checkbox
            m_Traditional = new CheckBox();
            m_Traditional.Text = "Traditional";
            m_Traditional.Left = m_Steampunk.Right + 8;
            m_Traditional.Top = m_FontPacks.Top + 32;
            m_Traditional.Width = 100;
            this.Controls.Add(m_Traditional);

            // Initialize done button
            m_DoneButton = new Button();
            m_DoneButton.Text = "Done";
            m_DoneButton.Left = m_Modern.Right - m_DoneButton.Width;
            m_DoneButton.Top = m_PhotoRealistic.Bottom + 8;
            m_DoneButton.Click += finalizeAndCloseForm;
            this.Controls.Add(m_DoneButton);

            // Initialize categories array
            m_Categories[0] = m_128x;
            m_Categories[1] = m_16x;
            m_Categories[2] = m_256x;
            m_Categories[3] = m_32x;
            m_Categories[4] = m_512x;
            m_Categories[5] = m_64x;
            m_Categories[6] = m_Animated;
            m_Categories[7] = m_DataPacks;
            m_Categories[8] = m_FontPacks;
            m_Categories[9] = m_Medieval;
            m_Categories[10] = m_Miscellaneous;
            m_Categories[11] = m_ModSupport;
            m_Categories[12] = m_Modern;
            m_Categories[13] = m_PhotoRealistic;
            m_Categories[14] = m_Steampunk;
            m_Categories[15] = m_Traditional;
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
