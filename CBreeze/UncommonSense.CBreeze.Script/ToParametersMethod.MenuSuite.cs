using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Core.MenuSuite;

namespace UncommonSense.CBreeze.Script
{
    public static partial class ToParametersMethod
    {
        public static IEnumerable<ParameterBase> ToParameters(this MenuSuiteNode menuSuiteNode)
        {
            yield return new SimpleParameter("ID", menuSuiteNode.ID);

            foreach (var parameter in menuSuiteNode.AllProperties.Where(p => p.HasValue).SelectMany(p => p.ToParameters()))
            {
                yield return parameter;
            }
        }
    }
}
