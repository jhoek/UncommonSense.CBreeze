using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Core.Code.Parameter;

namespace UncommonSense.CBreeze.Write
{
    public static class ParametersWriter
    {
        public static void Write(this Parameters parameters, CSideWriter writer)
        {
            foreach (var parameter in parameters)
            {
                parameter.Write(writer);

                if (parameter != parameters.Last())
                    writer.Write(";");
            }
        }
    }
}
