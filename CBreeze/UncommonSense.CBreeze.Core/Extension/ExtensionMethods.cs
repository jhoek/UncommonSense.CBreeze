using UncommonSense.CBreeze.Core.Page.Control;
using UncommonSense.CBreeze.Core.Property.Enumeration;

namespace UncommonSense.CBreeze.Core.Extension
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