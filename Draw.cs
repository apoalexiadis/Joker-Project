using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFinalStage
{
    class Draw : IStorable
    {
        //----------------------------properties that satisfy contract with interface------------------
        public int Jocker { get; set; }
        public List<int> FiveNumbers { get; set; }
        public int Number { get; set; }
        public static double Budget;

        //-------------------------------ctors------------------------------
        public Draw()
        {
            FiveNumbers = new List<int>();
        }

        public Draw(List<int> fiveNumbers, int jocker)
        {
            FiveNumbers = fiveNumbers;
            Jocker = jocker;
        }

        //-----------------------------------methods that satisfy contract with interface---------------------
        //play five numbers 
        public List<int> PlayFiveNumbers(string makeItNullForRandom)
        {
            Random r = new Random();
            const int maxLimitOfNumbers = 45;
            const int howManyNumbers = 5;

            //By For-Looping i fill my list
            for (int i = 0; i < howManyNumbers; i++)
            {
                //By Do-While-Looping i manage to fill my list with unique numbers
                do
                {
                    Number = r.Next(1, maxLimitOfNumbers+1); // by using next i decide the field of numbers
                } while (FiveNumbers.Contains(Number));
                //when the number goes out of check for if unique, it is added to list
                FiveNumbers.Add(Number);
            }
            FiveNumbers.Sort();
            return FiveNumbers;
        }

        //printing the five numbers
        public void PrintFiveNumbers()
        {
            Console.WriteLine("Five Lucky Numbers are");
            foreach (int i in FiveNumbers)
            {
                Console.WriteLine(i);
            }
        }

        //play one number (Jocker)
        public int PlayJocker(string makeItNullForRandom)
        {
            const int maxLimitOfJockerNumbers = 20;
            Random r = new Random();
            Jocker = r.Next(1, maxLimitOfJockerNumbers+1);
            

            return Jocker;
        }

        //printing jocker
        public void PrintJocker()
        {
            Console.WriteLine("Jocker Number is");
            Console.WriteLine(Jocker);
        }

        //-----------------------------------------other methods------------
        //i create this method to use somewhere the ID i made for delegate.
        public static void DrawACar(List<Player> listOfPlayers)
        {
            //i use colour difference to understand if and where it works.
            Console.ForegroundColor = ConsoleColor.DarkBlue;

            List<string> listOfPlayersID = new List<string>();

            //if my remaining budget is over 10000 euros(JackPot), a draw for a car will take place!
            if (Draw.Budget > 10000)
            {
                Console.WriteLine("We have JackPot!");
                Console.WriteLine("One of the Players will win a new Car");

                foreach (var player in listOfPlayers)
                {
                    listOfPlayersID.Add(player.ID);
                }
                //I run through my list of string and i choose one string randomly!
                int index = new Random().Next(listOfPlayersID.Count);
                string luckyID = listOfPlayersID[index];

                Console.WriteLine($"The lucky Player with ID {luckyID} won the car!");
 
            }
            else
                Console.WriteLine("I m sorry, there is not Jackpot!");

            //colour set back to normal white!
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
