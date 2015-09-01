using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.IO
{
    public class Arguments : Dictionary<string, string>
    {
        public override string ToString()
        {
            return string.Join(",", this.Where(a => !string.IsNullOrEmpty(a.Value)).Select(a => string.Format("{0}={1}", a.Key, a.Value)));
        }
    }
}
