using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Write
{
    public static class ParameterWriter
    {
        private static void DoWrite(bool var, string name, int uid, bool temporary, string typeName, string dimensions, CSideWriter writer)
        {
            if (var)
                writer.Write("VAR ");

            writer.Write("{0}@{1} : ", name, uid);

            if (!string.IsNullOrEmpty(dimensions))
                writer.Write("ARRAY [{0}] OF ", dimensions.Replace(';', ','));

            if (temporary)
                writer.Write("TEMPORARY ");

            writer.Write(typeName);
        }

        public static void Write(this Parameter parameter, CSideWriter writer)
        {
            switch (parameter)
            {
                case RecordParameter recordParameter: DoWrite(recordParameter.Var, recordParameter.Name, recordParameter.ID, recordParameter.Temporary.GetValueOrDefault(false), recordParameter.TypeName, recordParameter.Dimensions, writer); break;
                default: DoWrite(parameter.Var, parameter.Name, parameter.ID, false, parameter.TypeName, parameter.Dimensions, writer); break;
            }
        }
    }
}