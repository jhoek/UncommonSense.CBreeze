using System;
using System.Collections.Generic;

namespace CBreeze.NextGen
{
    public class Table : Object, IEquatable<Table>, IHasProperties
    {
        private TableProperties properties;
        private TableFields fields;
        private Code code = new Code();

        public Table(int id, string name) :
            base(id, name)
        {
            this.properties = new TableProperties(this);
            this.fields = new TableFields(this);
        }

        public override ObjectType Type
        {
            get
            {
                return ObjectType.Table;
            }
        }

        public TableProperties Properties
        {
            get
            {
                return this.properties;
            }
        }

        public TableFields Fields
        {
            get
            {
                return this.fields;
            }
        }

        public Code Code
        {
            get
            {
                return this.code;
            }
        }

        public override IEnumerable<INode> ChildNodes
        {
            get
            {
                yield return ObjectProperties;
                yield return Properties;
                yield return Fields;
                yield return Code;
            }
        }

        public bool Equals(Table other)
        {
            if (other == null)
                return false;

            if (other.ID == ID)
                return true;

            if (other.Name == Name)
                return true;

            return false;
        }

        public IProperties GetProperties()
        {
            return Properties;
        }
    }
}

