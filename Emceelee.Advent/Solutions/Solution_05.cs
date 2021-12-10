using System;
using System.Collections.Generic;
using System.Text;

using Emceelee.Advent.Resolvers;

namespace Emceelee.Advent.Solutions
{
    public class Solution_05 : ISolution
    {
        public void Solve()
        {
            string encryptedMessage = "Z5VGFPEIMVFAVLHKKFNMV3WWVGFNHNFDMV5WWWVOKPMMDBVMGKFPNMVXWWVB7NKDMVFAVMFPGVOKFN V2WWWVYPCIKFGMVZWWWVLHEITVLHEDMVXVBHKYDVOFSVFAV7OPGKFADEVHEIVNFIHTMVGHGDK";
            Console.WriteLine("Day 05 Solution: ");

            var possibleKeys = new List<string>()
            {
                "CANDY24",
                "JINGLE 98",
                "TINSEL43",
                "8 XMAS",
                "STOCKING7",
                "CLAUS",
                "HOLIDAY 789",
                "RUDOLPH",
                "1 CHIMNEY",
                "CAROLING3"
            };

            var resolver = new CiphertextResolver();

            foreach(var possibleKey in possibleKeys)
            {
                var ciphertextAlphabet = resolver.ResolveCiphertextAlphabet(possibleKey);
                var unencrypted = Solve(encryptedMessage, CiphertextResolver.PlaintextAlphabet, ciphertextAlphabet);

                Console.WriteLine($"{possibleKey} - {unencrypted}");
            };

            Console.ReadLine();
        }

        public string Solve(string encryptedMessage, string plaintextAlphabet, string ciphertextAlphabet)
        {
            var unencryptedMessage = new List<char>();
            if(plaintextAlphabet.Length != ciphertextAlphabet.Length)
            {
                throw new ArgumentException("plaintextAlphabet and ciphertextAlphabet must have the same characters and thus lengths");
            }

            foreach(char k in encryptedMessage)
            {
                var index = ciphertextAlphabet.IndexOf(k);

                if (index < 0)
                {
                    throw new ArgumentOutOfRangeException($"Character({k}) does not exist in plaintext alphabet: {plaintextAlphabet}");
                }
                //should be caught above in the length comparison check
                if(index >= plaintextAlphabet.Length)
                {
                    throw new ArgumentOutOfRangeException($"Index({index}) does not exist in ciphertext alphabet: {ciphertextAlphabet}");
                }

                var matchingK = plaintextAlphabet[index];
                unencryptedMessage.Add(matchingK);
            }

            return new string(unencryptedMessage.ToArray());
        }
    }
}
