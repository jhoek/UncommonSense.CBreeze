using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.DomWriter
{
    public class ClassMethod : Method
    {
        private bool @abstract;
        private bool @override;
        private List<string> lines = new List<string>();

        public ClassMethod(string name, string returnTypeName)
            : base(name, returnTypeName)
        {
        }

        public bool Abstract
        {
            get
            {
                return this.@abstract;
            }
            set
            {
                this.@abstract = value;
            }
        }

        public bool Override
        {
            get
            {
                return this.@override;
            }
            set
            {
                this.@override = value;
            }
        }

        public List<string> Lines
        {
            get
            {
                return this.lines;
            }
        }
    }
}
