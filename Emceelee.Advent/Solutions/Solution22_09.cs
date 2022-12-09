using Emceelee.Advent.Resolvers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Emceelee.Advent.Solutions
{
    public class Solution22_09 : ISolution
    {
        public void Solve()
        {
            var pig = Utility.ReadAllText(@"DataSet\2022\09_1984.pig");
            var english = Utility.ReadAllText(@"DataSet\2022\09_1984.txt");

            var pigWords = GetPigWords(pig);
            var englishWords = GetEnglishWords(english);

            var dictionary = BuildDictionary(pigWords, englishWords);

            var phrase = "ooo squeeee ooink sque squeeee eeee huff shooort ooink ooo snort ooo sque ooo hufff ooo ooo oink ooink huff squeeee sque oink eee shooort eee ooink huff eeee shooort sque eyyyee shooort eeee snort wheez eieie sque ooink snort sque wheeze sque ooo eieie ooink shooort oink eeee hufff squeeee oink sque shooort eeee sque snort wheeze squeeee ooo ooink ee oink eyyyee shooort hufff ooo eieie eee squeeee ooink ooo eyyyee huff shooort squeeee ooo eieie eieie huff snort eieie ee snort eieie eee eieie wheeze snort eee shooort shooort sque squeeee";

            Console.WriteLine("Day 09 Solution: " + Solve(phrase, dictionary));
        }

        public IDictionary<string, string> BuildDictionary(IEnumerable<string> raw, IEnumerable<string> translation)
        {
            var result = new Dictionary<string, string>();

            var rawArray = raw.ToArray();
            var translationArray = translation.ToArray();

            if(rawArray.Length != translationArray.Length)
            {
                throw new ArgumentException("raw and translation inputs must be of same size");
            }

            for (int i = 0; i < rawArray.Length; ++i)
            {
                var rawWord = rawArray[i];
                var translatedWord = translationArray[i];

                if (result.TryGetValue(rawWord, out string value))
                {
                    if (value != translatedWord)
                    {
                        throw new InvalidOperationException("raw word has two translations");
                    }
                }
                else
                {
                    result.Add(rawWord, translatedWord);
                }
            }

            return result;
        }

        public IEnumerable<string> GetPigWords(string pig)
        {
            var pigWordEndings = new string[] { " hufff ", " huff ", " wheez ", " wheeze ", " squee " };
            var pigWords = pig.Split(pigWordEndings, StringSplitOptions.RemoveEmptyEntries);
            var pigWordsTrimmed = pigWords.Select(x => x.Trim()).Where(x => !string.IsNullOrWhiteSpace(x));

            return pigWordsTrimmed;
        }

        public IEnumerable<string> GetEnglishWords(string english)
        {
            var scrubbed = new string(english.Where(k => k != '\'' 
            && k != '"'
            && k != '['
            && k != ']'
            && k != '('
            && k != ')'
            && k != '.'
            && k != ','
            && k != '!'
            && k != '?'
            && k != ':'
            && k != '-'
            && k != ';').ToArray());

            var englishSplitters = new string[] { ".", ",", "!", "?", " ", "\r", "\n" }; //split at punctuation
            var englishWords = scrubbed.Split(englishSplitters, StringSplitOptions.RemoveEmptyEntries);
            var englishWordsTrimmed = englishWords.Select(x => x.Trim().ToLower()).Where(x => !string.IsNullOrWhiteSpace(x));

            //check for special characters which my throw off the word counts
            var specialCharWords = englishWordsTrimmed.Where(x => !Regex.IsMatch(x, "^[a-z0-9]*$"));

            return englishWordsTrimmed;
        }

        public string Solve(string phrase, IDictionary<string, string> dictionary)
        {
            var result = new StringBuilder();
            var words = GetPigWords(phrase);

            foreach(var word in words)
            {
                if(dictionary.TryGetValue(word, out string translation))
                {
                    if(result.Length > 0)
                    {
                        result.Append(" ");
                    }
                    result.Append(translation);
                }
                else
                {
                    throw new InvalidOperationException("No translation available for word");
                }
            }

            return result.ToString();
        }
    }
}
