using System;
using System.Collections.Generic;
using System.Text;

using Emceelee.Advent.Resolvers;

namespace Emceelee.Advent.Solutions
{
    public class Solution21_19 : ISolution
    {
        public void Solve()
        {
            var lines = Utility.ReadLines("DataSet\\2021\\19_network.txt");

            Solve(lines);
        }

        public void Solve(IEnumerable<string> lines)
        {
            var resolver = new NodeNetworkResolver();

            foreach (var line in lines)
            {
                var parts = line.Split(": ");
                var nodeNames = parts[0].Split('-');
                var node1 = nodeNames[0].ToUpper();
                var node2 = nodeNames[1].ToUpper();
                var value = int.Parse(parts[1]);

                if (!resolver.Contains(node1))
                {
                    resolver.AddNode(node1);
                }
                if (!resolver.Contains(node2))
                {
                    resolver.AddNode(node2);
                }
                resolver.AddPath(node1, node2, value);
            }

            resolver.CacheMinPathValues("NORTH POLE");
            var minValue = resolver.ResolveMinimumPathValue("MCMURDO", "NORTH POLE", out IEnumerable<NetworkPath> minValuePath);

            Console.WriteLine("Day 19 Solution: " + minValue);

            var currentNode = resolver["MCMURDO"];
            NetworkNode nextNode = null;

            foreach (var path in minValuePath)
            {
                nextNode = path.GetOtherNode(currentNode);
                Console.WriteLine($"{currentNode.Name}->{nextNode.Name}: {path.PathValue}");
                currentNode = nextNode;
            }
        }
    }
}
