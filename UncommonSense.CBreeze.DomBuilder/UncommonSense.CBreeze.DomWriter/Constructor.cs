using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.DomWriter
{
    public class Constructor
    {
        private Class @class;
        private Visibility visibility = Visibility.Public;
        private List<MethodParameter> parameters = new List<MethodParameter>();

        public Constructor(Class @class)
        {
            this.@class = @class;
        }

        public Class Class
        {
            get
            {
                return this.@class;
            }
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

        public List<MethodParameter> Parameters
        {
            get
            {
                return this.parameters;
            }
        }
    }
}
