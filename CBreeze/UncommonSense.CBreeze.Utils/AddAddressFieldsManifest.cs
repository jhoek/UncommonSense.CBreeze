using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Utils
{
    public class AddAddressFieldsManifest
    {
        internal AddAddressFieldsManifest()
        {
        }

        public TextTableField AddressField
        {
            get;
            internal set;
        }

        public TextTableField Address2Field
        {
            get;
            internal set;
        }

        public CodeTableField PostCodeField
        {
            get;
            internal set;
        }

        public TextTableField CityField
        {
            get;
            internal set;
        }

        public TextTableField CountyField
        {
            get;
            internal set;
        }

        public CodeTableField CountryRegionCodeField
        {
            get;
            internal set;
        }
    }
}
