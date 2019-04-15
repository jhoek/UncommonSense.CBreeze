using UncommonSense.CBreeze.Read;
using UncommonSense.CBreeze.Write;

namespace UncommonSense.CBreeze.Test
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ApplicationBuilder
                .ReadFromFolder(@"C:\Users\jhoek\Desktop\objects\pages")
                .WriteToFolder(@"c:\users\jhoek\Desktop\output");

            //ApplicationBuilder
            //    .ReadFromFile(@"C:\Users\jhoek\Desktop\objects\codeunits\cod1008.TXT")
            //    .WriteToFile(@"C:\Users\jhoek\Desktop\output.txt");
        }
    }
}