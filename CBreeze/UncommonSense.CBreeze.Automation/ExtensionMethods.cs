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
        public static int GetID(this PSObject id, IEnumerable<int> idsInUse = null, int containingID = 0, IEnumerable<int> alternativeRange = null)
        {
            if (id.BaseObject is int)
            {
                return (int)id.BaseObject;
            }

            if (id.BaseObject is IEnumerable<int>)
            {
                var range = id.BaseObject as IEnumerable<int>;

                // Note: containingID may be an object ID (in case of e.g. page controls),
                // or e.g. a function ID (in case of parameters). 
                if (containingID != 0)
                    if (range.Contains(containingID))
                        range = (alternativeRange ?? 1.To(int.MaxValue));

                return range.Except(idsInUse ?? Enumerable.Empty<int>()).First();
            }

            throw new ArgumentOutOfRangeException("Cannot determine ID.");
        }

        public static int GetID(this PSObject id, IEnumerable<int> idsInUse = null, bool useAlternativeRange = false, IEnumerable<int> alternativeRange = null)
        {
            if (id.BaseObject is int)
            {
                return (int)id.BaseObject;
            }

            if (id.BaseObject is IEnumerable<int>)
            {
                var range = id.BaseObject as IEnumerable<int>;

                if (useAlternativeRange)
                    range = (alternativeRange ?? 1.To(int.MaxValue));

                return range.Except(idsInUse ?? Enumerable.Empty<int>()).First();
            }

            throw new ArgumentOutOfRangeException("Cannot determine ID.");
        }

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

        public static IEnumerable<int> GetParameterIDs(this PSObject inputObject)
        {
            if (inputObject.BaseObject is Parameters)
                return (inputObject.BaseObject as Parameters).Select(p => p.ID);
            else if (inputObject.BaseObject is IHasParameters)
                return (inputObject.BaseObject as IHasParameters).Parameters.Select(p => p.ID);
            else
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
