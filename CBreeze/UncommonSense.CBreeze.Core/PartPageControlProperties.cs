using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
        public class PartPageControlProperties : Properties
    {
#if NAV2015
        private AccessByPermissionProperty accessByPermission = new AccessByPermissionProperty("AccessByPermission");
#endif
        private MultiLanguageProperty captionML = new MultiLanguageProperty("CaptionML");
        private StringProperty chartPartID = new StringProperty("ChartPartID");
        private StringProperty description = new StringProperty("Description");
        private StringProperty editable = new StringProperty("Editable");
        private StringProperty enabled = new StringProperty("Enabled");
        private StringProperty name = new StringProperty("Name");
        private PageReferenceProperty pagePartID = new PageReferenceProperty("PagePartID");
        private PartTypeProperty partType = new PartTypeProperty("PartType");
        private NullableIntegerProperty providerID = new NullableIntegerProperty("ProviderID");
        private NullableBooleanProperty showFilter = new NullableBooleanProperty("ShowFilter");
        private RunObjectLinkProperty subPageLink = new RunObjectLinkProperty("SubPageLink");
        private TableViewProperty subPageView = new TableViewProperty("SubPageView");
        private SystemPartIDProperty systemPartID = new SystemPartIDProperty("SystemPartID");
        private MultiLanguageProperty toolTipML = new MultiLanguageProperty("ToolTipML");
#if NAV2015
        private UpdatePropagationProperty updatePropagation = new UpdatePropagationProperty("UpdatePropagation");
#endif
        private StringProperty visible = new StringProperty("Visible");

        internal PartPageControlProperties()
        {
            innerList.Add(name);
#if NAV2015
            innerList.Add(accessByPermission);
#endif
            innerList.Add(captionML);
            innerList.Add(toolTipML);
            innerList.Add(description);
            innerList.Add(subPageView);
            innerList.Add(subPageLink);
            innerList.Add(pagePartID);
            innerList.Add(providerID);
            innerList.Add(visible);
            innerList.Add(enabled);
            innerList.Add(editable);
            innerList.Add(partType);
            innerList.Add(systemPartID);
            innerList.Add(chartPartID);
            innerList.Add(showFilter);
#if NAV2015
            innerList.Add(updatePropagation);
#endif
        }

#if NAV2015
        public AccessByPermission AccessByPermission
        {
            get
            {
                return this.accessByPermission.Value;
            }
        }
#endif

        public MultiLanguageValue CaptionML
        {
            get
            {
                return this.captionML.Value;
            }
        }

      public string ChartPartID
        {
            get
            {
                return this.chartPartID.Value;
            }
            set
            {
                this.chartPartID.Value = value;
            }
        }

      public string Description
        {
            get
            {
                return this.description.Value;
            }
            set
            {
                this.description.Value = value;
            }
        }

      public string Editable
        {
            get
            {
                return this.editable.Value;
            }
            set
            {
                this.editable.Value = value;
            }
        }

      public string Enabled
        {
            get
            {
                return this.enabled.Value;
            }
            set
            {
                this.enabled.Value = value;
            }
        }

      public string Name
        {
            get
            {
                return this.name.Value;
            }
            set
            {
                this.name.Value = value;
            }
        }

      public int? PagePartID
        {
            get
            {
                return this.pagePartID.Value;
            }
            set
            {
                this.pagePartID.Value = value;
            }
        }

        public PartType? PartType
        {
            get
            {
                return this.partType.Value;
            }
            set
            {
                this.partType.Value = value;
            }
        }

      public int? ProviderID
        {
            get
            {
                return this.providerID.Value;
            }
            set
            {
                this.providerID.Value = value;
            }
        }

      public bool? ShowFilter
        {
            get
            {
                return this.showFilter.Value;
            }
            set
            {
                this.showFilter.Value = value;
            }
        }

        public RunObjectLink SubPageLink
        {
            get
            {
                return this.subPageLink.Value;
            }
        }

        public TableView SubPageView
        {
            get
            {
                return this.subPageView.Value;
            }
        }

        public SystemPartID? SystemPartID
        {
            get
            {
                return this.systemPartID.Value;
            }
            set
            {
                this.systemPartID.Value = value;
            }
        }

        public MultiLanguageValue ToolTipML
        {
            get
            {
                return this.toolTipML.Value;
            }
        }

#if NAV2015
        public UpdatePropagation? UpdatePropagation
        {
            get
            {
                return updatePropagation.Value;
            }
            set
            {
                updatePropagation.Value = value;
            }
        }
#endif

      public string Visible
        {
            get
            {
                return this.visible.Value;
            }
            set
            {
                this.visible.Value = value;
            }
        }
    }
}
