using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Render;
using UncommonSense.CBreeze.Write;

namespace UncommonSense.CBreeze.Model.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var applicationDesign = new ApplicationDesign();
            var setup = applicationDesign.Add(new SetupEntityType("Demo Setup"));
            var item = applicationDesign.Add(new MasterEntityType("Item", setup));
            //var vendor = applicationDesign.Add(new MasterEntityType("Vendor", setup));

            //var subsidiaryEntityType = applicationDesign.Add(new SubsidiaryEntityType("Item Vendor", "Item Vendors", item, vendor));
            //subsidiaryEntityType.DifferentiatorType = DifferentiatorType.None;

            //var ledgerEntityType = applicationDesign.Add(new LedgerEntityType("Item Ledger Entry", "Item Ledger Entries"));
            //ledgerEntityType.MasterEntityType = item;

            var application = applicationDesign.RenderTo(new Application(), new RenderingContext());
            application.Write(Console.Out);
        }
    }
}
