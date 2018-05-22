using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;
using Object = UncommonSense.CBreeze.Core.Base.Object;

namespace UncommonSense.CBreeze.IO
{
    public static class ApplicationDesigner
    {
        public static void Design(this Object @object, string devClient, string serverName, string database)
        {
            var arguments = new Arguments(null, serverName, database);
            arguments.Add("designobject", string.Format("{0} {1}", @object.Type, @object.ID));

            DevClient.Run(devClient, arguments);
        }
    }
}
