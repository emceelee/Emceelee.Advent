using System;
using System.Collections.Generic;
using System.Text;

namespace Emceelee.Advent.Resolvers
{
    public class CiphertextResolver
    {
        public const string PlaintextAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ 0123456789";

        public string ResolveCiphertextAlphabet(string phrase)
        {
            var ciphertextAlphabet = new List<char>();

            //1) Add every character in phrase
            foreach(char k in phrase.ToUpper())
            {
                AddToCipherAlphabet(ciphertextAlphabet, k);
            }

            //2) Add a space
            AddToCipherAlphabet(ciphertextAlphabet, ' ');

            //3) Add remaining characters from PlaintextAlphabet
            foreach (char k in PlaintextAlphabet)
            {
                AddToCipherAlphabet(ciphertextAlphabet, k);
            }

            return new string(ciphertextAlphabet.ToArray());
        }

        private void AddToCipherAlphabet(List<char> ciphertextAlphabet, char k)
        {
            if(PlaintextAlphabet.Contains(k) && !ciphertextAlphabet.Contains(k))
            {
                ciphertextAlphabet.Add(k);
            }
        }
    }
}
