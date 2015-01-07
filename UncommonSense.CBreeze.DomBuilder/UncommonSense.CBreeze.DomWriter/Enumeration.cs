using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.DomWriter
{
    public class Enumeration
    {
        private string name;
        private Visibility visibility = Visibility.Public;
        private Dictionary<string, int> values = new Dictionary<string, int>();

        public Enumeration(string name)
        {
            this.name = name;
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

        public Dictionary<string, int> Values
        {
            get
            {
                return this.values;
            }
        } 
    }
}
