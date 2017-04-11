using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Demo
{
    // # Basic
    public static class Basic
    {
        // ## Adding a table
        public static void AddingATable()
        {
            var application = new Application();
            var table = application.Tables.Add(new Table(50000, "My Table"));
        }

        // ## Adding a page
        public static void AddingAPage()
        {
            var application = new Application();
            var page = application.Pages.Add(new Page(50000, "My Page"));
        }
    }
}