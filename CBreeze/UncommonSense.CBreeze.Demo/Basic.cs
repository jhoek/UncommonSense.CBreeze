using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Read;

namespace UncommonSense.CBreeze.Demo
{
    // # Basic operations
    public static class Basic
    {
        // ## Creating a new application
        public static void _00100CreatingAnApplication()
        {
            var application = new Application();
        }

        // ## Initializing an application with objects
        public static void _00200InitializingAnApplicationWithObjects()
        {
            var application = new Application(
                new Table(50000, "My Table"),
                new Table(50001, "My Other Table"),
                new Page(50000, "My Page"),
                new Codeunit(50000, "My Codeunit"));
        }

        // ## Importing an existing application from a single disk file
        public static void _00300ImportingAnExistingApplicationFromASingleDiskFile()
        {
            var application = ApplicationBuilder.FromFile("mytest.txt");
        }

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