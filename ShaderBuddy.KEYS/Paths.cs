using System;

namespace ShaderBuddy.KEYS
{
    public static class Paths
    {
        public static readonly string sr_FilePath = System.IO.Path.GetTempPath() + "Optifine.jar";
        public static readonly string sr_ShaderPacksPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\.minecraft\shaderpacks";
    }
}
