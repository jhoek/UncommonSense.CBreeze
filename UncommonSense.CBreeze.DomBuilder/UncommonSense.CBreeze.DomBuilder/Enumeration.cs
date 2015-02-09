using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.CBreeze.DomBuilder
{
    public class Enumeration : ObjectModelElement
    {
        private List<string> values = new List<string>();

        public Enumeration(string name, params string[] values)
            : base(name)
        {
            this.values.AddRange(values);
        }

        public IEnumerable<string> Values
        {
            get
            {
                foreach (var value in this.values)
                {
                    yield return value;
                }
            }
        }
    }
}
