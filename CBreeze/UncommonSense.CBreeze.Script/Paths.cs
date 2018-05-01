using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.CBreeze.Script
{
    public static class Paths
    {
        public static string Input => Environment.GetCommandLineArgs().Skip(1).First();
        public static string Desktop => Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        public static string Script => Path.Combine(Desktop, "scripts");
        public static string Output => Path.Combine(Desktop, "output");
        public static string Runner(string prefix) => Path.Combine(Desktop, $"{prefix}.runner.ps1");

        public static string Create(this string folder)
        {
            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);

            return folder;
        }

        public static string Delete(this string folder)
        {
            if (Directory.Exists(folder))
                Directory.Delete(folder, true);

            return folder;
        }

        public static string Recreate(this string folder)
        {
            return folder.Delete().Create();
        }
    }
}
