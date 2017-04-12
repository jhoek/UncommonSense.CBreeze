using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Demo
{
    // # Basic operations
    public static class Basic
    {
        // ## Adding a table
        public static void _01000AddingATable()
        {
            var application = new Application();
            var table = application.Tables.Add(new Table(50000, "My Table"));
        }

        // ## Adding a table field
        public static void _01100AddingATableField()
        {
            var application = new Application();
            var table = application.Tables.Add(new Table(50000, "My Table"));
            var field = table.Fields.Add(new IntegerTableField(1, "Entry No."));
        }

        // ## Adding a page
        public static void _02000AddingAPage()
        {
            var application = new Application();
            var page = application.Pages.Add(new Page(50000, "My Page"));
        }
    }
}