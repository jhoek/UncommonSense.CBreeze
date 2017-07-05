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
			// FIXME
			throw new NotImplementedException();
		}

		protected override void AddItemToInputObject(QueryElement item, PSObject InputObject)
		{
			// FIXME
		}

	[Parameter()]
	public String DataSource { get; set; }

	[Parameter()]
	public Nullable<DateMethod> DateMethod { get; set; }

	[Parameter()]
	public String Description { get; set; }

	[Parameter()]
	public Nullable<MethodType> MethodType { get; set; }

	[Parameter()]
	public Nullable<Boolean> ReverseSign { get; set; }

	[Parameter()]
	public Nullable<TotalsMethod> TotalsMethod { get; set; }

	}

	[Cmdlet(VerbsCommon.New, "DataItemQueryElement")]
	[OutputType(typeof(QueryElement))]
	[Alias("DataItem")]
	public class NewCBreezeDataItemQueryElement : NewItemWithIDCmdlet<QueryElement, int, PSObject>
	{
		protected override IEnumerable<QueryElement> CreateItems()
		{
			// FIXME
			throw new NotImplementedException();
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

	}

	[Cmdlet(VerbsCommon.New, "FilterQueryElement")]
	[OutputType(typeof(QueryElement))]
	[Alias("Filter")]
	public class NewCBreezeFilterQueryElement : NewItemWithIDCmdlet<QueryElement, int, PSObject>
	{
		protected override IEnumerable<QueryElement> CreateItems()
		{
			// FIXME
			throw new NotImplementedException();
		}

		protected override void AddItemToInputObject(QueryElement item, PSObject InputObject)
		{
			// FIXME
		}

	[Parameter()]
	public String DataSource { get; set; }

	[Parameter()]
	public String Description { get; set; }

	}

}

