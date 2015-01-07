using System;
using System.Linq;

namespace UncommonSense.CBreeze.Core
{
    public abstract partial class Object
    {
        public abstract ObjectType Type
        {
            get;
        }
    }

    public partial class Table
    {
        public override ObjectType Type
        {
            get
            {
                return ObjectType.Table;
            }
        }
    }

    public partial class Page
    {
        public override ObjectType Type
        {
            get
            {
                return ObjectType.Page;
            }
        }
    }

    public partial class Report
    {
        public override ObjectType Type
        {
            get
            {
                return ObjectType.Report;
            }
        }
    }

    public partial class Codeunit
    {
        public override ObjectType Type
        {
            get
            {
                return ObjectType.Codeunit;
            }
        }
    }

    public partial class MenuSuite
    {
        public override ObjectType Type
        {
            get
            {
                return ObjectType.MenuSuite;
            }
        }
    }

    public partial class Query
    {
        public override ObjectType Type
        {
            get
            {
                return ObjectType.Query;
            }
        }
    }

    public partial class XmlPort
    {
        public override ObjectType Type
        {
            get
            {
                return ObjectType.XmlPort;
            }
        }
    }

    public abstract partial class TableField
    {
        public abstract Property GetPropertyByName(string name);
    }

    public partial class BigIntegerTableField
    {
        public override Property GetPropertyByName(string name)
        {
            return this.Properties.FirstOrDefault(p => p.Name == name);
        }
    }

    public partial class BinaryTableField
    {
        public override Property GetPropertyByName(string name)
        {
            return this.Properties.FirstOrDefault(p => p.Name == name);
        }
    }

    public partial class BlobTableField
    {
        public override Property GetPropertyByName(string name)
        {
            return this.Properties.FirstOrDefault(p => p.Name == name);
        }
    }

    public partial class BooleanTableField
    {
        public override Property GetPropertyByName(string name)
        {
            return this.Properties.FirstOrDefault(p => p.Name == name);
        }
    }

    public partial class CodeTableField
    {
        public override Property GetPropertyByName(string name)
        {
            return this.Properties.FirstOrDefault(p => p.Name == name);
        }
    }

    public partial class DateFormulaTableField
    {
        public override Property GetPropertyByName(string name)
        {
            return this.Properties.FirstOrDefault(p => p.Name == name);
        }
    }

    public partial class DateTableField
    {
        public override Property GetPropertyByName(string name)
        {
            return this.Properties.FirstOrDefault(p => p.Name == name);
        }
    }

    public partial class DateTimeTableField
    {
        public override Property GetPropertyByName(string name)
        {
            return this.Properties.FirstOrDefault(p => p.Name == name);
        }
    }

    public partial class DecimalTableField
    {
        public override Property GetPropertyByName(string name)
        {
            return this.Properties.FirstOrDefault(p => p.Name == name);
        }
    }

    public partial class DurationTableField
    {
        public override Property GetPropertyByName(string name)
        {
            return this.Properties.FirstOrDefault(p => p.Name == name);
        }
    }

    public partial class GuidTableField
    {
        public override Property GetPropertyByName(string name)
        {
            return this.Properties.FirstOrDefault(p => p.Name == name);
        }
    }

    public partial class IntegerTableField
    {
        public override Property GetPropertyByName(string name)
        {
            return this.Properties.FirstOrDefault(p => p.Name == name);
        }
    }

    public partial class OptionTableField
    {
        public override Property GetPropertyByName(string name)
        {
            return this.Properties.FirstOrDefault(p => p.Name == name);
        }
    }

    public partial class RecordIDTableField
    {
        public override Property GetPropertyByName(string name)
        {
            return this.Properties.FirstOrDefault(p => p.Name == name);
        }
    }

    public partial class TableFilterTableField
    {
        public override Property GetPropertyByName(string name)
        {
            return this.Properties.FirstOrDefault(p => p.Name == name);
        }
    }

    public partial class TextTableField
    {
        public override Property GetPropertyByName(string name)
        {
            return this.Properties.FirstOrDefault(p => p.Name == name);
        }
    }

    public partial class TimeTableField
    {
        public override Property GetPropertyByName(string name)
        {
            return this.Properties.FirstOrDefault(p => p.Name == name);
        }
    }
}
