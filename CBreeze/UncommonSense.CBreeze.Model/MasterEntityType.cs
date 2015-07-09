using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.Model
{
    public class MasterEntityType : EntityType, ISubsidiaryTo
    {
        public MasterEntityType(string name, SetupEntityType setupEntityType)
        {
            Name = name;
            SetupEntityType = setupEntityType;
            DescriptionStyle = Model.DescriptionStyle.Description;
            HasDescription2Field = true;
            HasSearchDescriptionField = true;
            HasLastDateModifiedField = true;
            HasStatisticsPage = true;
        }

        public string Name
        {
            get;
            internal set;
        }

        public SetupEntityType SetupEntityType
        {
            get;
            internal set;
        }

        public DescriptionStyle DescriptionStyle
        {
            get;
            set;
        }

        public bool HasDescription2Field
        {
            get;
            set;
        }

        public bool HasSearchDescriptionField
        {
            get;
            set;
        }

        public bool HasLastDateModifiedField
        {
            get;
            set;
        }

        public bool HasStatisticsPage
        {
            get;set;
        }
    }
}
