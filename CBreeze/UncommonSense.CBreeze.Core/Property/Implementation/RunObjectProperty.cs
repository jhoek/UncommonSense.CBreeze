namespace UncommonSense.CBreeze.Core.Property.Implementation
{
        public class RunObjectProperty : ReferenceProperty<RunObject>
    {
        internal RunObjectProperty(string name)
            : base(name)
        {
        }

        public override bool HasValue
        {
            get
            {
                return Value.Type.HasValue && Value.ID.HasValue;
            }
        }
    }
}
