using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.Model
{
	public class DocumentHistoryEntityType : EntityType
	{
		public DocumentHistoryEntityType(string headerName, string lineName) 
		{
			HeaderName = headerName;
			LineName = lineName;
		}

		public string HeaderName
		{
			get;
            internal set;
		}

		public string LineName
		{
			get;internal set;
		}
	}
}
