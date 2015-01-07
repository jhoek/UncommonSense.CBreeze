using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.DomWriter
{
    public abstract class Method
    {
        private Visibility visibility = Visibility.Public;
        private string name;
        private string returnTypeName;
        private List<MethodParameter> parameters = new List<MethodParameter>();

        public Method(string name, string returnTypeName)
        {
            this.name = name;
            this.returnTypeName = returnTypeName;
        }

        public Visibility Visibility
        {
            get
            {
                return this.visibility;
            }
            set
            {
                this.visibility = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
        }

        public string ReturnTypeName
        {
            get
            {
                return this.returnTypeName;
            }
        }

        public List<MethodParameter> Parameters
        {
            get
            {
                return this.parameters;
            }
        }
    }
}
