using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Emceelee.Advent.Resolvers;

namespace Emceelee.Advent.Solutions
{
    public class Solution21_08 : ISolution
    {
        public void Solve()
        {
            var lines = Utility.ReadLines("DataSet\\08_map.txt");
            var resolver = new CollisionResolver();

            var trajectories = new List<int[]>()
            {
                new int[3] { 3, 1, 0 },
                new int[3] { 2, 2, 0 },
                new int[3] { 2, 1, 0 },
                new int[3] { 5, 2, 0 },
                new int[3] { 1, 1, 0 }
            };

            foreach(var trajectory in trajectories)
            {
                trajectory[2] = resolver.ResolveCollisions(lines, trajectory[0], trajectory[1]);
            }

            var result = trajectories.Min(trajectory => trajectory[2]);

            Console.WriteLine("Day 08 Solution: " + result);
        }
    }
}
