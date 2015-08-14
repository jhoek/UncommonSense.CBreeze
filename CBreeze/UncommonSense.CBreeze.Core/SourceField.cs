using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public partial class SourceField
    {
        private String fieldName;
        private String tableVariableName;

        internal SourceField()
        {
        }

        public String FieldName
        {
            get
            {
                return this.fieldName;
            }
            set
            {
                this.fieldName = value;
            }
        }

        public String TableVariableName
        {
            get
            {
                return this.tableVariableName;
            }
            set
            {
                this.tableVariableName = value;
            }
        }

    }
}
