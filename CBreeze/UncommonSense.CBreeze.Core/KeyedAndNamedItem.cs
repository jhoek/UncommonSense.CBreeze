using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.CBreeze.Core
{
    public abstract class KeyedAndNamedItem<T> : KeyedItem<T>
    {
        // This supports both elements that have a name property (e.g. table fields),
        // and elements whose names are stored in their Properties (e.g. page controls).
        // FIXME: Currently not tested: what if somebody changes a page control's name
        // to something that already exists within the same PageControls collection?

        public abstract string GetName();
    }
}
