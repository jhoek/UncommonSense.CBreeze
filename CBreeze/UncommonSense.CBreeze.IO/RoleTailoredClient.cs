using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.IO
{
    public static class RoleTailoredClient
    {
        public static void Run(string fileName, string hyperlink, bool hideNavigationPage = false, bool fullScreen = false, bool consoleMode = false, int? languageID = null)
        {
            var arguments = new StringBuilder();
            arguments.AppendIf(hideNavigationPage, " -shownavigationpane:0");
            arguments.AppendIf(fullScreen, " -fullscreen");
            arguments.AppendIf(consoleMode, " -consolemode");
            arguments.AppendIf(languageID.HasValue, String.Format(" -language:{0}", languageID));
            arguments.AppendFormat(" \"{0}\"", hyperlink);

            Process.Start(fileName, arguments.ToString());
        }
    }
}
