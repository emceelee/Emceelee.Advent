using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Emceelee.Advent.Resolvers;

namespace Emceelee.Advent.Solutions
{
    public class Solution_10 : ISolution
    {
        public void Solve()
        {
            var lines = Utility.ReadLines("DataSet\\10_nodes.txt");
            Console.WriteLine("Day 10 Solution: " + Solve(lines));
        }

        public int Solve(IEnumerable<string> lines)
        {
            var paths = new List<TrolleyPath>();
            foreach (var line in lines)
            {
                var array = line.Split(",");
                paths.Add(new TrolleyPath(array[0], array[1], array[2]));
            }

            var resolver = new TrolleyPathNodeTreeResolver();
            var rootNode = resolver.ResolveTrolleyPathNodeTree(paths);

            var result = FindTrolleyPathMinValue(rootNode);

            return result;
        }

        private int FindTrolleyPathMinValue(TrolleyPathNode node)
        {
            if(!node.Children.Any())
            {
                return node.PathToNodeValue;
            }

            int? minValue = null;
            foreach(var child in node.Children)
            {
                int childValue = FindTrolleyPathMinValue(child);
                if(minValue == null || childValue < minValue)
                {
                    minValue = childValue;
                }
            }

            return minValue.GetValueOrDefault();
        }
    }
}
