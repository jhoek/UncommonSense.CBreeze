using UncommonSense.CBreeze.Read;
using UncommonSense.CBreeze.Write;

namespace UncommonSense.CBreeze.Test
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ApplicationBuilder
                .ReadFromFolder(@"C:\Users\jhoek\Desktop\2018\input\nl\rtm")
                .WriteToFolder(@"c:\users\jhoek\Desktop\2018\Output");

            //ApplicationBuilder
            //    .ReadFromFile(@"C:\Users\jhoek\Desktop\2018\Input\NL\rtm\PAG1170.TXT")
            //    .WriteToFile(@"C:\Users\jhoek\Desktop\out.txt");
        }
    }
}