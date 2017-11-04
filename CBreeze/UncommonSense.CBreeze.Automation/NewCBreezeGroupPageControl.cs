using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.New, "CBreezeGroupPageControl", DefaultParameterSetName = ParameterSetNames.NewWithoutID)]
    [OutputType(typeof(GroupPageControl))]
    [Alias("Group")]
    public class NewCBreezeGroupPageControl : NewItemWithIDCmdlet<PageControl, int, PSObject>
    {
        protected override void AddItemToInputObject(PageControl item, PSObject inputObject)
        {
            // FIXME:
            //base.AddItemToInputObject(item, inputObject);
        }

        protected override IEnumerable<PageControl> CreateItems()
        {
            var groupPageControl = new GroupPageControl(ID, GetIndentation(), GroupType.GetValueOrDefault(Core.GroupType.Group));
            groupPageControl.Properties.CaptionML.Set(CaptionML);
            groupPageControl.Properties.Description = Description;
            groupPageControl.Properties.Name = Name;
            groupPageControl.Properties.Editable = Editable;
            groupPageControl.Properties.Enabled = Enabled;
            groupPageControl.Properties.FreezeColumnID = FreezeColumnID;
            groupPageControl.Properties.IndentationColumnName = IndentationColumnName;
            groupPageControl.Properties.IndentationControls.Set(IndentationControls);
            groupPageControl.Properties.Layout = Layout;
            groupPageControl.Properties.ShowAsTree = ShowAsTree;
            groupPageControl.Properties.Visible = Visible;
            groupPageControl.AutoCaption(AutoCaption);
            yield return groupPageControl;

            var variables = new List<PSVariable>() { new PSVariable("Indentation", groupPageControl.IndentationLevel + 1) };
            var childControls = ChildControls?
                .InvokeWithContext(null, variables)
                .Select(o => o.BaseObject)
                .Cast<PageControl>()
                ?? Enumerable.Empty<PageControl>();

            foreach (var childControl in childControls)
            {
                yield return childControl;
            }
        }

        protected int GetIndentation()
        {
            return ParameterSetNames.IsNew(ParameterSetName)
                ? (int)GetVariableValue("Indentation", 0)
                : GetParentIndentation() + 1;
        }

        protected int GetParentIndentation()
        {
            throw new NotImplementedException(); // FIXME
        }

        [Parameter()] public SwitchParameter AutoCaption { get; set; }
        [Parameter()] public Hashtable CaptionML { get; set; }

        [Parameter(Position = 1, ParameterSetName = ParameterSetNames.NewWithoutID)]
        [Parameter(Position = 1, ParameterSetName = ParameterSetNames.AddWithoutID)]
        [Parameter(Position = 2, ParameterSetName = ParameterSetNames.NewWithID)]
        [Parameter(Position = 2, ParameterSetName = ParameterSetNames.AddWithID)]
        public ScriptBlock ChildControls { get; set; }

        [Parameter()] public string Description { get; set; }
        [Parameter()] public string Editable { get; set; }
        [Parameter()] public string Enabled { get; set; }
        [Parameter()] public string FreezeColumnID { get; set; }
        [Parameter()] public GroupType? GroupType { get; set; }
        [Parameter()] public string IndentationColumnName { get; set; }
        [Parameter()] public string[] IndentationControls { get; set; }
        [Parameter()] public GroupPageControlLayout? Layout { get; set; }
        [Parameter()] public string Name { get; set; }
        [Parameter()] public bool? ShowAsTree { get; set; }
        [Parameter()] public string Visible { get; set; }
    }
}