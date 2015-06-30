using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.ObjectModelBuilder;

namespace UncommonSense.CBreeze.ObjectModelWriter
{
    public static class ObjectModelWriter
    {
        public static void WriteToFolder(this ObjectModel objectModel, string folderName)
        {
            foreach (var item in objectModel.Elements.OfType<Item>())
            {
                item.WriteToFolder(folderName);
            }

            foreach (var container in objectModel.Elements.OfType<Container>())
            {
                container.WriteToFolder(folderName);
            }

            foreach (var propertyCollection in objectModel.Elements.OfType<PropertyCollection>())
            {
                propertyCollection.WriteToFolder(folderName);
            }

            foreach (var enumeration in objectModel.Elements.OfType<Enumeration>())
            {
                enumeration.WriteToFolder(folderName);
            }
        }
    }
}
