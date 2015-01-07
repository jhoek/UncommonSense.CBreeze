using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.DomWriter
{
    public class Constructor
    {
        private Visibility visibility = Visibility.Public;
        private List<MethodParameter> parameters = new List<MethodParameter>();

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
