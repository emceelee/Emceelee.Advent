using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Emceelee.Advent
{
    public static class Utility
    {
        public static IEnumerable<string> ReadLines(string file)
        {
            string path = Directory.GetCurrentDirectory();
            string filePath = $"{path}\\{file}";

            return File.ReadLines(filePath);
        }

        public static string ReadAllText(string file)
        {
            string path = Directory.GetCurrentDirectory();
            string filePath = $"{path}\\{file}";

            return File.ReadAllText(filePath);
        }
    }
}
