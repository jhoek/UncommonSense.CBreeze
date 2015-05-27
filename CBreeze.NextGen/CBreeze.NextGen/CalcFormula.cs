using System;

namespace CBreeze.NextGen
{
	public class CalcFormula
	{
		internal CalcFormula()
		{
		}

		public string TableName
		{
			get;
			set;
		}

		public string FieldName
		{
			get;
			set;
		}

		public bool ReverseSign
		{
			get;
			set;
		}

		public CalcFormulaMethod Method
		{
			get;
			set;
		}

		// FIXME:
		//		public CalcFormulaTableFilter TableFilter
		//		{
		//			get;
		//		}
	}
}

