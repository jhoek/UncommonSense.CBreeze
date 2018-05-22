using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Core.XmlPort;

namespace UncommonSense.CBreeze.Write
{
    public static class XmlPortWriter
    {
        public static void Write(this XmlPort xmlPort, CSideWriter writer)
        {
            writer.BeginSection(xmlPort.GetObjectSignature());
            xmlPort.ObjectProperties.Write(writer);
            xmlPort.Properties.Write(writer);
            xmlPort.Nodes.Write(writer);
            WriteEvents(writer);
            xmlPort.RequestPage.Write(writer);
            xmlPort.Code.Write(writer);
            writer.EndSection();
            writer.InnerWriter.WriteLine();
        }

        public static void WriteEvents(CSideWriter writer)
        {
            writer.BeginSection("EVENTS");
            writer.EndSection();
        }
    }
}
