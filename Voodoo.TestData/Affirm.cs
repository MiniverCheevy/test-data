using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Voodoo.TestData
{

    /// <summary>
    /// Used to avoid an issue with referencing mstest, which caused confilcts with newer version of mstest
    /// </summary>
    internal static class Affirm
    {
        internal static bool AreEqual<T>(T expected, T actual, string message = null)
        {
            
            if (object.Equals((object)expected, (object)actual))
                return true;

            var errorMessage = $"Expected {actual} to be {expected}";
            if (message != null)
                errorMessage = $"{errorMessage} reason:{message}";

            throw new AffirmationFailedException(errorMessage);
        }

        internal static bool IsNotNull(object item, string message=null)
        {
            if (item != null)
                return true;

            var errorMessage = $"Expected item to not be null";
            if (message != null)
                errorMessage = $"{errorMessage} reason:{message}";

            throw new AffirmationFailedException(errorMessage);
        }
    }
    public class AffirmationFailedException: Exception
    {
        public AffirmationFailedException(string message):base(message)
        {

        }
    }
}
