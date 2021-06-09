using System.Collections;

namespace HinosPackage.Runtime.Util.ExtensionMethods {
    public static class ListExtensionMethods {

        public static bool IsEmpty(this ICollection e) => e.Count == 0;
    }
}