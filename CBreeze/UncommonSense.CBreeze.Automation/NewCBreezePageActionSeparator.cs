using System.Collections.Generic;
using System.Management.Automation;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.New, "CBreezePageActionSeparator", DefaultParameterSetName = ParameterSetNames.NewWithoutID)]
    [OutputType(typeof(PageActionSeparator))]
    [Alias("ActionSeparator", "Add-CBreezePageActionSeparator")]
    public class NewCBreezePageActionSeparator : NewItemWithIDCmdlet<PageActionSeparator, int, PSObject>
    {
        protected virtual int GetIndentation()
        {
            return ParameterSetNames.IsNew(ParameterSetName)
                ? (int)GetVariableValue("Indentation", 0)
                : GetParentIndentation() + 1;
        }

        protected int GetParentIndentation()
        {
            switch (InputObject.BaseObject)
            {
                case PageActionContainer c:
                    return c.IndentationLevel.GetValueOrDefault(0);
                case PageActionGroup g:
                    return g.IndentationLevel.GetValueOrDefault(0);
                default:
                    return 0;
            }
        }

        protected override IEnumerable<PageActionSeparator> CreateItems()
        {
            var pageActionSeparator = new PageActionSeparator(ID, GetIndentation());

            pageActionSeparator.Properties.CaptionML.Set("ENU", Caption);
            pageActionSeparator.Properties.IsHeader = IsHeader;

            yield return pageActionSeparator;
        }

        protected override void AddItemToInputObject(PageActionSeparator item, PSObject inputObject)
        {
            switch (InputObject.BaseObject)
            {
                case PageActionContainer c:
                    c.AddChildPageAction(item, Position.GetValueOrDefault(Core.Position.LastWithinContainer));
                    break;
                case PageActionGroup g:
                    g.AddChildPageAction(item, Position.GetValueOrDefault(Core.Position.LastWithinContainer));
                    break;
                case ActionList a:
                    a.AddPageActionAtPosition(item, Position.GetValueOrDefault(Core.Position.LastWithinContainer));
                    break;
                case IPage p:
                    p.AddPageActionAtPosition(item, Position.GetValueOrDefault(Core.Position.LastWithinContainer));
                    break;
                default:
                    base.AddItemToInputObject(item, inputObject);
                    break;
            }

        }

        [Parameter(ParameterSetName = ParameterSetNames.AddWithID)]
        [Parameter(ParameterSetName = ParameterSetNames.AddWithoutID)]
        public Position? Position
        {
            get; set;
        }

        [Parameter()]
        public string Caption
        {
            get; set;
        }

        [Parameter()]
        public bool? IsHeader
        {
            get; set;
        }
    }
}