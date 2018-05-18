using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Core.MenuSuite;

namespace UncommonSense.CBreeze.Write
{
    public static class MenuSuiteWriter
    {
        public static void Write(this MenuSuite menuSuite, CSideWriter writer)
        {
            writer.BeginSection(menuSuite.GetObjectSignature());
			menuSuite.ObjectProperties.Write(writer);
			menuSuite.Properties.Write(writer);
			menuSuite.Nodes.Write(writer);
            writer.EndSection();
        }
    }
}
