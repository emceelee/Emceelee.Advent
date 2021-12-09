using Emceelee.Advent.Resolvers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Emceelee.Advent.Solutions
{
    public class Solution_09 : ISolution
    {
        private HashSet<int> Squares { get; }
        private HashSet<int> Cubes { get; }

        public Solution_09()
        {
            var squaresResolver = new SquaresResolver();
            var cubesResolver = new CubesResolver();
            Squares = squaresResolver.ResolveSquares(1000);
            Cubes = cubesResolver.ResolveCubes(1000);
        }

        public void Solve()
        {
            var text = "226 342 663 441 976 695 695 582 64 0 625 326 626 21 676 604 679 849 456 81 529 8 321 274 54 25 237 205 739 196 412 193 427 4 881 584 841 36 484 103 102 610 400 299 465 567 64 468 779 583 100 907 444 8 4 729 176 331 908 974 729 418 529 350 32 547 664 784 605 121 400 225 716 867 518 100 422 672 900 707 887 882 400 92 322 706 732 121 869 125 289 27 744 553 326 930 64 398 216 686 294 725 18 729 889 121 64 49 242 835 986 27 476 2 400 989 473 922 441 490 54 126 200 8 667 576 121 225 213 22 474 460 81 16 343 186 313";
            Console.WriteLine("Day 09 Solution: " + Solve(text));
        }

        public string Solve(string text)
        {
            var numbers = text.Split(' ');
            var morseList = new List<char>();

            foreach(var numberText in numbers)
            {
                if(int.TryParse(numberText, out int number))
                {
                    if(number > 1000)
                    {
                        throw new ArgumentOutOfRangeException("Numbers should be <= 1000");
                    }

                    if(IsSquareOrCube(number))
                    {
                        morseList.Add(' ');
                    }
                    else if(IsEven(number))
                    {
                        morseList.Add('.');
                    }
                    else if(IsOdd(number))
                    {
                        morseList.Add('-');
                    }
                }
                else
                {
                    throw new ArgumentException("Text should be all numbers");
                }
            }

            var morseText = new string(morseList.ToArray());
            //three spaces is a word gap
            var morseWords = morseText.Split("   ");

            var translation = new List<char>();

            foreach(var morseWord in morseWords)
            {
                if(translation.Any())
                {
                    translation.Add(' ');
                }
                var morseLetters = morseWord.Split(' ');

                foreach(var morseLetter in morseLetters)
                {
                    var translatedCharacter = TranslateCharacter(morseLetter);
                    translation.Add(translatedCharacter);
                }
            }

            var result = new string(translation.ToArray());

            return result;
        }

        private bool IsOdd(int n)
        {
            return n % 2 == 1;
        }

        private bool IsEven(int n)
        {
            return n % 2 == 0;
        }

        private bool IsSquare(int n)
        {
            return Squares.Contains(n);
        }

        private bool IsCube(int n)
        {
            return Cubes.Contains(n);
        }

        private bool IsSquareOrCube(int n)
        {
            return IsSquare(n) || IsCube(n);
        }

        private char TranslateCharacter(string morse)
        {
            switch(morse)
            {
                case ".-":
                    return 'a';
                case "-...":
                    return 'b';
                case "-.-.":
                    return 'c';
                case "-..":
                    return 'd';
                case ".":
                    return 'e';
                case "..-.":
                    return 'f';
                case "--.":
                    return 'g';
                case "....":
                    return 'h';
                case "..":
                    return 'i';
                case ".---":
                    return 'j';
                case "-.-":
                    return 'k';
                case ".-..":
                    return 'l';
                case "--":
                    return 'm';
                case "-.":
                    return 'n';
                case "---":
                    return 'o';
                case ".--.":
                    return 'p';
                case "--.-":
                    return 'q';
                case ".-.":
                    return 'r';
                case "...":
                    return 's';
                case "-":
                    return 't';
                case "..-":
                    return 'u';
                case "...-":
                    return 'v';
                case ".--":
                    return 'w';
                case "-..-":
                    return 'x';
                case "-.--":
                    return 'y';
                case "--..":
                    return 'z';
                default:
                    return '@';
            }
        }
    }
}
