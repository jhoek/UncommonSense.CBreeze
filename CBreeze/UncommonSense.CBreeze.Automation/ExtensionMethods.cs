using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Write;

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

        public static IPage GetIPage(this PSObject inputObject)
        {
            IPage result = null;

            TypeSwitch.Do(
                inputObject.BaseObject,
                TypeSwitch.Case<Page>(i => result = i),
                TypeSwitch.Case<Report>(i => result = i.RequestPage),
                TypeSwitch.Case<XmlPort>(i => result = i.RequestPage),
                TypeSwitch.Case<ReportRequestPage>(i => result = i),
                TypeSwitch.Case<XmlPortRequestPage>(i => result = i),
                TypeSwitch.Case<ActionList>(i => result = i.Page),
                TypeSwitch.Case<PageControls>(i => result = i.Page),
                TypeSwitch.Case<PageActionContainer>(i => result = i.Container.Page),
                TypeSwitch.Case<PageActionGroup>(i => result = i.Container.Page),
                TypeSwitch.Case<GroupPageControl>(i => result = i.Container.Page),
                TypeSwitch.Case<ContainerPageControl>(i => result = i.Container.Page)
            );

            if (result == null)
                throw new ArgumentOutOfRangeException("Don't know how to determine IPage interface for this InputObject.");

            return result;
        }

        public static IEnumerable<int> GetPageUIDsInUse(this IPage page)
        {
            return page.Actions.Select(a => a.ID).Union(page.Controls.Select(c => c.ID));
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

        public static T AddPageActionAtPosition<T>(this ActionList actionList, T pageAction, Position position) where T: PageActionBase
        {
            switch (position)
            {
                case Position.FirstWithinContainer:
                    actionList.Insert(0, pageAction);
                    break;
                case Position.LastWithinContainer:
                    actionList.Add(pageAction);
                    break;
            }

            return pageAction;
        }

        public static T AddPageActionAtPosition<T>(this IPage page, T pageAction, Position position) where T:PageActionBase
        {
            switch (position)
            {
                case Position.FirstWithinContainer:
                    page.Actions.Insert(0, pageAction);
                    break;
                case Position.LastWithinContainer:
                    page.Actions.Add(pageAction);
                    break;
            }

            return pageAction;
        }
    }
}
