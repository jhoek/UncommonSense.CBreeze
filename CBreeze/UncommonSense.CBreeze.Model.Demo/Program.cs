using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Render;

namespace UncommonSense.CBreeze.Model.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var applicationDesign = new ApplicationDesign();
            var setup = applicationDesign.AddSetupEntityType("Demo Setup");
            var supplemental = applicationDesign.AddSupplementalEntityType("My Language", "My Languages");
            var master = applicationDesign.AddMasterEntityType("My Customer", setup);
            var subsidary = applicationDesign.AddSubsidiaryEntityType("My Customer Address", "My Customer Addresses", master);
            var journal = applicationDesign.AddJournalEntityType("Demo");

            var application = new Application();
            var renderingContext = new RenderingContext();

            applicationDesign.RenderTo(application, renderingContext);
        }
    }
}
