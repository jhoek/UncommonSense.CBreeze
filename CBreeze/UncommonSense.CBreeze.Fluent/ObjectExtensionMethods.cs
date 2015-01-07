using System;

namespace UncommonSense.CBreeze.Fluent
{
	public static class ObjectExtensionMethods
	{
		public static UncommonSense.CBreeze.Core.Object WithModificationDate(this UncommonSense.CBreeze.Core.Object @object, DateTime dateTime)
		{
			@object.ObjectProperties.DateTime = dateTime;
			return @object;
		}

		public static UncommonSense.CBreeze.Core.Object WithModifiedFlag(this UncommonSense.CBreeze.Core.Object @object, bool modified)
		{
			@object.ObjectProperties.Modified = modified;
			return @object;
		}

		public static UncommonSense.CBreeze.Core.Object WithVersionList(this UncommonSense.CBreeze.Core.Object @object, string versionList)
		{
			@object.ObjectProperties.VersionList = versionList;
			return @object;
		}
	}
}

