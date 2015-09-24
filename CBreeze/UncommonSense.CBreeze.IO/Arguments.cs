using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.IO
{
    public class Arguments : Dictionary<string, object>
    {
        public Arguments()
        {
        }

        public Arguments(string command, string serverName, string database)
        {
            this.Add("command", command);
            this.Add("servername", serverName);
            this.Add("database", database);
            this.Add("ntauthentication", 1);
        }

        public override string ToString()
        {
            return string.Join(",", this.Where(a => !string.IsNullOrEmpty((a.Value ?? string.Empty).ToString())).Select(a => string.Format("{0}={1}", a.Key, a.Value)));
        }
    }
}
