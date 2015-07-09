using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.Model
{
    public class SubsidiaryEntityType : EntityType
    {
        private List<ISubsidiaryTo> subsidiaryTo = new List<ISubsidiaryTo>();
        private DifferentiatorType differentiatorType = DifferentiatorType.LineNo;

        public SubsidiaryEntityType(string name, string pluralName, params ISubsidiaryTo[] subsidiaryTo)
        {
            if (!subsidiaryTo.Any())
                throw new ApplicationException(ExceptionMessages.MustBeSubsidiaryTo);

            Name = name;
            PluralName = pluralName;
            this.subsidiaryTo.AddRange(subsidiaryTo);
        }

        public string Name
        {
            get;
            internal set;
        }

        public string PluralName
        {
            get;
            internal set;
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
