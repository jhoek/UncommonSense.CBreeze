using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public partial class Codeunit : Object
    {
        private CodeunitProperties properties = new CodeunitProperties();
        private Code code = new Code();

        internal Codeunit(Int32 id, String name) : base(id, name)
        {
        }

        public override ObjectType Type
        {
            get
            {
                return ObjectType.Codeunit;
            }
        }

        public CodeunitProperties Properties
        {
            get
            {
                return this.properties;
            }
        }

        public Code Code
        {
            get
            {
                return this.code;
            }
        }

    }
}
