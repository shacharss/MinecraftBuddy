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
        public static void MapPackSearch(string i_Version, bool[] i_Categories)
        {
            string[] categories = {"adventure", "creation", "game-map", "modded-world", "parkour", "puzzle", "survival"};

            string pathBeforeVersion = "https://www.curseforge.com/minecraft/search?class=worlds&gameVersion=";
            string pathAfterVersion = "&page=1&pageSize=20&sortType=1";
            string pathForCategories = "&categories=";

            int i = 0;
            foreach (bool b in i_Categories)
            {
                if (b)
                {
                    pathForCategories += categories[i] + "%2C";
                }
                i += 1;
            }

            string link = pathBeforeVersion + i_Version + pathAfterVersion + pathForCategories;
            Process.Start(link);
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
