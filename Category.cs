using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFinalStage
{
    class Category 
    {
        //---------------------------------------properties---------------------------
        //public static double budget;
        private static int fivePlusOne;
        private static int fiveZero;
        private static int fourPlusOne;
        private static int fourZero;
        private static int threePlusOne;
        private static int threeZero;
        private static int twoPlusOne;
        private static int twoZero;
        private static int onePlusOne;
        private static int nothing;

        //--------------------------------------ctor---------------------------
        public Category()
        {
            fivePlusOne = 0;
            fiveZero = 0;
            fourPlusOne = 0;
            fourZero = 0;
            threePlusOne = 0;
            threeZero = 0;
            twoPlusOne = 0;
            twoZero = 0;
            onePlusOne = 0;
            nothing = 0;
        }

        //----------------------------------------------methods-----------------------------------------
        //case switch that fill my category's properties.
        public static List<Category> OneResultEntersOneCategory(int success, int bonus)
        {
            List<Category> winningResults = new List<Category>();
            switch (success)
            {
                case 5:
                    if (bonus == 1)
                        fivePlusOne++;
                    else
                        fiveZero++;
                    break;
                case 4:
                    if (bonus == 1)
                        fourPlusOne++;
                    else
                        fourZero++;
                    break;
                case 3:
                    if (bonus == 1)
                        threePlusOne++;
                    else
                        threeZero++;
                    break;
                case 2:
                    if (bonus == 1)
                        twoPlusOne++;
                    else
                        twoZero++;
                    break;
                case 1:
                    if (bonus == 1)
                        onePlusOne++;
                    else
                        nothing++;
                    break;
                default:
                    nothing++;
                    break;
            }
            return winningResults;
        }

        //i print the winning categories and the money each player gets. By using if-else i avoid dividing by 0. 
        public static void PrintTheWinningCategoriesAndMoney()
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("Finally results are:");
            double moneyForEachPlayerInWinningCategory = 0;

            if (fivePlusOne > 0)
            {
                moneyForEachPlayerInWinningCategory = (Draw.Budget * 40 / 100) / fivePlusOne;
                moneyForEachPlayerInWinningCategory = Math.Round(moneyForEachPlayerInWinningCategory, 2);
                Draw.Budget -= Draw.Budget * 40 / 100;
                Draw.Budget = Math.Round(Draw.Budget, 2);
                Console.WriteLine($"5+1 {fivePlusOne} times and each player won {moneyForEachPlayerInWinningCategory} Euros");
            }
            else
                Console.WriteLine($"5+1 {fivePlusOne} times");


            if (fiveZero > 0)
            {
                moneyForEachPlayerInWinningCategory = (Draw.Budget * 25 / 100) / fiveZero;
                moneyForEachPlayerInWinningCategory = Math.Round(moneyForEachPlayerInWinningCategory, 2);
                Draw.Budget -= Draw.Budget * 25 / 100;
                Draw.Budget = Math.Round(Draw.Budget, 2);
                Console.WriteLine($"5+0 {fiveZero} times and each player won {moneyForEachPlayerInWinningCategory} Euros");
            }
            else
                Console.WriteLine($"5+0 {fiveZero} times");

            if (fourPlusOne > 0)
            {
                moneyForEachPlayerInWinningCategory = (Draw.Budget * 15 / 100) / fourPlusOne;
                moneyForEachPlayerInWinningCategory = Math.Round(moneyForEachPlayerInWinningCategory, 2);
                Draw.Budget -= Draw.Budget * 15 / 100;
                Draw.Budget = Math.Round(Draw.Budget, 2);
                Console.WriteLine($"4+1 {fourPlusOne} times and each player won {moneyForEachPlayerInWinningCategory} Euros");
            }
            else
                Console.WriteLine($"4+1 {fourPlusOne} times");

            if (fourZero > 0)
            {
                moneyForEachPlayerInWinningCategory = (Draw.Budget * 5 / 100) / fourZero;
                moneyForEachPlayerInWinningCategory = Math.Round(moneyForEachPlayerInWinningCategory, 2);
                Draw.Budget -= Draw.Budget * 5 / 100;
                Draw.Budget = Math.Round(Draw.Budget, 2);
                Console.WriteLine($"4+0 {fourZero} times and each player won {moneyForEachPlayerInWinningCategory} Euros");
            }
            else
                Console.WriteLine($"4+0 {fourZero} times");


            if (threePlusOne > 0)
            {
                moneyForEachPlayerInWinningCategory = (Draw.Budget * 4 / 100) / threePlusOne;
                moneyForEachPlayerInWinningCategory = Math.Round(moneyForEachPlayerInWinningCategory, 2);
                Draw.Budget -= Draw.Budget * 4 / 100;
                Draw.Budget = Math.Round(Draw.Budget, 2);
                Console.WriteLine($"3+1 {threePlusOne} times and each player won {moneyForEachPlayerInWinningCategory} Euros");
            }
            else
                Console.WriteLine($"3+1 {threePlusOne} times");

            if (threeZero > 0)
            {
                moneyForEachPlayerInWinningCategory = (Draw.Budget * 3.5 / 100) / threeZero;
                moneyForEachPlayerInWinningCategory = Math.Round(moneyForEachPlayerInWinningCategory, 2);
                Draw.Budget -= Draw.Budget * 3.5 / 100;
                Draw.Budget = Math.Round(Draw.Budget, 2);
                Console.WriteLine($"3+0 {threeZero} times and each player won {moneyForEachPlayerInWinningCategory} Euros");

            }
            else
                Console.WriteLine($"3+0 {threeZero} times");

            if (twoPlusOne > 0)
            {
                moneyForEachPlayerInWinningCategory = (Draw.Budget * 1.5 / 100) / twoPlusOne;
                moneyForEachPlayerInWinningCategory = Math.Round(moneyForEachPlayerInWinningCategory, 2);
                Draw.Budget -= Draw.Budget * 1.5 / 100;
                Draw.Budget = Math.Round(Draw.Budget, 2);
                Console.WriteLine($"2+1 {twoPlusOne} times and each player won {moneyForEachPlayerInWinningCategory} Euros");
            }
            else
                Console.WriteLine($"2+1 {twoPlusOne} times");

            if (twoZero > 0)
            {
                moneyForEachPlayerInWinningCategory = (Draw.Budget * 1.5 / 100) / twoZero;
                moneyForEachPlayerInWinningCategory = Math.Round(moneyForEachPlayerInWinningCategory, 2);
                Draw.Budget -= Draw.Budget * 1.5 / 100;
                Draw.Budget = Math.Round(Draw.Budget, 2);
                Console.WriteLine($"2+0 {twoZero} times and each player won {moneyForEachPlayerInWinningCategory} Euros");
            }
            else
                Console.WriteLine($"2+0 {twoZero} times");

            if (onePlusOne > 0)
            {
                moneyForEachPlayerInWinningCategory = (Draw.Budget * 1 / 100) / onePlusOne;
                moneyForEachPlayerInWinningCategory = Math.Round(moneyForEachPlayerInWinningCategory, 2);
                Draw.Budget -= Draw.Budget * 1 / 100;
                Draw.Budget = Math.Round(Draw.Budget, 2);
                Console.WriteLine($"1+1 {onePlusOne} times and each player won {moneyForEachPlayerInWinningCategory} Euros");

            }
            else
                Console.WriteLine($"1+1 {onePlusOne} times");

            if (nothing > 0)
            {
                moneyForEachPlayerInWinningCategory = 0;
                Console.WriteLine($"nothing {nothing} times and each player won {moneyForEachPlayerInWinningCategory} Euros");
            }
            else
                Console.WriteLine($"nothing {nothing} times");
            Console.BackgroundColor = ConsoleColor.Black;
        }
    }
}
