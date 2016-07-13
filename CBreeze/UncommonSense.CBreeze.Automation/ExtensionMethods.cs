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
        public static int GetID(this PSObject id, IEnumerable<int> idsInUse = null, int containingID = 0, int objectID = 0, IEnumerable<int> alternativeRange = null)
        {
            if (id.BaseObject is int)
            {
                return (int)id.BaseObject;
            }

            if (id.BaseObject is IEnumerable<int>)
            {
                var range = id.BaseObject as IEnumerable<int>;
                var useAlternativeRange = false;

                // Note: containingID may be an object ID (in case of e.g. page controls),
                // or e.g. a function ID (in case of parameters). In multi-layered scenario's,
                // such as function parameters, the containingID contains the function ID, 
                // and the objectID contains the object ID.
                // See also this gist: https://gist.github.com/jhoek/8988ffb441e4162c8b5e

                if (containingID != 0)
                {
                    if (range.Contains(containingID))
                    {
                        useAlternativeRange = true;
                    }
                    else
                    {
                        useAlternativeRange = range.Contains(objectID);
                    }
                }

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

        public static IEnumerable<PageActionBase> GetActions(this PSObject inputObject)
        {
            if (inputObject.BaseObject is PageControls)
                return (inputObject.BaseObject as PageControls).Page.Actions;
            else if (inputObject.BaseObject is Page)
                return (inputObject.BaseObject as Page).Properties.ActionList;
            else if (inputObject.BaseObject is ReportRequestPage)
                return (inputObject.BaseObject as ReportRequestPage).Properties.ActionList;
            else if (inputObject.BaseObject is XmlPortRequestPage)
                return (inputObject.BaseObject as XmlPortRequestPage).Properties.ActionList;
            else if (inputObject.BaseObject is ContainerPageControl)
                return (inputObject.BaseObject as ContainerPageControl).Container.Page.Actions;
            else if (inputObject.BaseObject is GroupPageControl)
                return (inputObject.BaseObject as GroupPageControl).Container.Page.Actions;
            else
                throw new ArgumentOutOfRangeException("Don't know how to determine used action IDs for this InputObject.");
        }

        public static IEnumerable<PageControl> GetPageControls(this PSObject inputObject)
        {
            if (inputObject.BaseObject is PageControls)
                return (inputObject.BaseObject as PageControls);
            else if (inputObject.BaseObject is Page)
                return (inputObject.BaseObject as Page).Controls;
            else if (inputObject.BaseObject is ReportRequestPage)
                return (inputObject.BaseObject as ReportRequestPage).Controls;
            else if (inputObject.BaseObject is XmlPortRequestPage)
                return (inputObject.BaseObject as XmlPortRequestPage).Controls;
            else if (inputObject.BaseObject is ContainerPageControl)
                return (inputObject.BaseObject as ContainerPageControl).Container;
            else if (inputObject.BaseObject is GroupPageControl)
                return (inputObject.BaseObject as GroupPageControl).Container;
            else
                throw new ArgumentOutOfRangeException("Don't know how to determine used control IDs for this InputObject.");
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
