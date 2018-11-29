using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectFinalStage
{
    class Game
    {
        /*In this class i design a game. Each game should have a Player or more and a draw or more.
        I could implement more games throught this class in the future */
        
        //properties
        public static Player onePlayer;
        public static Draw oneDraw;
        public static List<Player> listOfPlayers;
        public static List<Draw> listOfDraws;
        
        //ctor
        public Game()
        {
            onePlayer = new Player();
            oneDraw = new Draw();
            listOfPlayers = new List<Player>();
            listOfDraws = new List<Draw>();
        }

        //methods

        //i use this method to create and enter players.
        public List<Player> EnterPlayers()
        {
            Console.WriteLine("How many players would you like to play?");
            int numberOfPlayers = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfPlayers; i++)
            {
                Console.Write("Choose selection category: random or manually:");
                string declareRandomOrManually = Console.ReadLine();
                var pickFiveNumbers = onePlayer.PlayFiveNumbers(declareRandomOrManually);
                var jockerNumber = onePlayer.PlayJocker(declareRandomOrManually);
                onePlayer.IDGiven += new IDGivenDelegate(onePlayer.OnIDGiven1);
                onePlayer.IDGiven += new IDGivenDelegate(onePlayer.OnIDGiven2);
                onePlayer.ID = onePlayer.CreateAnIDForPlayer();
                onePlayer = new Player(pickFiveNumbers, jockerNumber,onePlayer.ID);
                onePlayer.PrintFiveNumbers();
                onePlayer.PrintJocker();

                listOfPlayers.Add(onePlayer);
                onePlayer = new Player();
                Thread.Sleep(2000);
            }
            return listOfPlayers;
        }

        //i use this method to create draws and then print their winning categories each draw has
        public List<Draw> MakeDrawsAndPrintTheirWinningCategories()
        {
            Console.WriteLine("How many draws would you like to play?");
            int numberOfDraws = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfDraws; i++)
            {
                Draw.Budget += 1000;
                Console.WriteLine("The draw's bugdet is {0}", Draw.Budget);
                Console.WriteLine($"{i + 1} Draw results are:");
                var drawFiveNumbers = oneDraw.PlayFiveNumbers(null);
                var drawJockerNumber = oneDraw.PlayJocker(null);
                oneDraw.PrintFiveNumbers();
                oneDraw.PrintJocker();
                oneDraw = new Draw(drawFiveNumbers, drawJockerNumber);
                listOfDraws.Add(oneDraw);
                Game.PrintTheWinningCategories();
                oneDraw = new Draw();
                Thread.Sleep(1000);
            }
            Console.WriteLine("The remaining budget is {0}", Draw.Budget);
            Draw.DrawACar(listOfPlayers);
            return listOfDraws;
        }

        // i create this method to prin the winning categories. Through procedural programming this will happen in method above
        public static void PrintTheWinningCategories()
        {
            foreach (var player in listOfPlayers)
            {
                Comparison.CompareOnePlayerOneDraw(player, oneDraw);
                Category.OneResultEntersOneCategory(Comparison.success, Comparison.bonus);
            }
            // printin winning categories
            Category.PrintTheWinningCategoriesAndMoney();
            Category category = new Category(); // i do this so it wont keep the previous categories
        }

        // i create this method to compute some statistics about the most or less occured numbers in draws
        public void ComputeStatistics()
        {
            foreach (var draw in listOfDraws)
            {
                foreach (int i in draw.FiveNumbers)
                {
                    Statistics.AllNumbersThatWereBeenDrawn.Add(i);
                }
                Statistics.AllJockersThatWereBeenDrawn.Add(draw.Jocker);
            }

            Console.WriteLine("\nFor five numbers these are the stats:");
            var fiveNumbersStats = Statistics.GetFrequencies(Statistics.AllNumbersThatWereBeenDrawn);
            Statistics.DisplaySortedThreeMostOccured(fiveNumbersStats, 3);
            Statistics.DisplaySortedThreeLessOccured(fiveNumbersStats, 3);

            Console.WriteLine("\nFor jocker numbers these are the stats:");
            var jockerStats = Statistics.GetFrequencies(Statistics.AllJockersThatWereBeenDrawn);
            Statistics.DisplaySortedThreeMostOccured(jockerStats, 1);
            Statistics.DisplaySortedThreeLessOccured(jockerStats, 1);
        }

    }

}
