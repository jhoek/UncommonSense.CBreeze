using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
        public class Codeunit : Object, IHasCode
    {
        public Codeunit(int id, string name)
            : base(id, name)
        {
            Properties = new CodeunitProperties();
            Code = new Code(this);
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
            get;protected set;
        }

        public Code Code
        {
            get;
            protected set;
        }

        public override Properties AllProperties
        {
            get
            {
                return Properties;
            }
        }
    }
}
