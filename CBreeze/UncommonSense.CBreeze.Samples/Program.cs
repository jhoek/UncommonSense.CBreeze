using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Read;
using UncommonSense.CBreeze.Write;

namespace UncommonSense.CBreeze.Samples
{
    class Program
    {
        static void Main(string[] args)
        {
            // CBreezeWriteDemo(@"c:\users\jhoek\desktop\sample.txt");
            CBreezeReaderDemo(@"c:\users\jhoek\desktop\input.txt", @"c:\users\jhoek\desktop\output.txt");
        }

        static void CBreezeCoreDemo()
        {
            var application = new Application();
            var table = application.Tables.Add(50000, "My Demo Table");

            var codeField = table.Fields.Add(new CodeTableField(1, "Code", 10));
            codeField.Properties.NotBlank = true;
            codeField.Properties.CaptionML.Add("ENU", codeField.Name);

            var descriptionField = table.Fields.Add(new TextTableField(10, "Description", 30));
            descriptionField.Properties.CaptionML.Add("ENU", descriptionField.Name);

            table.Properties.DataCaptionFields.AddRange(codeField.Name, descriptionField.Name);
        }

        static void CBreezeWriteDemo(string outputFileName)
        {
            var application = new Application();
            
            // ... add objects to your application here ...

            application.Write(outputFileName);
        }

        static void CBreezeReaderDemo(string inputFileName, string outputFileName)
        {
            var application = ApplicationBuilder.FromFile(inputFileName);

            foreach (var table in application.Tables)
            {
                // No ENU caption present? Add it!
                if (!table.Properties.CaptionML.Any(e => e.LanguageID == "ENU"))
                    table.Properties.CaptionML.Add("ENU", table.Name);
            }

            application.Write(outputFileName);
        }
    }
}
