using System;

namespace UncommonSense.CBreeze.Parse
{
	public static class Exceptions
	{
		public static readonly string TextDoesNotMatchPattern = "'{0}' does not match pattern '{1}'.";
        public static readonly string MustBeAnEnumeratedType = "{0} must be an enumerated type.";
        public static readonly string UnknownSectionType = "{0} is not a known section type.";

        public static void ThrowException(string message)
        {
            throw new ApplicationException(message);
        }

		public static void ThrowException(string message, params object[] args)
		{
			ThrowException(string.Format(message, args));
		}
	}
}

