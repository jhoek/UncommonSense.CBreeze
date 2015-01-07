using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.Model
{
	public class RegisterEntityType : EntityType
	{
		private string name;
		private bool hasSourceCodeField = true;
		private List<LedgerEntityType> ledgerEntityTypes = new List<LedgerEntityType>();

		internal RegisterEntityType(ApplicationDesign applicationDesign, string name, params LedgerEntityType[] ledgerEntityTypes) : base(applicationDesign)
		{
			this.name = name;
			this.ledgerEntityTypes.AddRange(ledgerEntityTypes);
		}

		public string Name
		{
			get
			{
				return name;
			}
		}

		public bool HasSourceCodeField
		{
			get
			{
				return hasSourceCodeField;
			}
			set
			{
				hasSourceCodeField = value;
			}
		}

		public IEnumerable<LedgerEntityType> LedgerEntityTypes
		{
			get
			{
				foreach (var ledgerEntityType in ledgerEntityTypes)
				{
					yield return ledgerEntityType;
				}
			}
		}
	}
}
