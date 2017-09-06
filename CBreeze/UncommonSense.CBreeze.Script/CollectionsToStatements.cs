using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Script
{
    public static class CollectionsToStatements
    {
        public static IEnumerable<Statement> ToStatements(this TableFields fields) => fields.Select(f => f.ToInvocation());
    }
}