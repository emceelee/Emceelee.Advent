using System;
using System.Collections.Generic;
using System.Text;

using Emceelee.Advent.Resolvers;

namespace Emceelee.Advent.Solutions
{
    public class Solution_17 : ISolution
    {
        public void Solve()
        {
            Console.WriteLine("Day 17 Solution: " + Solve(5));
        }

        public string Solve(int n)
        {
            if(n < 1)
            {
                throw new ArgumentOutOfRangeException("n must be > 0.");
            }

            var searchArray = new string[n];
            var fibonatree = new List<string>();

            var seqNo = 0; 
            var digitsCompleted = 0;
            var isSearchArrayCompleted = false;

            var resolver = new FiboResolver();
            while (true)
            {
                //first iteration of resolveFibo should be seqNo = 1
                var fibo = resolver.ResolveFibo(++seqNo).ToString();
                var digits = fibo.ToString().Length;

                if(digits == digitsCompleted + 1)
                {
                    //first n lines need to be searched in the current line of the fibonatree
                    if (digitsCompleted < searchArray.Length && searchArray[digitsCompleted] == null)
                    {
                        searchArray[digitsCompleted] = fibo;
                    }

                    //new line to the fibonatree
                    fibonatree.Add(fibo);
                    ++digitsCompleted;

                    isSearchArrayCompleted = digitsCompleted >= n;

                    var containsAllFibos = true;
                    if (isSearchArrayCompleted)
                    {
                        foreach (var searchTerm in searchArray)
                        {
                            containsAllFibos &= fibo.Contains(searchTerm);
                            if (!containsAllFibos)
                            {
                                break;
                            }
                        }

                        if (containsAllFibos)
                        {
                            return fibo;
                        }
                    }
                }
            }
        }
    }
}
