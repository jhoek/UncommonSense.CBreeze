using System.Management.Automation;
using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation 
{
	[Cmdlet(VerbsCommon.New, "CBreezeFunction")]
	[OutputType(typeof(Function))]
	[Alias("Procedure")]
	public class NewCBreezeFunctionFIXME : NewItemWithIDAndNameCmdlet<Function, int, PSObject>
	{
		[Parameter()] public bool? Local { get;set; }
		[Parameter()] public string ReturnValueName { get; set; } 
		[Parameter()] public FunctionReturnValueType? ReturnValueType { get; set; }
		[Parameter()] [ValidateRange(1, int.MaxValue)] public int? ReturnValueDataLength { get; set; }
		[Parameter()] public string ReturnValueDimensions { get; set; }
	}

	[Cmdlet(VerbsCommon.New, "CBreezeTestFunction")]
	[OutputType(typeof(Function))]
	[Alias("TestFunction")]
	public class NewCBreezeTestFunctionFIXME : NewItemWithIDAndNameCmdlet<Function, int, PSObject>
	{
		[Parameter()] public bool? Local { get;set; }
		[Parameter()] public string ReturnValueName { get; set; } 
		[Parameter()] public FunctionReturnValueType? ReturnValueType { get; set; }
		[Parameter()] [ValidateRange(1, int.MaxValue)] public int? ReturnValueDataLength { get; set; }
		[Parameter()] public string ReturnValueDimensions { get; set; }
		[Parameter()] public string HandlerFunctions { get; set; }
		[Parameter()] public TestFunctionType? TestFunctionType { get; set; } 
		[Parameter()] public TransactionModel? TransactionModel { get; set; }
	}

	[Cmdlet(VerbsCommon.New, "CBreezeUpgradeFunction")]
	[OutputType(typeof(Function))]
	[Alias("UpgradeFunction")]
	public class NewCBreezeUpgradeFunctionFIXME : NewItemWithIDAndNameCmdlet<Function, int, PSObject>
	{
		[Parameter()] public bool? Local { get;set; }
		[Parameter()] public string ReturnValueName { get; set; } 
		[Parameter()] public FunctionReturnValueType? ReturnValueType { get; set; }
		[Parameter()] [ValidateRange(1, int.MaxValue)] public int? ReturnValueDataLength { get; set; }
		[Parameter()] public string ReturnValueDimensions { get; set; }
#if NAV2015
		[Parameter()] public UpgradeFunctionType? UpgradeFunctionType { get; set; } 
#endif
	}

#if NAV2016
	[Cmdlet(VerbsCommon.New, "CBreezeEventSubscriberFunction")]
	[OutputType(typeof(Function))]
	[Alias("EventSubscriber")]
	public class NewCBreezeEventSubscriberFunctionFIXME : NewItemWithIDAndNameCmdlet<Function, int, PSObject>
	{
		[Parameter()] public bool? Local { get;set; }
		[Parameter()] public string ReturnValueName { get; set; } 
		[Parameter()] public FunctionReturnValueType? ReturnValueType { get; set; }
		[Parameter()] [ValidateRange(1, int.MaxValue)] public int? ReturnValueDataLength { get; set; }
		[Parameter()] public string ReturnValueDimensions { get; set; }
		[Parameter(Mandatory = true)] public ObjectType EventPublisherObjectType { get; set; } 
		[Parameter(Mandatory = true)] public int EventPublisherObjectID { get; set; } 
		[Parameter()] public string EventPublisherElement { get; set; } 
		[Parameter(Mandatory = true)] public string EventFunction { get; set; } 
	}
#endif

#if NAV2016
	[Cmdlet(VerbsCommon.New, "CBreezeBusinessEventPublisherFunction")]
	[OutputType(typeof(Function))]
	[Alias("BusinessEvent")]
	public class NewCBreezeBusinessEventPublisherFunctionFIXME : NewItemWithIDAndNameCmdlet<Function, int, PSObject>
	{
		[Parameter()] public bool? Local { get;set; }
		[Parameter()] public string ReturnValueName { get; set; } 
		[Parameter()] public FunctionReturnValueType? ReturnValueType { get; set; }
		[Parameter()] [ValidateRange(1, int.MaxValue)] public int? ReturnValueDataLength { get; set; }
		[Parameter()] public string ReturnValueDimensions { get; set; }
		[Parameter()] public bool? IncludeSender { get; set; } 
	}
#endif

#if NAV2016
	[Cmdlet(VerbsCommon.New, "CBreezeIntegrationEventPublisherFunction")]
	[OutputType(typeof(Function))]
	[Alias("IntegrationEvent")]
	public class NewCBreezeIntegrationEventPublisherFunctionFIXME : NewItemWithIDAndNameCmdlet<Function, int, PSObject>
	{
		[Parameter()] public bool? Local { get;set; }
		[Parameter()] public string ReturnValueName { get; set; } 
		[Parameter()] public FunctionReturnValueType? ReturnValueType { get; set; }
		[Parameter()] [ValidateRange(1, int.MaxValue)] public int? ReturnValueDataLength { get; set; }
		[Parameter()] public string ReturnValueDimensions { get; set; }
		[Parameter()] public bool? IncludeSender { get; set; }
		[Parameter()] public bool? GlobalVarAccess { get; set; } 
	}
#endif

}