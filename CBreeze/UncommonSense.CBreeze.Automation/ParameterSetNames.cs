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

        public static IEnumerable<string> Enumerate()
        {
            yield return AddWithID;
            yield return AddWithoutID;
            yield return NewWithID;
            yield return NewWithoutID;
        }

        public static bool IsAdd(string name) => (name == AddWithID) || (name == AddWithoutID);

        public static bool IsNew(string name) => (name == NewWithID) || (name == NewWithoutID);

        public static bool WithID(string name) => (name == AddWithID) || (name == NewWithID);

        public static bool WithoutID(string name) => (name == AddWithoutID) || (name == NewWithoutID);
    }
}