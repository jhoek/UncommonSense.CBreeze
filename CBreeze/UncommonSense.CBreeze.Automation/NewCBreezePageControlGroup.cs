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
    [Cmdlet(VerbsCommon.New, "CBreezePageControlGroup", DefaultParameterSetName = ParameterSetNames.NewWithoutID)]
    [OutputType(typeof(PageControlGroup))]
    [Alias("GroupControl", "Add-CBreezePageControlGroup")]
    public class NewCBreezePageControlGroup : NewItemWithIDCmdlet<PageControlBase, int, PSObject>
    {
        protected override void AddItemToInputObject(PageControlBase item, PSObject inputObject)
        {
            switch (inputObject.BaseObject)
            {
                case PageControlContainer c:
                    c.AddChildPageControl(item, Position.GetValueOrDefault(Core.Position.LastWithinContainer));
                    break;

                case PageControlGroup g:
                    g.AddChildPageControl(item, Position.GetValueOrDefault(Core.Position.LastWithinContainer));
                    break;

                case PageControls c:
                    AddItemToInputObject(item, c);
                    break;

                case IPage p:
                    AddItemToInputObject(item, p);
                    break;

                default:
                    base.AddItemToInputObject(item, inputObject);
                    break;
            }
        }

        protected void AddItemToInputObject(PageControlBase item, IPage page) => AddItemToInputObject(item, page.Controls);

        protected void AddItemToInputObject(PageControlBase item, PageControls pageControls) => pageControls.Add(item, Position);

        protected override IEnumerable<PageControlBase> CreateItems()
        {
            var groupPageControl = new PageControlGroup(ID, GetIndentation(), GroupType);
            groupPageControl.Properties.CaptionML.Set(CaptionML);
            groupPageControl.Properties.Description = Description;
            groupPageControl.Properties.Name = Name;
            groupPageControl.Properties.Editable = Editable;
            groupPageControl.Properties.Enabled = Enabled;
            groupPageControl.Properties.FreezeColumnID = FreezeColumnID;
            groupPageControl.Properties.IndentationColumnName = IndentationColumnName;
            groupPageControl.Properties.IndentationControls.Set(IndentationControls);
            groupPageControl.Properties.InstructionalTextML.Set(InstructionalTextML);
            groupPageControl.Properties.Layout = Layout;
            groupPageControl.Properties.ShowAsTree = NullableBooleanFromSwitch(nameof(ShowAsTree));
            groupPageControl.Properties.Visible = Visible;
            groupPageControl.AutoCaption(AutoCaption);
            yield return groupPageControl;

            var variables = new List<PSVariable>() { new PSVariable("Indentation", groupPageControl.IndentationLevel + 1) };
            var childControls = ChildControls?
                .InvokeWithContext(null, variables)
                .Select(o => o.BaseObject)
                .Cast<PageControlBase>()
                ?? Enumerable.Empty<PageControlBase>();

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
            return InputObject.BaseObject is PageControlBase
                ? (InputObject.BaseObject as PageControlBase).IndentationLevel.GetValueOrDefault(0)
                : 0;
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
        [Parameter()] public PageControlGroupType? GroupType { get; set; }
        [Parameter()] public string IndentationColumnName { get; set; }
        [Parameter()] public string[] IndentationControls { get; set; }
        [Parameter()] public Hashtable InstructionalTextML { get; set; }
        [Parameter()] public PageControlGroupLayout? Layout { get; set; }
        [Parameter()] public string Name { get; set; }
        [Parameter()] public Position? Position { get; set; }
        [Parameter()] public SwitchParameter ShowAsTree { get; set; }
        [Parameter()] public string Visible { get; set; }
    }
}