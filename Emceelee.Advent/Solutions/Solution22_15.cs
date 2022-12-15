using Emceelee.Advent.Resolvers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Emceelee.Advent.Solutions
{
    public class Solution22_15 : ISolution
    {
        public void Solve()
        {
            var tickets = Utility.ReadLines(@"DataSet\2022\15_tickets.txt");
            Console.WriteLine("Day 15 Solution: " + Solve(tickets));
        }
        
        public int Solve(IEnumerable<string> tickets)
        {
            var seatFilledMatrix = new bool[128, 8];
            foreach(string ticket in tickets)
            {
                ResolveSeat(ticket, out int row, out int seat);
                seatFilledMatrix[row, seat] = true;
            }

            var rowsWithSpace = new List<int>();

            for(int r = 0; r < seatFilledMatrix.GetLength(0); ++r)
            {
                var consecutiveEmptySeats = 0;

                for (int s = 0; s < seatFilledMatrix.GetLength(1); ++s)
                {
                    if(seatFilledMatrix[r,s])
                    {
                        consecutiveEmptySeats = 0;
                    }
                    else
                    {
                        ++consecutiveEmptySeats;

                        if(consecutiveEmptySeats >= 3)
                        {
                            rowsWithSpace.Add(r);
                        }
                    }
                }
            }

            return rowsWithSpace.FirstOrDefault();
        }

        public void ResolveSeat(string ticket, out int row, out int seat)
        {
            var rowIdentifier = ticket.Substring(0, 7);
            var seatIdentifier = ticket.Substring(7);

            var rowResolver = new BinarySpacePartitionResolver('F', 'B');
            var seatResolver = new BinarySpacePartitionResolver('L', 'R');

            row = rowResolver.ResolveIndex(rowIdentifier);
            seat = seatResolver.ResolveIndex(seatIdentifier);
        }
    }
}
