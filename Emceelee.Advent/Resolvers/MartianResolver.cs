using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Emceelee.Advent.Resolvers
{
    public class MartianResolver
    {
        public bool IsMartian(string name)
        {
            var nameUpper = name.ToUpper();

            //check each character is used exactly onec
            if (nameUpper.Count(k => k == 'M') != 1)
            {
                return false;
            }
            if (nameUpper.Count(k => k == 'A') != 1)
            {
                return false;
            }
            if (nameUpper.Count(k => k == 'R') != 1)
            {
                return false;
            }
            if (nameUpper.Count(k => k == 'S') != 1)
            {
                return false;
            }

            //get character index
            var nM = nameUpper.IndexOf('M');
            var nA = nameUpper.IndexOf('A');
            var nR = nameUpper.IndexOf('R');
            var nS = nameUpper.IndexOf('S');

            if (nM > nA)
            {
                return false;
            }
            if (nA > nR)
            {
                return false;
            }
            if (nR > nS)
            {
                return false;
            }

            return true;
        }

        public IEnumerable<string> ResolveMartians(IEnumerable<string> possibleMartians)
        {
            var result = possibleMartians.Where(possibleMartian => IsMartian(possibleMartian));
            return result;
        }
    }
}
