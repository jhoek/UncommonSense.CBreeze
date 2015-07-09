using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.Demo
{
    public class CommandLine
    {
        internal CommandLine(string[] args)
        {
            IsValid = args.Length == 2;

            if (IsValid)
            {
                InputFileName = args[0];
                OutputFileName = args[1];
            }
        }

        public bool IsValid
        {
            get;
            internal set;
        }

        public string InputFileName
        {
            get;
            internal set;
        }

        public string OutputFileName
        {
            get;
            internal set;
        }
    }
}
