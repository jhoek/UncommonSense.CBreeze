using System;
using System.Linq;
using UncommonSense.CBreeze.Core;
using System.Management.Automation;

namespace UncommonSense.CBreeze.Automation 
{
	[Cmdlet(VerbsCommon.New, "CBreezeDeltaMenuSuiteNode", DefaultParameterSetName="NewWithoutID")]
	[OutputType(typeof(DeltaNode))]
	[Alias("DeltaNode")]
	public class NewCBreezeDeltaMenuSuiteNode : NewItemWithIDCmdlet<DeltaNode, Guid, MenuSuite>
	{
		protected override DeltaNode CreateItem() 
		{
			var deltaNode = new DeltaNode(ID);	
			deltaNode.Properties.Deleted = Deleted;
			deltaNode.Properties.NextNodeID = NextNodeID;
			return deltaNode;
		}

		protected override void AddItemToInputObject(DeltaNode item, MenuSuite inputObject)
		{
            if (!inputObject.Nodes.Any())
            {
                var deltaNode = inputObject.Nodes.Add(new DeltaNode(Guid.NewGuid()));
                deltaNode.Properties.NextNodeID = item.ID;
            }

            inputObject.Nodes.Add(item);
		}

		[Parameter()]
		public Nullable<Boolean> Deleted 
		{
			get; set;
		}

		[Parameter()]
		public Nullable<Guid> NextNodeID 
		{
			get; set;
		}

	}

	[Cmdlet(VerbsCommon.New, "CBreezeGroupMenuSuiteNode", DefaultParameterSetName="NewWithoutID")]
	[OutputType(typeof(GroupNode))]
	[Alias("GroupNode")]
	public class NewCBreezeGroupMenuSuiteNode : NewItemWithIDCmdlet<GroupNode, Guid, MenuSuite>
	{
		protected override GroupNode CreateItem() 
		{
			var groupNode = new GroupNode(ID);	
			groupNode.Properties.FirstChild = FirstChild;
			groupNode.Properties.IsDepartmentPage = IsDepartmentPage;
			groupNode.Properties.MemberOfMenu = MemberOfMenu;
			groupNode.Properties.Name = Name;
			groupNode.Properties.NextNodeID = NextNodeID;
			groupNode.Properties.ParentNodeID = ParentNodeID;
			groupNode.Properties.Visible = Visible;
			groupNode.Properties.CaptionML.Set("ENU", Caption);
			return groupNode;
		}

		protected override void AddItemToInputObject(GroupNode item, MenuSuite inputObject)
		{
            if (!inputObject.Nodes.Any())
            {
                var deltaNode = inputObject.Nodes.Add(new DeltaNode(Guid.NewGuid()));
                deltaNode.Properties.NextNodeID = item.ID;
            }

            inputObject.Nodes.Add(item);
		}

		[Parameter()]
		public Nullable<Guid> FirstChild 
		{
			get; set;
		}

		[Parameter()]
		public Nullable<Boolean> IsDepartmentPage 
		{
			get; set;
		}

		[Parameter()]
		public Nullable<Guid> MemberOfMenu 
		{
			get; set;
		}

		[Parameter()]
		public String Name 
		{
			get; set;
		}

		[Parameter()]
		public Nullable<Guid> NextNodeID 
		{
			get; set;
		}

		[Parameter()]
		public Nullable<Guid> ParentNodeID 
		{
			get; set;
		}

		[Parameter()]
		public Nullable<Boolean> Visible 
		{
			get; set;
		}

		[Parameter(Mandatory = true, Position = 2, ParameterSetName = ParameterSetNames.AddWithID)]
		[Parameter(Mandatory = true, Position = 1, ParameterSetName = ParameterSetNames.AddWithoutID)]
		[Parameter(Mandatory = true, Position = 2, ParameterSetName = ParameterSetNames.NewWithID)]
		[Parameter(Mandatory = true, Position = 1, ParameterSetName = ParameterSetNames.NewWithoutID)]
		public String Caption 
		{
			get; set;
		}

	}

	[Cmdlet(VerbsCommon.New, "CBreezeItemMenuSuiteNode", DefaultParameterSetName="NewWithoutID")]
	[OutputType(typeof(ItemNode))]
	[Alias("ItemNode")]
	public class NewCBreezeItemMenuSuiteNode : NewItemWithIDCmdlet<ItemNode, Guid, MenuSuite>
	{
		protected override ItemNode CreateItem() 
		{
			var itemNode = new ItemNode(ID);	
			itemNode.Properties.Deleted = Deleted;
			itemNode.Properties.DepartmentCategory = DepartmentCategory;
			itemNode.Properties.MemberOfMenu = MemberOfMenu;
			itemNode.Properties.Name = Name;
			itemNode.Properties.NextNodeID = NextNodeID;
			itemNode.Properties.ParentNodeID = ParentNodeID;
			itemNode.Properties.Visible = Visible;
			itemNode.Properties.CaptionML.Set("ENU", Caption);
			itemNode.Properties.RunObjectType = RunObjectType;
			itemNode.Properties.RunObjectID = RunObjectID;
			return itemNode;
		}

		protected override void AddItemToInputObject(ItemNode item, MenuSuite inputObject)
		{
            if (!inputObject.Nodes.Any())
            {
                var deltaNode = inputObject.Nodes.Add(new DeltaNode(Guid.NewGuid()));
                deltaNode.Properties.NextNodeID = item.ID;
            }

            inputObject.Nodes.Add(item);
		}

		[Parameter()]
		public Nullable<Boolean> Deleted 
		{
			get; set;
		}

		[Parameter(Mandatory=true)]
		public Nullable<MenuItemDepartmentCategory> DepartmentCategory 
		{
			get; set;
		}

		[Parameter()]
		public Nullable<Guid> MemberOfMenu 
		{
			get; set;
		}

		[Parameter()]
		public String Name 
		{
			get; set;
		}

		[Parameter()]
		public Nullable<Guid> NextNodeID 
		{
			get; set;
		}

		[Parameter()]
		public Nullable<Guid> ParentNodeID 
		{
			get; set;
		}

		[Parameter()]
		public Nullable<Boolean> Visible 
		{
			get; set;
		}

		[Parameter(Mandatory = true, Position = 2, ParameterSetName = ParameterSetNames.AddWithID)]
		[Parameter(Mandatory = true, Position = 1, ParameterSetName = ParameterSetNames.AddWithoutID)]
		[Parameter(Mandatory = true, Position = 2, ParameterSetName = ParameterSetNames.NewWithID)]
		[Parameter(Mandatory = true, Position = 1, ParameterSetName = ParameterSetNames.NewWithoutID)]
		public String Caption 
		{
			get; set;
		}

		[Parameter(Mandatory = true, Position = 3, ParameterSetName = ParameterSetNames.AddWithID)]
		[Parameter(Mandatory = true, Position = 2, ParameterSetName = ParameterSetNames.AddWithoutID)]
		[Parameter(Mandatory = true, Position = 3, ParameterSetName = ParameterSetNames.NewWithID)]
		[Parameter(Mandatory = true, Position = 2, ParameterSetName = ParameterSetNames.NewWithoutID)]
		public Nullable<MenuItemRunObjectType> RunObjectType 
		{
			get; set;
		}

		[Parameter(Mandatory = true, Position = 4, ParameterSetName = ParameterSetNames.AddWithID)]
		[Parameter(Mandatory = true, Position = 3, ParameterSetName = ParameterSetNames.AddWithoutID)]
		[Parameter(Mandatory = true, Position = 4, ParameterSetName = ParameterSetNames.NewWithID)]
		[Parameter(Mandatory = true, Position = 3, ParameterSetName = ParameterSetNames.NewWithoutID)]
		[ValidateRange(1, int.MaxValue)] 
		public Nullable<Int32> RunObjectID 
		{
			get; set;
		}

	}

	[Cmdlet(VerbsCommon.New, "CBreezeMenuMenuSuiteNode", DefaultParameterSetName="NewWithoutID")]
	[OutputType(typeof(MenuNode))]
	[Alias("MenuNode")]
	public class NewCBreezeMenuMenuSuiteNode : NewItemWithIDCmdlet<MenuNode, Guid, MenuSuite>
	{
		protected override MenuNode CreateItem() 
		{
			var menuNode = new MenuNode(ID);	
			menuNode.Properties.Enabled = Enabled;
			menuNode.Properties.FirstChild = FirstChild;
			menuNode.Properties.Image = Image;
			menuNode.Properties.IsShortcut = IsShortcut;
			menuNode.Properties.MemberOfMenu = MemberOfMenu;
			menuNode.Properties.Name = Name;
			menuNode.Properties.NextNodeID = NextNodeID;
			menuNode.Properties.ParentNodeID = ParentNodeID;
			menuNode.Properties.Visible = Visible;
			menuNode.Properties.CaptionML.Set("ENU", Caption);
			return menuNode;
		}

		protected override void AddItemToInputObject(MenuNode item, MenuSuite inputObject)
		{
            if (!inputObject.Nodes.Any())
            {
                var deltaNode = inputObject.Nodes.Add(new DeltaNode(Guid.NewGuid()));
                deltaNode.Properties.NextNodeID = item.ID;
            }

            inputObject.Nodes.Add(item);
		}

		[Parameter()]
		public Nullable<Boolean> Enabled 
		{
			get; set;
		}

		[Parameter()]
		public Nullable<Guid> FirstChild 
		{
			get; set;
		}

		[Parameter()]
		[ValidateRange(0, 15)] 
		public Nullable<Int32> Image 
		{
			get; set;
		}

		[Parameter()]
		public Nullable<Boolean> IsShortcut 
		{
			get; set;
		}

		[Parameter()]
		public Nullable<Guid> MemberOfMenu 
		{
			get; set;
		}

		[Parameter()]
		public String Name 
		{
			get; set;
		}

		[Parameter()]
		public Nullable<Guid> NextNodeID 
		{
			get; set;
		}

		[Parameter()]
		public Nullable<Guid> ParentNodeID 
		{
			get; set;
		}

		[Parameter()]
		public Nullable<Boolean> Visible 
		{
			get; set;
		}

		[Parameter(Mandatory = true, Position = 2, ParameterSetName = ParameterSetNames.AddWithID)]
		[Parameter(Mandatory = true, Position = 1, ParameterSetName = ParameterSetNames.AddWithoutID)]
		[Parameter(Mandatory = true, Position = 2, ParameterSetName = ParameterSetNames.NewWithID)]
		[Parameter(Mandatory = true, Position = 1, ParameterSetName = ParameterSetNames.NewWithoutID)]
		public String Caption 
		{
			get; set;
		}

	}

	[Cmdlet(VerbsCommon.New, "CBreezeRootMenuSuiteNode", DefaultParameterSetName="NewWithoutID")]
	[OutputType(typeof(RootNode))]
	[Alias("RootNode")]
	public class NewCBreezeRootMenuSuiteNode : NewItemWithIDCmdlet<RootNode, Guid, MenuSuite>
	{
		protected override RootNode CreateItem() 
		{
			var rootNode = new RootNode(ID);	
			rootNode.Properties.FirstChild = FirstChild;
			return rootNode;
		}

		protected override void AddItemToInputObject(RootNode item, MenuSuite inputObject)
		{
            if (!inputObject.Nodes.Any())
            {
                var deltaNode = inputObject.Nodes.Add(new DeltaNode(Guid.NewGuid()));
                deltaNode.Properties.NextNodeID = item.ID;
            }

            inputObject.Nodes.Add(item);
		}

		[Parameter()]
		public Nullable<Guid> FirstChild 
		{
			get; set;
		}

	}

}

