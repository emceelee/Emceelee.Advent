using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Emceelee.Advent.Resolvers
{
    public class PassphraseResolver
    {
        public bool IsValidPassphrase(string passphrase)
        {
            var words = passphrase.Split(' ');

            //verify no duplicates
            if (words.GroupBy(x => x).Where(x => x.Count() > 1).Any())
            {
                return false;
            }

            //at least 3 words
            if (words.Count() < 3)
            {
                return false;
            }

            //at most 8 words
            if(words.Count() > 8)
            {
                return false;
            }

            //verify no special characters
            if(words.Any(x => !Regex.IsMatch(x, @"^[a-z]+$")))
            {
                return false;
            }

            return true;
        }

        public IEnumerable<string> ResolveValidPassphrases(IEnumerable<string> passphrases)
        {
            return passphrases.Where(passphrase => IsValidPassphrase(passphrase));
        }
    }
}
