using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    public class PageControlPartProperties : Properties
    {
#if NAV2015
        private AccessByPermissionProperty accessByPermission = new AccessByPermissionProperty("AccessByPermission");
#endif
#if NAV2017
        private TagListProperty applicationArea = new TagListProperty("ApplicationArea");
#endif
        private MultiLanguageProperty captionML = new MultiLanguageProperty("CaptionML");
        private StringProperty chartPartID = new StringProperty("ChartPartID");
        private StringProperty description = new StringProperty("Description");
        private StringProperty editable = new StringProperty("Editable");
        private StringProperty enabled = new StringProperty("Enabled");
#if NAV2018
        private StringProperty entityName = new StringProperty("EntityName");
        private StringProperty entitySetName = new StringProperty("EntitySetName");
#endif
        private StringProperty name = new StringProperty("Name");
        private PageReferenceProperty pagePartID = new PageReferenceProperty("PagePartID");
        private PageControlPartTypeProperty partType = new PageControlPartTypeProperty("PartType");
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

        internal PageControlPartProperties(PageControlPart partPageControl)
        {
            PartPageControl = partPageControl;

            innerList.Add(name);
#if NAV2015
            innerList.Add(accessByPermission);
#endif
            innerList.Add(captionML);
            innerList.Add(toolTipML);
#if NAV2017
            innerList.Add(applicationArea);
#endif
            innerList.Add(description);
            innerList.Add(subPageView);
            innerList.Add(subPageLink);
            innerList.Add(pagePartID);
            innerList.Add(providerID);
#if NAV2018
            innerList.Add(entitySetName);
            innerList.Add(entityName);
#endif
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

        public PageControlPart PartPageControl { get; protected set; }

        public override INode ParentNode => PartPageControl;

#if NAV2015

        public AccessByPermission AccessByPermission
        {
            get
            {
                return this.accessByPermission.Value;
            }
        }

#endif

#if NAV2017
        public TagList ApplicationArea => applicationArea.Value;
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

#if NAV2018

        public string EntityName
        {
            get => entityName.Value;
            set => entityName.Value = value;
        }

        public string EntitySetName
        {
            get => entitySetName.Value;
            set => entitySetName.Value = value;
        }

#endif

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

        public PageControlPartType? PartType
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