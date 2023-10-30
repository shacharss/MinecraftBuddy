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

        public static void ResourcePackSearch(string i_Version, bool[] i_ResourceCategories)
        {
            /// TODOOOO
            string[] resourceCategories = { "one-twenty-eight-x", "sixteen-x", "two-fifty-six-x", "thirty-two-x", "five-twelve-x-and-beyond",
                "sixty-four-x", "animated", "data-packs", "font-packs", "medieval", "miscellaneous", "mod-support",
                "modern", "photo-realistic", "steampunk", "traditional"};

            string pathBeforeVersion = "https://www.curseforge.com/minecraft/search?class=texture-packs&gameVersion=";
            string pathAfterVersion = "&page=1&pageSize=20&sortType=1";

            string pathForResourceCategories = "&categories=";

            int i = 0;
            foreach (bool b in i_ResourceCategories)
            {
                if (b)
                {
                    pathForResourceCategories += resourceCategories[i] + "%2C";
                }
                i += 1;
            }


            if (i_Version.Equals("all"))
            {
                string pathBeforeResourceCategories = "https://www.curseforge.com/minecraft/search?class=texture-packs&page=1&pageSize=20&sortType=1";
                string link = pathBeforeResourceCategories + pathForResourceCategories;
                Process.Start(link);
            }
            else
            {
                string link = pathBeforeVersion + i_Version + pathAfterVersion + pathForResourceCategories;
                Process.Start(link);
            }

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
