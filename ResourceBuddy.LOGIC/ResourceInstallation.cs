using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;
using ResourceBuddy.KEYS;

namespace ResourceBuddy.LOGIC
{
    public class ResourceInstallation
    {

        public static void ResourcePackSearch(string i_Version)
        {
            string pathBeforeVersion = "https://www.curseforge.com/minecraft/search?class=texture-packs&gameVersion=";
            string pathAfterVersion = "&page=1&pageSize=20&sortType=1";

            string link = pathBeforeVersion + i_Version + pathAfterVersion;
            Process.Start(link);
        }

        public static void UploadResourcePack()
        {
            OpenFileDialog myDialog = new OpenFileDialog();
            myDialog.ShowDialog();
            string filePath = myDialog.FileName;
            if (filePath == "") { return; }
            string fileName = System.IO.Path.GetFileName(filePath);
            string resourcePacksPath = Paths.sr_ResourcePacksPath + @"\" + fileName;
            System.IO.File.Move(filePath, resourcePacksPath);
        }
    }
}
