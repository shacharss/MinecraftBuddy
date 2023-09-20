using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Net;
using ForgeBuddy.KEYS;

namespace ForgeBuddy.LOGIC
{
    public class ForgeInstallation
    {
        public static void DownloadForgeVersion(string i_MinecraftVersion, string i_ForgeVersion, WebClient webClient)
        {
            string uri = linkBuilder(i_MinecraftVersion, i_ForgeVersion);
            webClient.DownloadFileAsync(new Uri(uri), Paths.sr_FilePath);
        }

        private static string linkBuilder(string i_MinecraftVersion, string i_ForgeVersion)
        {
            string dictKey = i_MinecraftVersion + "-" + i_ForgeVersion;
            string dictValue = Links.sr_versionValuePairs[dictKey];
            string scheme = "https://";
            string domain = "maven.minecraftforge.net";
            string commonPath = "/net/minecraftforge/forge/";
            string specificPath = dictValue + "/";
            string resource = "forge-" + dictValue + "-installer.jar";

            string finalUri = scheme + domain + commonPath + specificPath + resource;

            return finalUri;
        }

        public static void startForge()
        {
            Process Forge = new Process();
            Forge.StartInfo.FileName = "java.exe";
            Forge.StartInfo.Arguments = "-jar " + Paths.sr_FilePath;
            Forge.StartInfo.UseShellExecute = false;
            Forge.StartInfo.CreateNoWindow = true;
            Forge.Start();
            Forge.WaitForExit();
        }
    }
}
