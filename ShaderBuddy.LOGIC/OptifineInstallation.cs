using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Net;
using ShaderBuddy.KEYS;
using HtmlAgilityPack;

namespace ShaderBuddy.LOGIC
{
    public class OptifineInstallation
    {
        public static void DownloadOptifineVersion(string i_MinecraftVersion, WebClient webClient)
        {
            string uri = linkBuilder(i_MinecraftVersion);
            webClient.DownloadFileAsync(new Uri(uri), Paths.sr_FilePath);
        }

        private static string linkBuilder(string i_MinecraftVersion)
        {
            string scheme = "https://";
            string domain = "optifine.net/";
            string commonPath = "adloadx?f=";
            string specificPath = Links.sr_versionValuePairs[i_MinecraftVersion];

            var web = new HtmlWeb();
            var optifineDocument = web.Load(scheme + domain + commonPath + specificPath);
            var downloadNode = optifineDocument.DocumentNode.SelectSingleNode("//*[@id=\"Download\"]/div/a");

            
            var downloadPath = downloadNode.Attributes["href"].Value;

            return scheme + domain + downloadPath;
        }

        public static void startOptifine()
        {
            Process Optifine = new Process();
            Optifine.StartInfo.FileName = "java.exe";
            Optifine.StartInfo.Arguments = "-jar " + Paths.sr_FilePath;
            Optifine.StartInfo.UseShellExecute = false;
            Optifine.StartInfo.CreateNoWindow = true;
            Optifine.Start();
            Optifine.WaitForExit();
        }
    }
}
