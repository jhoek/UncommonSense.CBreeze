using System;
using System.Linq;

namespace UncommonSense.CBreeze.Core
{
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
