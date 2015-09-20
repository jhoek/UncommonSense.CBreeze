using System;
using System.Collections.Generic;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Model;

namespace UncommonSense.CBreeze.Render
{
	public class SubsidiaryEntityTypeManifest : RenderingManifest
	{
		internal SubsidiaryEntityTypeManifest()
		{
            ReferenceFields = new Dictionary<ISubsidiaryTo, CodeTableField>();
		}

		public Table Table
		{
			get;
			internal set;
		}

        public CodeTableField AddReferenceField(CodeTableField referenceField, ISubsidiaryTo subsidiaryTo) 
        {
            ReferenceFields.Add(subsidiaryTo, referenceField);
            return referenceField;
        }

        public Dictionary<ISubsidiaryTo, CodeTableField> ReferenceFields
        {
            get;
            internal set;
        }

        public IntegerTableField LineNoField
        {
            get;
            internal set;
        }

        public CodeTableField CodeField
        {
            get;
            internal set;
        }

        public TableKey PrimaryKey
        {
            get;
            internal set;
        }

		public Page Page
		{
			get;
			internal set;
		}
	}
}

