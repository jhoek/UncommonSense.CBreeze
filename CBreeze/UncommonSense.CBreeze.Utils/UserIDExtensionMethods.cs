using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Utils
{
    public class UserIDFieldsManifest
    {
        internal UserIDFieldsManifest()
        {
        }
    }

    public class UserIDControlsManifest
    {
        internal UserIDControlsManifest()
        {
        }
    }

    public static class UserIDExtensionMethods
    {
        public static UserIDFieldsManifest AddUserIDFields(this Table table, IEnumerable<int> range)
        {
            var manifest = new UserIDFieldsManifest();

            return manifest;
        }

        public static UserIDControlsManifest AddUserIDControls(this Page page, UserIDFieldsManifest fieldsManifest, IEnumerable<int> range)
        {
            var manifest = new UserIDControlsManifest();

            return manifest;
        }
    }
}
