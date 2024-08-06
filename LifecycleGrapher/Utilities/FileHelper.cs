using System.IO;

namespace LifecycleGrapher.Utilities
{
    public static class FileHelper
    {
        public static void WriteToFile(string filePath, string content)
        {
            File.WriteAllText(filePath, content);
        }
    }
}