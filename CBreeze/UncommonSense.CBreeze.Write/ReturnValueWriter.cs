﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Core.Code.Function;

namespace UncommonSense.CBreeze.Write
{
    public static class ReturnValueWriter
    {
        public static string GetTypeName(FunctionReturnValue functionReturnValue)
        {
            switch (functionReturnValue.Type)
            {
                case FunctionReturnValueType.Text:
                    return functionReturnValue.DataLength.HasValue ? string.Format("{0}[{1}]", functionReturnValue.Type, functionReturnValue.DataLength) : functionReturnValue.Type.ToString();

                case FunctionReturnValueType.Code:
                case FunctionReturnValueType.Binary:
                    return $"{functionReturnValue.Type}[{functionReturnValue.DataLength}]";

                case FunctionReturnValueType.Guid:
                    return "GUID";

                default:
                    return functionReturnValue.Type.ToString();
            }
        }

        public static void Write(this FunctionReturnValue functionReturnValue, CSideWriter writer)
        {
            if (!functionReturnValue.Type.HasValue)
                return;

            if (!string.IsNullOrEmpty(functionReturnValue.Name))
                writer.Write(" {0}", functionReturnValue.Name);

            writer.Write(" : ");

            if (!string.IsNullOrEmpty(functionReturnValue.Dimensions))
                writer.Write("ARRAY [{0}] OF ", functionReturnValue.Dimensions);

            writer.Write(GetTypeName(functionReturnValue));
        }
    }
}