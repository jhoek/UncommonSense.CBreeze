using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Write
{
    public static class FunctionParametersWriter
    {
        public static void Write(Parameters parameters, CSideWriter writer)
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
