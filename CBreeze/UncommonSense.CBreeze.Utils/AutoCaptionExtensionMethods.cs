using System;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Utils
{
	public static class AutoCaptionExtensionMethods
	{
		public static Page AutoCaption(this Page item)
		{
			item.Properties.CaptionML.Set("ENU", item.Name);
			return item;
		}

		public static Query AutoCaption(this Query item)
		{
			item.Properties.CaptionML.Set("ENU", item.Name);
			return item;
		}

		public static Report AutoCaption(this Report item)
		{
			item.Properties.CaptionML.Set("ENU", item.Name);
			return item;
		}

		public static Table AutoCaption(this Table item)
		{
			item.Properties.CaptionML.Set("ENU", item.Name);
			return item;
		}

		public static XmlPort AutoCaption(this XmlPort item)
		{
			item.Properties.CaptionML.Set("ENU", item.Name);
			return item;
		}

		public static BigIntegerTableField AutoCaption(this BigIntegerTableField item)
		{
			item.Properties.CaptionML.Set("ENU", item.Name);
			return item;
		}

		public static BinaryTableField AutoCaption(this BinaryTableField item)
		{
			item.Properties.CaptionML.Set("ENU", item.Name);
			return item;
		}

		public static BlobTableField AutoCaption(this BlobTableField item)
		{
			item.Properties.CaptionML.Set("ENU", item.Name);
			return item;
		}

		public static BooleanTableField AutoCaption(this BooleanTableField item)
		{
			item.Properties.CaptionML.Set("ENU", item.Name);
			return item;
		}

		public static CodeTableField AutoCaption(this CodeTableField item)
		{
			item.Properties.CaptionML.Set("ENU", item.Name);
			return item;
		}

		public static DateFormulaTableField AutoCaption(this DateFormulaTableField item)
		{
			item.Properties.CaptionML.Set("ENU", item.Name);
			return item;
		}

		public static DateTableField AutoCaption(this DateTableField item)
		{
			item.Properties.CaptionML.Set("ENU", item.Name);
			return item;
		}

		public static DateTimeTableField AutoCaption(this DateTimeTableField item)
		{
			item.Properties.CaptionML.Set("ENU", item.Name);
			return item;
		}

		public static DecimalTableField AutoCaption(this DecimalTableField item)
		{
			item.Properties.CaptionML.Set("ENU", item.Name);
			return item;
		}

		public static DurationTableField AutoCaption(this DurationTableField item)
		{
			item.Properties.CaptionML.Set("ENU", item.Name);
			return item;
		}

		public static GuidTableField AutoCaption(this GuidTableField item)
		{
			item.Properties.CaptionML.Set("ENU", item.Name);
			return item;
		}

		public static IntegerTableField AutoCaption(this IntegerTableField item)
		{
			item.Properties.CaptionML.Set("ENU", item.Name);
			return item;
		}

		public static OptionTableField AutoCaption(this OptionTableField item)
		{
			item.Properties.CaptionML.Set("ENU", item.Name);
			return item;
		}

		public static RecordIDTableField AutoCaption(this RecordIDTableField item)
		{
			item.Properties.CaptionML.Set("ENU", item.Name);
			return item;
		}

		public static TableFilterTableField AutoCaption(this TableFilterTableField item)
		{
			item.Properties.CaptionML.Set("ENU", item.Name);
			return item;
		}

		public static TextTableField AutoCaption(this TextTableField item)
		{
			item.Properties.CaptionML.Set("ENU", item.Name);
			return item;
		}

		public static TimeTableField AutoCaption(this TimeTableField item)
		{
			item.Properties.CaptionML.Set("ENU", item.Name);
			return item;
		}


		public static OptionTableField AutoOptionCaption(this OptionTableField item)
		{
			item.Properties.OptionCaptionML.Set("ENU", item.Properties.OptionString);
			return item;
		}
	}
}