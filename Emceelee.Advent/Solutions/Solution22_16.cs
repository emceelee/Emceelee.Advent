using Emceelee.Advent.Resolvers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Emceelee.Advent.Solutions
{
    public class Solution22_16 : ISolution
    {
        public void Solve()
        {
            Console.WriteLine("Day 16 Solution: " + Solve(100));
        }
        
        public int Solve(int total)
        {
            IEnumerable<Ingredient> winner = null;
            int winningScore = 0;

            //Candy Canes
            for(int a = 0; a <= total; ++a)
            {
                var candyCanes = new CandyCanes(a);
                var remainingA = total - a;

                //Wrapping Paper
                for(int b = 0; b <= remainingA; ++b)
                {
                    var wrappingPaper = new WrappingPaper(b);
                    var remainingB = remainingA - b;

                    //Shoe Polish
                    for (int c = 0; c <= remainingB; ++c)
                    {
                        var shoePolish = new ShoePolish(c);

                        //Last Year's Reindeer
                        var d = remainingB - c;
                        var lastYearsReindeer = new LastYearsReindeer(d);

                        var size = a + b + c + d;

                        var recipe = new List<Ingredient>() { candyCanes, wrappingPaper, shoePolish, lastYearsReindeer };

                        var score = recipe.TotalValue();
                        var calories = recipe.TotalCalories();

                        if(calories <= 250)
                        {
                            if(score > winningScore)
                            {
                                winningScore = score;
                                winner = recipe;
                                Console.WriteLine($"{a} CandyCanes, {b} WrappingPaper, {c} ShoePolish, {d} LastYearsReinder => Score: {score}, Calories: {calories}");
                            }
                        }
                    }
                }
            }

            return winningScore;
        }
    }

    public abstract class Ingredient
    {
        public abstract int Tastiness { get; }
        public abstract int Crunchiness { get; }
        public abstract int Muscleyness { get; }
        public abstract int Color { get; }
        public abstract int Calories { get; }
        public int Quantity { get; }

        protected Ingredient(int quantity)
        {
            Quantity = quantity;
        }

        public int TotalTastiness => Quantity * Tastiness;
        public int TotalCrunchiness => Quantity * Crunchiness;
        public int TotalMuscleyness => Quantity * Muscleyness;
        public int TotalColor => Quantity * Color;
        public int TotalCalories => Quantity * Calories;
        
    }

    public static class IngredientHelper
    {
        public static int TotalValue(this IEnumerable<Ingredient> ingredients)
        {
            int tastiness = ingredients.Sum(x => x.TotalTastiness);
            int crunchiness = ingredients.Sum(x => x.TotalCrunchiness);
            int muscleyness = ingredients.Sum(x => x.TotalMuscleyness);
            int color = ingredients.Sum(x => x.TotalColor);

            tastiness = tastiness > 0 ? tastiness : 0;
            crunchiness = crunchiness > 0 ? crunchiness : 0;
            muscleyness = muscleyness > 0 ? muscleyness : 0;
            color = color > 0 ? color : 0;

            var result = tastiness * crunchiness * muscleyness * color;
            return result;
        }

        public static int TotalCalories(this IEnumerable<Ingredient> ingredients)
        {
            return ingredients.Sum(x => x.TotalCalories);
        }
    }

    public class CandyCanes : Ingredient
    {
        public override int Tastiness => 3;
        public override int Crunchiness => 3;
        public override int Muscleyness => -1;
        public override int Color => 1;
        public override int Calories => 3;

        public CandyCanes(int quantity) : base(quantity) { }
    }

    public class WrappingPaper : Ingredient
    {
        public override int Tastiness => 1;
        public override int Crunchiness => -2;
        public override int Muscleyness => -1;
        public override int Color => -1;
        public override int Calories => 1;

        public WrappingPaper(int quantity) : base(quantity) { }
    }

    public class ShoePolish : Ingredient
    {
        public override int Tastiness => 3;
        public override int Crunchiness => 0;
        public override int Muscleyness => 1;
        public override int Color => 3;
        public override int Calories => 2;

        public ShoePolish(int quantity) : base(quantity) { }
    }

    public class LastYearsReindeer : Ingredient
    {
        public override int Tastiness => -2;
        public override int Crunchiness => 5;
        public override int Muscleyness => 5;
        public override int Color => -3;
        public override int Calories => 5;

        public LastYearsReindeer(int quantity) : base(quantity) { }
    }
}
