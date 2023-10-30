using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;
using MapBuddy.KEYS;

namespace MapBuddy.LOGIC
{
    public class MapInstallation
    {
        public static void MapPackSearch(string i_Version, bool[] i_MapCategories)
        {
            string[] mapCategories = {"adventure", "creation", "game-map", "modded-world", "parkour", "puzzle", "survival"};

            string pathBeforeVersion = "https://www.curseforge.com/minecraft/search?class=worlds&gameVersion=";
            string pathAfterVersion = "&page=1&pageSize=20&sortType=1";
            string pathForMapCategories = "&categories=";

            int i = 0;
            foreach (bool b in i_MapCategories)
            {
                if (b)
                {
                    pathForMapCategories += mapCategories[i] + "%2C";
                }
                i += 1;
            }

            if (i_Version.Equals("all"))
            {
                string pathBeforeMapCategories = "https://www.curseforge.com/minecraft/search?class=worlds&page=1&pageSize=20&sortType=1";
                string link = pathBeforeMapCategories + pathForMapCategories;
                Process.Start(link);
            }
            else
            {
                string link = pathBeforeVersion + i_Version + pathAfterVersion + pathForMapCategories;
                Process.Start(link);
            }
        }

        public static void UploadMapPack()
        {
            OpenFileDialog myDialog = new OpenFileDialog();
            myDialog.ShowDialog();
            string filePath = myDialog.FileName;
            if (filePath == "") { return; }
            string fileName = System.IO.Path.GetFileName(filePath);
            string mapPacksPath = Paths.sr_MapPacksPath + @"\" + fileName;
            System.IO.File.Move(filePath, mapPacksPath);
        }
    }
}
