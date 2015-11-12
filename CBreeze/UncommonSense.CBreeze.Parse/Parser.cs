using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace UncommonSense.CBreeze.Parse
{
	public partial class Parser
	{
		private static NullListener nullListener = new NullListener();
		private IListener listener;

		public void Parse(string fileName)
		{
			Parse(File.ReadLines(fileName, Encoding.GetEncoding("ibm850")));
		}

		public void Parse(IEnumerable<string> source)
		{
			ParseApplication(new Lines(source));
		}

		public IListener Listener
		{
			get
			{
				return listener ?? nullListener;
			}
			set
			{
				listener = value;
			}
		}
	}
}

