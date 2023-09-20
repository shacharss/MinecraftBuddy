using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ForgeBuddy.LOGIC
{
    public class ModInstallation
    {

        // Variables
        public static readonly string sr_DesktopModsFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Place Mods Here";

        public static void CreateDesktopFolder()
        {
            System.IO.Directory.CreateDirectory(sr_DesktopModsFolderPath);
        }

        public static void ModSearch(string i_Version)
        {
            string pathBeforeVersion = "https://www.curseforge.com/minecraft/search?class=mc-mods&gameVersion=";
            string pathAfterVersion = "&page=1&pageSize=20&sortType=1";

            string link = pathBeforeVersion + i_Version + pathAfterVersion;
            Process.Start(link);
        }

        public static bool MoveModsAndDeleteFolder()
        {
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string minecraftPath = appDataPath + @"\.minecraft";

            if (!Directory.Exists(minecraftPath))
            {
                return false;
            }
            System.IO.Directory.CreateDirectory(minecraftPath + @"\mods");

            foreach (var file in Directory.GetFiles(sr_DesktopModsFolderPath))
            {
                File.Copy(file, Path.Combine(minecraftPath + @"\mods", Path.GetFileName(file)));
            }

            Directory.Delete(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Place Mods Here", true);

            return true;
        }
    }
}
