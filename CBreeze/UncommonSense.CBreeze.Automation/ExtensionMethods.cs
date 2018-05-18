﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Core.Base;
using UncommonSense.CBreeze.Core.Code.Parameter;
using UncommonSense.CBreeze.Core.Code.Variable;
using UncommonSense.CBreeze.Core.Codeunit;
using UncommonSense.CBreeze.Core.Contracts;
using UncommonSense.CBreeze.Core.MenuSuite;
using UncommonSense.CBreeze.Core.Page;
using UncommonSense.CBreeze.Core.Page.Action;
using UncommonSense.CBreeze.Core.Page.Control;
using UncommonSense.CBreeze.Core.Property.Enumeration;
using UncommonSense.CBreeze.Core.Query;
using UncommonSense.CBreeze.Core.Report;
using UncommonSense.CBreeze.Core.Table;
using UncommonSense.CBreeze.Core.XmlPort;
using UncommonSense.CBreeze.Write;
using Object = UncommonSense.CBreeze.Core.Code.Variable.Object;

namespace UncommonSense.CBreeze.Automation
{
    public static class ExtensionMethods
    {
        public static void Add<T>(this Application application, IEnumerable<T> objs) where T : Object
        {
            foreach (var obj in objs)
            {
                application.Add(obj);
            }
        }

        public static T Add<T>(this Application application, T obj) where T : Object
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
            return page.Actions.AddPageActionAtPosition(pageAction, position);
        }

        public static T AddPageControlAtPosition<T>(this PageControls pageControls, T pageControl, Position position) where T : PageControlBase
        {
            switch (position)
            {
                case Position.FirstWithinContainer:
                    pageControls.Insert(0, pageControl);
                    break;

                case Position.LastWithinContainer:
                    pageControls.Add(pageControl);
                    break;
            }

            return pageControl;
        }

        public static T AddPageControlAtPosition<T>(this IPage page, T pageControl, Position position) where T : PageControlBase
        {
            return page.Controls.AddPageControlAtPosition(pageControl, position);
        }

        public static IEnumerable<T> AsEnumerable<T>(this T item) => new[] { item };

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

        public static void Set(this Trigger trigger, ScriptBlock scriptBlock)
        {
            trigger.Variables.Clear();
            trigger.CodeLines.Clear();

            if (scriptBlock != null)
            {
                var subObjects = scriptBlock.Invoke().Select(o => o.BaseObject);
                trigger.Variables.AddRange(subObjects.OfType<Variable>());
                trigger.CodeLines.AddRange(subObjects.OfType<string>());
            }
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

        public static void WriteObjectIf(this Cmdlet cmdlet, bool condition, object value)
        {
            if (condition)
            {
                cmdlet.WriteObject(value);
            }
        }
    }
}