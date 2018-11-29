using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFinalStage
{
    class Statistics
    {
        //properties
        public static List<int> AllNumbersThatWereBeenDrawn = new List<int>();
        public static List<int> AllJockersThatWereBeenDrawn = new List<int>();

        //method
        public static Dictionary<int, int> GetFrequencies(List<int> values)
        {
            var result = new Dictionary<int, int>();
            foreach (var value in values)
            {
                if (result.TryGetValue(value, out int count))
                {
                    // Increase existing value.
                    result[value] = count + 1;
                }
                else
                {
                    // New value, set to 1.
                    result.Add(value, 1);
                }
            }
            // Return the dictionary.
            return result;
        }

        public static void DisplaySortedThreeMostOccured(Dictionary<int, int> frequencies, int howManyRows)
        {
            // order pairs in dictionary from high to low frequency.
            var sorted = from pair in frequencies
                         orderby pair.Value descending
                         select pair;

            Console.WriteLine($"The {howManyRows} most occured numbers are: ");
            for (int i = 0; i < howManyRows; i++)
            {
                var first = sorted.Skip(i).First(); //skipping from the first element i times
                Console.WriteLine($"{first.Key} which showed up {first.Value} times in all draws");
            }

        }

        public static void DisplaySortedThreeLessOccured(Dictionary<int, int> frequencies, int howManyRows)
        {
            // order pairs in dictionary from high to low frequency.
            var sorted = from pair in frequencies
                         orderby pair.Value ascending
                         select pair;

            Console.WriteLine($"The {howManyRows} less occured numbers are: ");
            for (int i = 0; i < howManyRows; i++)
            {
                var first = sorted.Skip(i).First(); //skipping from the first element i times
                Console.WriteLine($"{first.Key} which showed up {first.Value} times in all draws");
            }

        }
    }
}
