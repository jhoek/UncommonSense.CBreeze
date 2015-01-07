using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.Model
{
	public class DocumentEntityType : EntityType
	{
        private string baseName;
        private SetupEntityType setupEntityType;
		private string documentTypeOptions = null;

		internal DocumentEntityType(ApplicationDesign applicationDesign, string baseName, SetupEntityType setupEntityType) : base(applicationDesign)
		{
			this.baseName = baseName;
            this.setupEntityType = setupEntityType;
		}

        public string BaseName
        {
            get
            {
                return this.baseName;
            }
        }

		public string HeaderName
		{
			get
			{
				return string.Format("{0} Header", BaseName);
			}
		}

		public string LineName
		{
			get
			{
				return string.Format("{0} Line", BaseName);
			}
		}

        public SetupEntityType SetupEntityType
        {
            get
            {
                return this.setupEntityType;
            }
        }

		public string DocumentTypeOptions
		{
			get
			{
				return this.documentTypeOptions ?? string.Empty;
			}
			set
			{
				this.documentTypeOptions = value;
			}
		}
	}
}
