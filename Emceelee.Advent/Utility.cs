using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

        public static IEnumerable<IEnumerable<T>> GetPermutations<T>(IEnumerable<T> input)
        {
            var list = input.ToList();

            //termination condition
            if (list.Count() == 1)
            {
                return new List<IEnumerable<T>>() { input };
            }

            var result = new List<List<T>>();

            //loop through all items
            for (int i = 0; i < list.Count; ++i)
            {
                //get current item
                var item = list[i];
                
                //get sublist to feed into recursive call
                var subList = new List<T>(list);
                subList.RemoveAt(i);

                //get permutations of remaining items
                var permutations = GetPermutations(subList);

                //add all permutations to result
                foreach(var permutation in permutations)
                {
                    //set first item as the current item
                    var currentList = new List<T>() { item };
                    currentList.AddRange(permutation);
                    result.Add(currentList);
                }
            }

            return result;
        }

        public static IEnumerable<string> GetPermutations(string s)
        {
            var result = GetPermutations<char>(s).Select(enumerable => new string(enumerable.ToArray()));
            return result;
        }
        
    }
}
