using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.CBreeze.Automation
{
    public static class ParameterSetNames
    {
        public const string AddWithID = "AddWithID";
        public const string AddWithoutID = "AddWithoutID";
        public const string NewWithID = "NewWithID";
        public const string NewWithoutID = "NewWithoutID";

        public static bool IsAdd(string name) => (name == AddWithID) || (name == AddWithoutID);

        public static bool IsNew(string name) => (name == NewWithID) || (name == NewWithoutID);
    }
}