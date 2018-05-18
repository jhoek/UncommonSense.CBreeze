using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Core.Page.Control;

namespace UncommonSense.CBreeze.Write
{
    public static class PageControlsWriter
    {
        public static void Write(this PageControls pageControls, CSideWriter writer, int propertyIndentation)
        {
            writer.BeginSection("CONTROLS");

            foreach (var pageControl in pageControls)
            {
                pageControl.Write(writer, propertyIndentation);
            }

            writer.EndSection();
        }
    }
}
