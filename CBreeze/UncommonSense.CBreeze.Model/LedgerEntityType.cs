using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.Model
{
	public class LedgerEntityType : EntityType
	{
		private string name;
		private string pluralName;
		private bool hasPostingDateField = true;
		private MasterEntityType masterEntityType;
		// FIXME: Amount fields on ledger entries should appears as FlowFields in the master entity type.
		internal LedgerEntityType(ApplicationDesign applicationDesign, string name, string pluralName) : base(applicationDesign)
		{
			this.name = name;
			this.pluralName = pluralName;
		}

		public string Name
		{
			get
			{
				return this.name;
			}
		}

		public string PluralName
		{
			get
			{
				return pluralName;
			}
		}

		public bool HasPostingDateField
		{
			get
			{
				return hasPostingDateField;
			}
			set
			{
				hasPostingDateField = value;
			}
		}

		public MasterEntityType MasterEntityType
		{
			get
			{
				return this.masterEntityType;
			}
			set
			{
				this.masterEntityType = value;
			}
		}
	}
}
