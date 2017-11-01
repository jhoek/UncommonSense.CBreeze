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
        public static void Add<T>(this Application application, IEnumerable<T> objs) where T : Core.Object
        {
            foreach (var obj in objs)
            {
                application.Add(obj);
            }
        }

        public static T Add<T>(this Application application, T obj) where T : Core.Object
        {
            switch (obj)
            {
                case Table t:
                    application.Tables.Add(t);
                    break;
                case Page p:
                    application.Pages.Add(p);
                    break;
                case Report r:
                    application.Reports.Add(r);
                    break;
                case Codeunit c:
                    application.Codeunits.Add(c);
                    break;
                case XmlPort x:
                    application.XmlPorts.Add(x);
                    break;
                case Query q:
                    application.Queries.Add(q);
                    break;
                case MenuSuite m:
                    application.MenuSuites.Add(m);
                    break;
            }

            return obj;
        }

        public static T AddPageActionAtPosition<T>(this ActionList actionList, T pageAction, Position position) where T : PageActionBase
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

        public static T AddPageActionAtPosition<T>(this IPage page, T pageAction, Position position) where T : PageActionBase
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

        public static object DoIf<T>(this T obj, bool condition, Action<T> action)
        {
            if (condition)
                action(obj);

            return obj;
        }

        public static IEnumerable<int> GetParameterIDs(this PSObject inputObject)
        {
            switch (inputObject.BaseObject)
            {
                case Parameters n:
                    return n.Select(p => p.ID);
                case Function f:
                    return f.Parameters.Select(p => p.ID);
                case Event e:
                    return e.Parameters.Select(p => p.ID);
                default:
                    return Enumerable.Empty<int>();
            }
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

        public static IEnumerable<int> GetVariableIDs(this PSObject inputObject)
        {
            if (TryGetVariables(inputObject, out Variables variables))
                return variables.Select(v => v.ID);

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
    }
}