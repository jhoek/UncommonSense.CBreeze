using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Utils;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezePageControl")]
    public class AddCBreezePageControl : CmdletWithDynamicParams
    {
        public AddCBreezePageControl()
        {
            // FIXME: use parameter sets to handle different part types?

            ChartPartID = new DynamicParameter<string>("ChartPartID");
            ContainerType = new DynamicParameter<ContainerType?>("ContainerType");
            Editable = new DynamicParameter<string>("Editable");
            Enabled = new DynamicParameter<string>("Enabled");
            PagePartID = new DynamicParameter<int?>("PagePartID");
            PartType = new DynamicParameter<PartType?>("PartType");
            SystemPartID = new DynamicParameter<SystemPartID?>("SystemPartID");
        }

        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        public Page Page
        {
            get;
            set;
        }

        [Parameter(Mandatory = true)]
        public PageControlType Type
        {
            get;
            set;
        }

        [Parameter(ParameterSetName = "Range")]
        public IEnumerable<int> Range
        {
            get;
            set;
        }

        [Parameter(ParameterSetName = "ID")]
        [ValidateRange(1, int.MaxValue)]
        public int ID
        {
            get;
            set;
        }

        [Parameter()]
        public string Description
        {
            get;
            set;
        }

        [Parameter()]
        public string Name
        {
            get;
            set;
        }

        [Parameter()]
        public SwitchParameter AutoCaption
        {
            get;
            set;
        }

        [Parameter]
        public SwitchParameter PassThru
        {
            get;
            set;
        }

        protected DynamicParameter<string> ChartPartID
        {
            get;
            set;
        }

        protected DynamicParameter<ContainerType?> ContainerType
        {
            get;
            set;
        }

        protected DynamicParameter<string> Editable
        {
            get;
            set;
        }

        protected DynamicParameter<string> Enabled
        {
            get;
            set;
        }

        protected DynamicParameter<int?> PagePartID
        {
            get;
            set;
        }

        protected DynamicParameter<PartType?> PartType
        {
            get;
            set;
        }

        protected DynamicParameter<SystemPartID?> SystemPartID
        {
            get;
            set;
        }

        protected override void ProcessRecord()
        {
            var pageControl = CreatePageControl();

            if (PassThru)
                WriteObject(pageControl);
        }

        protected PageControl CreatePageControl()
        {
            switch (Type)
            {
                case PageControlType.Container:
                    var containerPageControl = new ContainerPageControl(GetPageControlID(), 0);
                    containerPageControl.Properties.Description = Description;
                    containerPageControl.Properties.Name = Name;
                    containerPageControl.Properties.ContainerType = ContainerType.Value;

                    if (AutoCaption)
                        containerPageControl.AutoCaption();

                    return containerPageControl;

                case PageControlType.Group:
                    var groupPageControl = new GroupPageControl(GetPageControlID(), 1);
                    groupPageControl.Properties.Description = Description;
                    groupPageControl.Properties.Name = Name;

                    if (AutoCaption)
                        groupPageControl.AutoCaption();

                    return groupPageControl;

                case PageControlType.Field:
                    var fieldPageControl = new FieldPageControl(GetPageControlID(), 2);
                    fieldPageControl.Properties.Description = Description;
                    fieldPageControl.Properties.Name = Name;

                    if (AutoCaption)
                        fieldPageControl.AutoCaption();

                    return fieldPageControl;

                case PageControlType.Part:
                    var partPageControl = new PartPageControl(GetPageControlID(), 2);
                    partPageControl.Properties.Description = Description;
                    partPageControl.Properties.Name = Name;
                    partPageControl.Properties.ChartPartID = ChartPartID.Value;
                    partPageControl.Properties.Editable = Editable.Value;
                    partPageControl.Properties.Enabled = Enabled.Value;
                    partPageControl.Properties.PartType = PartType.Value;

                    if (AutoCaption)
                        partPageControl.AutoCaption();

                    return partPageControl;
                default:
                    throw new ArgumentOutOfRangeException("Unknown control type.");
            }
        }

        protected int GetPageControlID()
        {
            if (ID != 0)
                return ID;

            var range = Range;

            if (Range.Contains(Page.ID))
                range = 1.To(int.MaxValue);

            return range.Except(Page.Controls.Select(c => c.ID)).First();
        }

        public override IEnumerable<RuntimeDefinedParameter> DynamicParameters
        {
            get
            {
                switch (Type)
                {
                    case PageControlType.Container:
                        yield return ContainerType.RuntimeDefinedParameter;
                        break;

                    case PageControlType.Part:
                        yield return Editable.RuntimeDefinedParameter;
                        yield return Enabled.RuntimeDefinedParameter;
                        yield return PartType.RuntimeDefinedParameter;
                        
                        switch(PartType.Value)
                        {
                            case UncommonSense.CBreeze.Core.PartType.Chart:
                                yield return ChartPartID.RuntimeDefinedParameter;
                                break;
                            case UncommonSense.CBreeze.Core.PartType.Page:
                                yield return PagePartID.RuntimeDefinedParameter;
                                break;
                            case UncommonSense.CBreeze.Core.PartType.System:
                                yield return SystemPartID.RuntimeDefinedParameter;
                                break;
                        }
                        break;
                }
            }
        }
    }
}
