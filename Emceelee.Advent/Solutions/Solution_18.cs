using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Emceelee.Advent.Solutions
{
    public class Solution_18 : ISolution
    {
        string[] RawBaseLetters = new string[6]
        {
//1
@"----||
|--||-
--|---
--|-|-
-----|
|---||",

//2
@"|--||-
-----|
|--||-
||-|--
----||
---|||",

//3
@"||-|||
------
|-||||
-||-|-
|--|-|
|--||-",

//4
@"-|-|||
|||---
|-||--
-||-||
|-|||-
||----",

//5
@"|---||
|--|-|
-||---
-|---|
||----
||----",

//6
@"-|-||-
-|--|-
|-|-||
|||--|
-----|
|-|-|-"

        };

        string[] RawMasks = new string[6]
        {
//1
@"|---|-
|||--|
||||||
|||-||
|-|-||
||---|",

//2
@"|||---
||--|-
-|-|-|
---|||
||----
-||--|",

//3
@"|||-||
--||||
--|||-
|--|-|
||-|-|
--|--|",

//4
@"||-|||
-|||-|
|-|---
-|-|-|
-||--|
--|---",

//5
@"-|--|-
|---|-
--|--|
-|--||
--||||
||--||",

//6
@"-||--|
|-||--
|-|-||
|||--|
-||||-
|--|-|"

        };

        public void Solve()
        {
            var baseLetterMatrices = ProcessInput(RawBaseLetters);
            var maskMatrices = ProcessInput(RawMasks);
            DetermineAndOutputPossibilities(baseLetterMatrices, maskMatrices);
        }

        private List<char[,]> ProcessInput(string[] input)
        {
            var numSets = input.Length;
            //assume a set is a square matrix
            var matrixLength = input.FirstOrDefault().Split("\r\n").Length;

            var result = new List<char[,]>();

            for (int i=0; i< numSets; ++i)
            {
                var set = input[i];
                var lines = set.Split("\r\n");

                var charMatrix = new char[matrixLength, matrixLength];
                result.Add(charMatrix);

                for (int j=0; j<lines.Length; ++j)
                {
                    for (int k=0; k<lines.Length; ++k)
                    {
                        charMatrix[j, k] = lines[j][k];
                    }
                }
            }
            return result;
        }

        private void DetermineAndOutputPossibilities(List<char[,]> baseLetterMatrices, List<char[,]> maskMatrices)
        {
            var numSets = baseLetterMatrices.Count;

            for(int i=0; i<numSets; ++i)
            {
                var possibilities = new List<char[,]>();

                var baseLetterMatrix = baseLetterMatrices[i];
                var maskMatrix = maskMatrices[i];
                var prevMaskMatrix = maskMatrix;
                possibilities.Add(ApplyMask(baseLetterMatrix, maskMatrix));

                for (int rotations=0; rotations < 3; ++rotations)
                {
                    prevMaskMatrix = maskMatrix;
                    maskMatrix = RotateMatrix(maskMatrix);
                    possibilities.Add(ApplyMask(baseLetterMatrix, maskMatrix));
                }
                OutputPossibilities(possibilities);

                Console.WriteLine();
            }
        }

        private char[,] ApplyMask(char[,] baseLetterMatrix, char[,] maskMatrix)
        {
            var resultMatrix = new char[baseLetterMatrix.GetLength(0), baseLetterMatrix.GetLength(1)];

            for(int j=0; j<baseLetterMatrix.GetLength(0); ++j)
            {
                for (int k = 0; k < baseLetterMatrix.GetLength(1); ++k)
                {
                    var baseLetter = baseLetterMatrix[j, k];
                    var mask = maskMatrix[j, k];
                    var resultChar = ApplyMask(baseLetter, mask);
                    resultMatrix[j, k] = resultChar;
                }
            }

            return resultMatrix;
        }

        private char ApplyMask(char baseLetter, char mask)
        {
            var baseLetterBool = ConvertToBool(baseLetter);
            var maskBool = ConvertToBool(mask);

            var xor = baseLetterBool ^ maskBool;

            var result = ' ';
            if(xor)
            {
                result = '+';
            }
            return result;
        }

        private bool ConvertToBool(char input)
        {
            switch(input)
            {
                case '-':
                    return false;
                case '|':
                    return true;
                default:
                    throw new ArgumentException("input must be | or -");
            }
        }

        //output possibilities side by side
        private void OutputPossibilities(List<char[,]> possibilities)
        {
            var numLines = possibilities.FirstOrDefault().GetLength(0);
            for(int j=0; j<numLines; ++j)
            {
                var line = string.Empty;
                for(int i=0; i<possibilities.Count; ++i)
                {
                    var possibility = possibilities[i];

                    if(line.Length > 0)
                    {
                        line += "    ";
                    }
                    for (int k=0; k<possibility.GetLength(1); ++k)
                    {
                        line += possibility[j, k];
                    }
                }
                Console.WriteLine(line);
            }
        }

        private char[,] RotateMatrix(char[,] input)
        {
            var result = new char[input.GetLength(1), input.GetLength(0)];

            for (int j=0; j<result.GetLength(0); ++j)
            {
                //as we go down our result matrix, we go left on our input matrix
                var inputK = input.GetLength(1) - 1 - j;
                for (int k = 0; k < result.GetLength(1); ++k)
                {
                    //as we go right on our result matrix, we go down our input matrix
                    var inputJ = k;
                    var inputChar = input[inputJ, inputK];
                    var resultChar = inputChar == '|' ? '-' : '|';
                    result[j, k] = resultChar;
                }
            }

            return result;
        }
    }
}
