using System;
using System.Collections.Generic;
using System.Management.Automation;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation 
{
	// FIXME: Combine methods into one property

	[Cmdlet(VerbsCommon.New, "ColumnQueryElement")]
	[OutputType(typeof(QueryElement))]
	[Alias("Column")]
	public class NewCBreezeColumnQueryElement : NewItemWithIDCmdlet<QueryElement, int, PSObject>
	{
		protected override IEnumerable<QueryElement> CreateItems()
		{
			var columnQueryElement = new ColumnQueryElement();

			

			yield return columnQueryElement;
		}

		protected override void AddItemToInputObject(QueryElement item, PSObject InputObject)
		{
			// FIXME
		}

		[Parameter()]
		public String DataSource { get; set; }

		[Parameter()]
		public String Description { get; set; }

		[Parameter()]
		public Nullable<Boolean> ReverseSign { get; set; }

		[Parameter()]
		[ValidateSet("Day", "Month", "Year", "Sum", "Count", "Average", "Min", "Max")]
		public string Method { get; set; }

		[Parameter()]
		public string Name { get; set; }
	}

	[Cmdlet(VerbsCommon.New, "DataItemQueryElement")]
	[OutputType(typeof(QueryElement))]
	[Alias("DataItem")]
	public class NewCBreezeDataItemQueryElement : NewItemWithIDCmdlet<QueryElement, int, PSObject>
	{
		protected override IEnumerable<QueryElement> CreateItems()
		{
            var dataItemQueryElement = new DataItemQueryElement(0); // FIXME

			

			yield return dataItemQueryElement;
		}

		protected override void AddItemToInputObject(QueryElement item, PSObject InputObject)
		{
			// FIXME
		}

		[Parameter()]
		public Nullable<DataItemLinkType> DataItemLinkType { get; set; }

		[Parameter(Mandatory=true)]
		public Nullable<Int32> DataItemTable { get; set; }

		[Parameter()]
		public DataItemQueryElementTableFilter DataItemTableFilter { get; set; }

		[Parameter()]
		public String Description { get; set; }

		[Parameter()]
		public Nullable<SqlJoinType> SQLJoinType { get; set; }

		[Parameter()]
		public string Name { get; set; }
	}

	[Cmdlet(VerbsCommon.New, "FilterQueryElement")]
	[OutputType(typeof(QueryElement))]
	[Alias("Filter")]
	public class NewCBreezeFilterQueryElement : NewItemWithIDCmdlet<QueryElement, int, PSObject>
	{
		protected override IEnumerable<QueryElement> CreateItems()
		{
			var filterQueryElement = new FilterQueryElement();

			

			yield return filterQueryElement;
		}

		protected override void AddItemToInputObject(QueryElement item, PSObject InputObject)
		{
			// FIXME
		}

		[Parameter()]
		public String DataSource { get; set; }

		[Parameter()]
		public String Description { get; set; }

		[Parameter()]
		public string Name { get; set; }
	}

}

