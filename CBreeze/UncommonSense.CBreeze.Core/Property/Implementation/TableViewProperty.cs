using System.Linq;

namespace UncommonSense.CBreeze.Core.Property.Implementation
{
        public class TableViewProperty : ReferenceProperty<TableView>
    {
        internal TableViewProperty(string name)
            : base(name)
        {
        }

        public override bool HasValue
        {
            get
            {
                return Value.Key != null || Value.Order.HasValue || Value.TableFilter.Any();
            }
        }
    }
}
