using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Core.Property.Implementation;

namespace UncommonSense.CBreeze.Write
{
    public static class PropertyScopeExtensionMethods
    {
        public static string ScopedName(this ScopedTriggerProperty property)
        {
            switch (property.Name)
            {
                case "OnAfterInitRecord":
                case "OnAfterAssignVariable":
                case "OnBeforeInsertRecord":
                case "OnAfterInsertRecord":
                case "OnBeforeModifyRecord":
                case "OnAfterModifyRecord":
                case "OnAfterAssignField":
                    return string.Format("Import::{0}", property.Name);
                case "OnPreXMLItem":
                case "OnAfterGetRecord":
                case "OnBeforePassVariable":
                case "OnBeforePassField":
                    return string.Format("Export::{0}", property.Name);
                default:
                    return property.Name;
            }
        }
    }
}
