using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.Model
{
    public class SubsidiaryEntityType : EntityType
    {
        private string name;
        private string pluralName;
        private List<ISubsidiaryTo> subsidiaryTo = new List<ISubsidiaryTo>();
        private DifferentiatorType differentiatorType = DifferentiatorType.LineNo;

        internal SubsidiaryEntityType(ApplicationDesign applicationDesign, string name, string pluralName, params ISubsidiaryTo[] subsidiaryTo)
            : base(applicationDesign)
        {
            if (!subsidiaryTo.Any())
                throw new ApplicationException(ExceptionMessages.MustBeSubsidiaryTo);

            this.name = name;
            this.pluralName = pluralName;
            this.subsidiaryTo.AddRange(subsidiaryTo);
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

        public IEnumerable<ISubsidiaryTo> SubsidiaryTo
        {
            get
            {
                foreach (var subsidiaryTo in this.subsidiaryTo)
                {
                    yield return subsidiaryTo;
                }
            }
        }

        public DifferentiatorType DifferentiatorType
        {
            get
            {
                return differentiatorType;
            }
            set
            {
                differentiatorType = value;
            }
        }
    }
}
