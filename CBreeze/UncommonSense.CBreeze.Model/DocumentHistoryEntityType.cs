using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.Model
{
	public class DocumentHistoryEntityType : EntityType
	{
		private string headerName;
		private string lineName;

		internal DocumentHistoryEntityType(ApplicationDesign applicationDesign, string headerName, string lineName) : base(applicationDesign)
		{
			this.headerName = headerName;
			this.lineName = lineName;
		}

		public string HeaderName
		{
			get
			{
				return this.headerName;
			}
		}

		public string LineName
		{
			get
			{
				return this.lineName;
			}
		}
	}
}
