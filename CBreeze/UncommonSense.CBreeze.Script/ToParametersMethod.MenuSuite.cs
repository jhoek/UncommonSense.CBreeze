using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Script
{
    public static partial class ToParametersMethod
    {
        public static IEnumerable<ParameterBase> ToParameters(this MenuSuiteNode menuSuiteNode)
        {
            yield return new SimpleParameter("ID", menuSuiteNode.ID);

            foreach (var parameter in menuSuiteNode.AllProperties.Where(p => p.HasValue).SelectMany(p => p.ToParameters()))
            {
                yield return parameter;
            }
        }

        /*
        public static IEnumerable<ParameterBase> ToParameters(this RootNode rootNode)
        {
            yield return new SimpleParameter("ID", rootNode.ID);

            foreach (var property in rootNode.Properties)
            {

            }

            yield return new SimpleParameter("FirstChild", rootNode.Properties.FirstChild);
        }

        public static IEnumerable<ParameterBase> ToParameters(this MenuNode menuNode)
        {
            yield return new SimpleParameter("ID", menuNode.ID);
            yield return new SimpleParameter("Name", menuNode.Properties.Name);
            yield return new SimpleParameter("CaptionML", menuNode.Properties.CaptionML);
            yield return new SimpleParameter("MemberOfMenu", menuNode.Properties.MemberOfMenu);
            yield return new SimpleParameter("ParentNodeID", menuNode.Properties.ParentNodeID);
            yield return new SimpleParameter("Image", menuNode.Properties.Image);
            yield return new SwitchParameter("IsShortcut", menuNode.Properties.IsShortcut);
            yield return new SwitchParameter("Visible", menuNode.Properties.Visible);
            yield return new SwitchParameter("Enabled", menuNode.Properties.Enabled);
            yield return new SimpleParameter("NextNodeID", menuNode.Properties.NextNodeID);
            yield return new SimpleParameter("FirstChild", menuNode.Properties.FirstChild);
        }

        public static IEnumerable<ParameterBase> ToParameters(this DeltaNode deltaNode)
        {
            yield return new SimpleParameter("ID", deltaNode.ID);
            yield return new SwitchParameter("Deleted", deltaNode.Properties.Deleted);
            yield return new SimpleParameter("NextNodeID", deltaNode.Properties.NextNodeID);
        }

        public static IEnumerable<ParameterBase> ToParameters(this GroupNode groupNode)
        {
            yield return new SimpleParameter("ID", groupNode.ID);
            yield return new SimpleParameter("Name", groupNode.Properties.Name);
            yield return new SimpleParameter("CaptionML", groupNode.Properties.CaptionML);
            yield return new SimpleParameter("MemberOfMenu", groupNode.Properties.MemberOfMenu);
            yield return new SimpleParameter("ParentNodeID", groupNode.Properties.ParentNodeID);
            yield return new SwitchParameter("Visible", groupNode.Properties.Visible);
            yield return new SimpleParameter("NextNodeID", groupNode.Properties.NextNodeID);
            yield return new SimpleParameter("FirstChild", groupNode.Properties.FirstChild);
            yield return new SwitchParameter("IsDepartmentPage", groupNode.Properties.IsDepartmentPage);
            yield return new SwitchParameter("Deleted", groupNode.Properties.Deleted);
        }

        public static IEnumerable<ParameterBase> ToParameters(this ItemNode itemNode)
        {
            yield return new SimpleParameter("ID", itemNode.ID);
            yield return new SimpleParameter("Name", itemNode.Properties.Name);
#if NAV2015
            yield return new SimpleParameter("AccessByPermission", itemNode.Properties.AccessByPermission);
#endif
            yield return new SimpleParameter("CaptionML", itemNode.Properties.CaptionML);
#if NAV2017
            yield return new SimpleParameter("ApplicationArea", itemNode.Properties.ApplicationArea);
#endif
            yield return new SimpleParameter("MemberOfMenu", itemNode.Properties.MemberOfMenu);
            yield return new SimpleParameter("RunObjectType", itemNode.Properties.RunObjectType);
            yield return new SimpleParameter("RunObjectID", itemNode.Properties.RunObjectID);
            yield return new SimpleParameter("ParentNodeID", itemNode.Properties.ParentNodeID);
            yield return new SwitchParameter("Visible", itemNode.Properties.Visible);
            yield return new SimpleParameter("NextNodeID", itemNode.Properties.NextNodeID);
            yield return new SwitchParameter("Deleted", itemNode.Properties.Deleted);
            yield return new SimpleParameter("DepartmentCategory", itemNode.Properties.DepartmentCategory);
        }
        */
    }
}
