using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFinalStage
{
    class Player : IStorable
    {
        //------------------------properties that satisfy contract with interface---------------------
        public int Jocker { get; set; }
        public int Number { get; set; }
        public List<int> FiveNumbers { get; set; }

        //---------------------------other class' properties----------------------
        public static DateTime now;
        private Random r;
        private string id;
        public string ID
        {
            get
            {
                return id;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    IDGiven(id, value);
                    id = value;
                }

            }
        }
       
        //Event
        public IDGivenDelegate IDGiven;

        //-------------------------------ctors----------------------
        public Player()
        {
            now = DateTime.Now;
            id = "Nothing";
            r = new Random();
            FiveNumbers = new List<int>();
        }

        public Player(List<int> fiveNumbers, int jocker, string id)
        {
            FiveNumbers = fiveNumbers;
            Jocker = jocker;
            this.id = id;
        }

        //--------------------methods that satisfy contract with interface---------------------
        public List<int> PlayFiveNumbers(string declareRandomOrManually)
        {
            const int maxLimitOfNumbers = 45;
            const int howManyNumbers= 5;
            
            //By For-Looping i fill my list
            for (int i = 0; i < howManyNumbers; i++)
            {
                //By Do-While-Looping i manage to fill my list with unique numbers
                do
                {
                    //procedure goes on based on if i wish random numbers or numbers i manually insert
                    switch (declareRandomOrManually)
                    {
                        case "random":
                            Number = r.Next(1, maxLimitOfNumbers+1); // by using next i decide the field of numbers
                            break;

                        case "manually":
                            Console.Write($"Write {i + 1} number:");
                            // try-catch all possible exceptions 
                            try
                            {
                                Number = int.Parse(Console.ReadLine());
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Please enter an integer number!");
                            }
                            // i control the field of the numbers by using this while-loop
                            while (Number < 1 || Number > maxLimitOfNumbers)
                            {
                                Console.Write("Number must be {0}-{1}. Try again:", 1, maxLimitOfNumbers);
                                //try-catch all possible exceptions
                                try
                                {
                                    Number = int.Parse(Console.ReadLine());
                                }
                                catch (Exception)
                                {
                                    Console.WriteLine("Please enter an integer number!");
                                }
                            }
                            break;

                        // empty default case for possible future use
                        default:

                            break;
                    }
                } while (FiveNumbers.Contains(Number));
                //when the number goes out of check for if unique, it is added to list
                FiveNumbers.Add(Number);
            }
            return FiveNumbers;
        }

        public void PrintFiveNumbers()
        {
            //printing the fiven numbers
            Console.WriteLine("Player chose the follow five numbers:");
            foreach (int i in FiveNumbers)
            {
                Console.WriteLine(i);
            }

        }

        public int PlayJocker(string declareRandomOrManually)
        {
            const int maxLimitOfJockerNumbers = 20;

            switch (declareRandomOrManually)
            {
                case "random":
                    Jocker = r.Next(1, maxLimitOfJockerNumbers+1); // by using next i decide the field of numbers
                    break;

                case "manually":
                    Console.Write($"Write Jocker number:");
                    // try-catch all possible exceptions 
                    try
                    {
                        Jocker = int.Parse(Console.ReadLine());
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Please enter an integer number!");
                    }
                    // i control the field of the numbers by using this while-loop
                    while (Jocker < 1 || Jocker > maxLimitOfJockerNumbers)
                    {
                        Console.Write("Number must be {0}-{1}. Try again:", 1, maxLimitOfJockerNumbers);
                        //try-catch all possible exceptions
                        try
                        {
                            Jocker = int.Parse(Console.ReadLine());
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Please enter an integer number!");
                        }
                    }
                    break;

                // empty default case for possible future use
                default:

                    break;
            }
            return Jocker;
        }

        public void PrintJocker()
        {
            // printing the jocker number
            Console.WriteLine("Player chose for Jocker Number:");
            Console.WriteLine(Jocker);
        }

        //-------------------------------other methods--------------------------------
        public string CreateAnIDForPlayer()
        {
            // i use stringbuilder to build my ID. Each player must have a unique id, that's why i used DateTime. 
            StringBuilder sb = new StringBuilder();
            sb.Append("{")
              .Append(now.Year)
              .Append(now.Month)
              .Append(now.Day)
              .Append(now.Hour)
              .Append(now.Minute)
              .Append(now.Second)
              .Append("}");

            return sb.ToString();                       
        }

        //subscriber of event
        public void OnIDGiven1(string existingID, string newID)
        {
            Console.WriteLine($"Player created and played jocker at {now.ToLongDateString()} {now.ToLongTimeString()}");
        }

        public void OnIDGiven2(string existingName, string newName)
        {
            Console.WriteLine($"Players ID is {CreateAnIDForPlayer()}");
        }
    }
}
