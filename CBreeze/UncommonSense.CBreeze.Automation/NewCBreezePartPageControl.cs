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
    [Cmdlet(VerbsCommon.New, "CBreezeNewPartPageControl", DefaultParameterSetName = ParameterSetNames.NewWithoutID)]
    [OutputType(typeof(PartPageControl))]
    [Alias("PartControl")]
    public class NewCBreezePartPageControl : NewItemWithIDCmdlet<PageControl, int, PSObject>
    {
        [Parameter()] public SwitchParameter AutoCaption { get; set; }
        [Parameter()] public Hashtable CaptionML { get; set; }
        [Parameter()] public string ChartPartID { get; set; }
        [Parameter()] public string Description { get; set; }
        [Parameter()] public string Editable { get; set; }
        [Parameter()] public string Enabled { get; set; }
        [Parameter()] public string Name { get; set; }
        [Parameter()] public int? PagePartID { get; set; }
        [Parameter()] public int? ProviderID { get; set; }
        [Parameter()] public bool ShowFilter { get; set; }
        [Parameter()] public string SubPageViewKey { get; set; }
        [Parameter()] public Order? SubPageViewOrder { get; set; }
        [Parameter()] public SystemPartID? SystemPartID { get; set; }
#if NAV2015
        [Parameter()] public UpdatePropagation? UpdatePropagation { get; set; }
#endif
        [Parameter()] public string Visible { get; set; }

        protected override void AddItemToInputObject(PageControl item, PSObject inputObject)
        {
        }

        protected override IEnumerable<PageControl> CreateItems()
        {
            //throw new NotImplementedException();
        }
    }
}