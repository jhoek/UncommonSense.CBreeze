using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Utils
{
    public static class MenuSuiteNodeExtensionMethods
    {
        public static int Index(this MenuSuiteNode menuSuiteNode)
        {
            return menuSuiteNode.Container.IndexOf(menuSuiteNode);
        }
    }
}
