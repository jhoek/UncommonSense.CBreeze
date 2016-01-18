using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
		public class Function : KeyedItem<int>, IHasName, IHasParameters, IHasVariables
	{
		public Function(int id, string name)
		{
			ID = id;
			Name = name;
			CodeLines = new CodeLines();
			Parameters = new Parameters(this);
			ReturnValue = new FunctionReturnValue();
			Variables = new Variables(this);

#if NAV2016
			EventPublisherObject = new ObjectReference();
#endif
		}

		public string Name
		{
			get;
			protected set;
		}

		public bool? Local
		{
			get;
			set;
		}

		public TransactionModel? TransactionModel
		{
			get;
			set;
		}

		public string HandlerFunctions
		{
			get;
			set;
		}

		public TestFunctionType? TestFunctionType
		{
			get;
			set;
		}

		#if NAV2015
		public UpgradeFunctionType? UpgradeFunctionType
		{
			get;
			set;
		}
		#endif

		#if NAV2016
		public bool? TryFunction
		{
			get;
			set;
		}

		public EventPublisherSubscriber? Event
		{
			get;
			set;
		}

		public EventType EventType
		{
			get;
			set;
		}

		public bool? IncludeSender
		{
			get;
			set;
		}

		public bool? GlobalVarAccess
		{
			get;
			set;
		}

		public ObjectReference EventPublisherObject
		{
			get;
			protected set;
		}

		public string EventFunction
		{
			get;
			set;
		}

		public string EventPublisherElement
		{
			get;
			set;
		}

		public MissingAction? OnMissingLicense
		{
			get;
			set;
		}

		public MissingAction? OnMissingPermission
		{
			get;
			set;
		}
		#endif

		public Functions Container
		{
			get;
			internal set;
		}

		public CodeLines CodeLines
		{
			get;
			protected set;
		}

		public Parameters Parameters
		{
			get;
			protected set;
		}

		public FunctionReturnValue ReturnValue
		{
			get;
			protected set;
		}

		public Variables Variables
		{
			get;
			protected set;
		}

		public string GetName()
		{
			return Name;
		}
	}
}
