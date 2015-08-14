using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class SourceFieldProperty : Property
    {
        private SourceField value = new SourceField();

        internal SourceFieldProperty(string name) : base(name)
        {
        }

        public override bool HasValue
        {
            get
            {
                return Value.TableVariableName != null || value.FieldName != null;
            }
        }

        public SourceField Value
        {
            get
            {
                return this.value;
            }
        }
    }

}
