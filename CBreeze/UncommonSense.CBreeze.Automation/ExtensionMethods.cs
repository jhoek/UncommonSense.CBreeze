using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    public static class ExtensionMethods
    {
        public static Parameters GetParameters(this PSObject inputObject)
        {
            if (inputObject.BaseObject is Parameters)
                return (inputObject.BaseObject as Parameters);
            if (inputObject.BaseObject is Function)
                return (inputObject.BaseObject as Function).Parameters;
            if (inputObject.BaseObject is Event)
                return (inputObject.BaseObject as Event).Parameters;

            throw new ApplicationException("Cannot add parameters to this object.");
        }

        public static bool TryGetParameters(this PSObject inputObject, out Parameters parameters)
        {
            try
            {
                parameters = GetParameters(inputObject);
                return true;
            }
            catch (ApplicationException)
            {
                parameters = null;
                return false;
            }
        }

        public static IEnumerable<int> GetParameterIDs(this PSObject inputObject)
        {
            Parameters parameters = null;

            if (TryGetParameters(inputObject, out parameters))
                return parameters.Select(p => p.ID);

            return Enumerable.Empty<int>();
        }

        public static Variables GetVariables(this PSObject inputObject)
        {
            if (inputObject.BaseObject is Table)
                return (inputObject.BaseObject as Table).Code.Variables;
            if (inputObject.BaseObject is Page)
                return (inputObject.BaseObject as Page).Code.Variables;
            if (inputObject.BaseObject is Report)
                return (inputObject.BaseObject as Report).Code.Variables;
            if (inputObject.BaseObject is Codeunit)
                return (inputObject.BaseObject as Codeunit).Code.Variables;
            if (inputObject.BaseObject is Query)
                return (inputObject.BaseObject as Query).Code.Variables;
            if (inputObject.BaseObject is XmlPort)
                return (inputObject.BaseObject as XmlPort).Code.Variables;

            if (inputObject.BaseObject is Code)
                return (inputObject.BaseObject as Code).Variables;

            if (inputObject.BaseObject is Function)
                return (inputObject.BaseObject as Function).Variables;
            if (inputObject.BaseObject is Trigger)
                return (inputObject.BaseObject as Trigger).Variables;
            if (inputObject.BaseObject is Event)
                return (inputObject.BaseObject as Event).Variables;

            throw new ApplicationException("Cannot add variables to this object.");
        }

        public static bool TryGetVariables(this PSObject inputObject, out Variables variables)
        {
            try
            {
                variables = GetVariables(inputObject);
                return true;
            }
            catch (ApplicationException)
            {
                variables = null;
                return false;
            }
        }

        public static IEnumerable<int> GetVariableIDs(this PSObject inputObject)
        {
            Variables variables = null;

            if (TryGetVariables(inputObject, out variables))
                return variables.Select(v => v.ID);

            return Enumerable.Empty<int>();
        }
    }
}
