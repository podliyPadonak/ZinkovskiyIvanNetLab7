using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ZinkovskiyTask
{
    internal class DirectoryScanner
    {
        private DirectoryInfo directoryInfo;

        internal DirectoryScanner() { }

        internal List<string> GetTextFilesWithString(string[] dictionaries, string searchText)
        {
            List<string> result = new List<string>();

            foreach (string directory in dictionaries)
            {
                directoryInfo = new DirectoryInfo(directory);
                var files = directoryInfo.GetFiles("*", SearchOption.AllDirectories)
                                          .AsParallel() // Використовуйте паралельність для прискорення операцій
                                          .Where(f => GetIsFileContainsString(f.FullName, searchText));

                result.AddRange(files.Select(f => f.FullName));
            }
            return result;
        }
        internal bool GetIsFileContainsString(string path, string phrase)
        {
            var streamReader = new StreamReader(path);

            while (streamReader.Peek() != -1)
            {
                string line = streamReader.ReadLine();
                if (line.Contains(phrase, StringComparison.OrdinalIgnoreCase)) // Використовуйте ігнорування регістру для пошуку
                {
                    return true;
                }
            }
            streamReader.Close();
            return false;
        }
    }
}