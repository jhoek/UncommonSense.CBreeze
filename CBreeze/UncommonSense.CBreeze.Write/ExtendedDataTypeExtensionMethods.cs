using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Write
{
    public static class ExtendedDataTypeExtensionMethods
    {
        public static string AsString(this ExtendedDataType value)
        {
            switch (value)
            {
                case ExtendedDataType.Url:
                    return "URL";
                case ExtendedDataType.EMail:
                    return "E-Mail";
                case ExtendedDataType.Masked:
                    return "Masked";
                case ExtendedDataType.None:
                    return "None";
                case ExtendedDataType.PhoneNo:
                    return "Phone No.";
                case ExtendedDataType.Ratio :
                    return "Ratio";
#if NAV2017
                case ExtendedDataType.Person:
                    return "Person";
                case ExtendedDataType.Resource:
                    return "Resource";
#endif
                default:
                    throw new ArgumentOutOfRangeException("value");
            }
        }
    }
}
