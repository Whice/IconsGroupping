using System.IO;

namespace Assets.Scripts.Utils
{
    internal static class Extensions
    {
        public static string GetFileName(this string fullPath)
        {
            return Path.GetFileName(fullPath);
        }
    }
}
