using System;
using System.Linq;
using System.Diagnostics;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Write;
using UncommonSense.CBreeze.Read;
using System.IO;
using System.Text;

namespace UncommonSense.CBreeze.Demo
{
    internal class MainClass
    {
        public static void Main(string[] args)
        {
            DefaultRanges.ID = Enumerable.Range(50000, 100);
            DefaultRanges.UID = Enumerable.Range(1000000000, 100);

            var application = new Application();
            var xmlport = application.XmlPorts.Add(new XmlPort("My XMLport"));

            xmlport.Nodes.Add(new XmlPortTableElement("Customer")).Properties.SourceTable = BaseApp.TableIDs.Customer;
            xmlport.Nodes.Add(new XmlPortFieldElement("No", 1));
            xmlport.Nodes.Add(new XmlPortFieldElement("Balance", 1));
            xmlport.Nodes.Add(new XmlPortTextAttribute("Currency", 2));

            application.Write();
        }
    }
}