using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.ObjectModelBuilder;

namespace UncommonSense.CBreeze.DomBuilder.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var objectModel = new ObjectModel("Demo");

            var @object = objectModel.Elements.Add(new Item("Object", new Attribute("int", "ID"), new Attribute("string", "Name")));

            var table = objectModel.Elements.Add(new Item("Table"));
            var tables = objectModel.Elements.Add(new Container("Table", "Tables"));

            var application = objectModel.Elements.Add(new Item("Application"));
            application.Attributes.Add(new Attribute("Tables", "Tables"));
        }
    }
}
