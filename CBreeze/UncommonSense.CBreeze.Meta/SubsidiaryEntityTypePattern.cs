using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Meta
{
    public class SubsidiaryEntityTypePattern : EntityTypePattern
    {
        private string pluralName;
        private List<Table> subsidiaryTo = new List<Table>();

        public SubsidiaryEntityTypePattern(Application application, IEnumerable<int> range, string name, params Table[] subsidiaryTo)
            : base(application, range, name)
        {
            DifferentiatorType = DifferentiatorType.None;
            this.subsidiaryTo.AddRange(subsidiaryTo);
        }

        protected override void VerifyRequirements()
        {
            if (!SubsidiaryTo.Any())
                throw new ArgumentOutOfRangeException("SubsidiaryTo");
        }

        public string PluralName
        {
            get
            {
                return this.pluralName ?? string.Format("{0}s", Name);
            }
            set
            {
                this.pluralName = value;
            }
        }

        public DifferentiatorType DifferentiatorType
        {
            get;
            set;
        }
        
        public IEnumerable<Table> SubsidiaryTo
        {
            get
            {
                return subsidiaryTo.AsEnumerable();
            }
        }
    }
}
