using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.DomWriter
{
    public class MethodParameter
    {
        private string typeName;
        private string name;
        private bool @ref = false;
        private bool @out = false;
        private bool @params = false;

        public MethodParameter(string name, string typeName)
        {
            this.name = name;
            this.typeName = typeName;
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();

            if (Out)
                stringBuilder.Append("out ");
            if (Ref)
                stringBuilder.Append("ref ");
            if (Params)
                stringBuilder.Append("params ");

            stringBuilder.AppendFormat("{0} {1}", TypeName, Name);

            return stringBuilder.ToString();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
        }

        public string TypeName
        {
            get
            {
                return this.typeName;
            }
        }

        private bool Ref
        {
            get
            {
                return this.@ref;
            }
            set
            {
                this.@ref = value;
            }
        }

        private bool Out
        {
            get
            {
                return this.@out;
            }
            set
            {
                this.@out = value;
            }
        }

        private bool Params
        {
            get
            {
                return this.@params;
            }
            set
            {
                this.@params = value;
            }
        }
    }
}
