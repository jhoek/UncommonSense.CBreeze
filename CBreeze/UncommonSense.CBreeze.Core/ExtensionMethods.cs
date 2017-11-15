using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.Core
{
    public static class ExtensionMethods
    {
        public static void Add(this PageControls pageControls, PageControlBase item, Position? position)
        {
            switch (position.GetValueOrDefault(Position.LastWithinContainer))
            {
                case Position.FirstWithinContainer:
                    pageControls.Insert(0, item);
                    break;

                case Position.LastWithinContainer:
                    pageControls.Add(item);
                    break;
            }
        }
    }
}