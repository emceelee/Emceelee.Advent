using Emceelee.Advent.Resolvers;
using Emceelee.Advent.Transforms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Emceelee.Advent.Solutions
{
    public class Solution22_18 : ISolution
    {
        public void Solve()
        {
            var map = BuildMap();
            Console.WriteLine("Day 18 Solution: " + Solve(map));
        }

        public int Solve(char[,] map)
        {
            var transform = new AggregateTransform<char>();
            var transform1 = new SeepSiliconTransform();
            transform.AddTransform(transform1);
            var transform2 = new BuildMineTransform(); //count successful minings
            transform.AddTransform(transform2);
            var transform3 = new DestroyMineTransform();
            transform.AddTransform(transform3);
            var transform4 = new SpreadMuncherTransform();
            transform.AddTransform(transform4);
            var transform5 = new StarveMuncherTransform();
            transform.AddTransform(transform5);

            transform.ApplyTransform(map, 12);
            var siliconCount = Utility.Count(map, Constants22_18.Silicon);
            var muncherCount = Utility.Count(map, Constants22_18.Muncher);
            var mineCount = Utility.Count(map, Constants22_18.Mine);
            Console.WriteLine($"Silicon: {siliconCount}, Munchers: {muncherCount}, Mines: {mineCount}");

            return transform2.SuccessCount;
        }

        private char[,] BuildMap()
        {
            var lines = Utility.ReadLines(@"DataSet\2022\18_big.txt");
            var list = lines.Where(x => !string.IsNullOrWhiteSpace(x)).ToList();

            var map = new char[lines.First().Length, list.Count];

            for(int y = 0; y < list.Count; ++y)
            {
                var line = list[y];
                for(int x = 0; x < line.Length; ++x)
                {
                    map[x, y] = line[x];
                }
            }

            return map;
        }
    }
}   
