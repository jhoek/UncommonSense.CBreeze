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
            set;
        }

        public TextTableField Address2Field
        {
            get;
            set;
        }

        public CodeTableField PostCodeField
        {
            get;
            set;
        }

        public TextTableField CityField
        {
            get;
            set;
        }

        public TextTableField CountyField
        {
            get;
            set;
        }

        public CodeTableField CountryRegionCodeField
        {
            get;
            set;
        }
    }
}
