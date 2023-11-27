using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;
using ShaderBuddy.KEYS;


namespace ShaderBuddy.LOGIC
{
    public class ShaderInstallation
    {
        public static void ShaderSearch(string i_Version, bool[] i_ShaderCategories)
        {
            string[] mapCategories = { "fantasy", "realistic", "vanilla" };

            string pathBeforeVersion = "https://www.curseforge.com/minecraft/search?class=shaders&gameVersion=";
            string pathAfterVersion = "&page=1&pageSize=20&sortType=1";
            string pathForMapCategories = "&categories=";

            int i = 0;
            foreach (bool b in i_ShaderCategories)
            {
                if (b)
                {
                    pathForMapCategories += mapCategories[i] + "%2C";
                }
                i += 1;
            }

            if (i_Version.Equals("all"))
            {
                string pathBeforeMapCategories = "https://www.curseforge.com/minecraft/search?class=shaders&page=1&pageSize=20&sortType=1";
                string link = pathBeforeMapCategories + pathForMapCategories;
                Process.Start(link);
            }
            else
            {
                string link = pathBeforeVersion + i_Version + pathAfterVersion + pathForMapCategories;
                Process.Start(link);
            }
        }

        public static void UploadShaderPack()
        {
            OpenFileDialog myDialog = new OpenFileDialog();
            myDialog.ShowDialog();
            string filePath = myDialog.FileName;
            if (filePath == "") { return; }
            string fileName = System.IO.Path.GetFileName(filePath);
            string mapPacksPath = Paths.sr_ShaderPacksPath + @"\" + fileName;
            System.IO.File.Move(filePath, mapPacksPath);
        }
    }
}
