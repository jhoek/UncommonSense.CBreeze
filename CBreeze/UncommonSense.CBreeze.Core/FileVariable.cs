using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public partial class FileVariable : Variable
    {
        public FileVariable(int id, string name)
            : base(id, name)
        {
        }

        public override VariableType Type
        {
            get
            {
                return VariableType.File;
            }
        }

        public string Dimensions
        {
            get;
            set;
        }
    }
}
