using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.DomWriter
{
    public class ClassProperty : Property
    {
        private bool @abstract;
        private bool @override;
        private List<string> getterLines = new List<string>();
        private List<string> setterLines = new List<string>();

        public ClassProperty(string name, string typeName)
            : base(name, typeName)
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

        public List<string> GetterLines
        {
            get
            {
                return this.getterLines;
            }
        }

        public List<string> SetterLines
        {
            get
            {
                return this.setterLines;
            }
        }
    }
}
