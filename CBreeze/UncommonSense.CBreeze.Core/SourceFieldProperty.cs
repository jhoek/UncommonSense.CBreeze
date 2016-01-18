using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
        public class SourceFieldProperty : ReferenceProperty<SourceField>
    {
        internal SourceFieldProperty(string name)
            : base(name)
        {
        }

        public override bool HasValue
        {
            get
            {
                return Value.TableVariableName != null || Value.FieldName != null;
            }
        }
    }
}
