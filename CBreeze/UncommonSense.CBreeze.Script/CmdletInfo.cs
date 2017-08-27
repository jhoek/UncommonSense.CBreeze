using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.CBreeze.Script
{
    public class CmdletInfo
    {
        protected internal CmdletInfo(string name, string alias)
        {
            Name = name;
            Alias = alias;
        }

        public string Alias { get; protected set; }
        public string Name { get; protected set; }
    }
}