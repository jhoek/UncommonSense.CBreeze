using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public partial class Page : Object
    {
        private Code code = new Code();
        private PageControls controls = new PageControls();
        private PageProperties properties = new PageProperties();

        internal Page(Int32 id, String name) : base(id, name)
        {
        }

        public override ObjectType Type
        {
            get
            {
                return ObjectType.Page;
            }
        }

        public Code Code
        {
            get
            {
                return this.code;
            }
        }

        public PageControls Controls
        {
            get
            {
                return this.controls;
            }
        }

        public PageProperties Properties
        {
            get
            {
                return this.properties;
            }
        }

    }
}
