using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFinalStage
{
    class Comparison
    {
        //properties
        public static int success;
        public static int bonus;

        //ctor
        public Comparison()
        {
            success = 0;
            bonus = 0;
        }

        //method
        // i create this method to compare two objects: a player and a draw
        public static List<Comparison> CompareOnePlayerOneDraw(Player player, Draw draw)
        {
            List<Comparison> saveCompare = new List<Comparison>();
            Comparison comparison = new Comparison();

            foreach (int playerNumber in player.FiveNumbers)
            {
                if (draw.FiveNumbers.Contains(playerNumber))
                {
                    success++;
                }
            }
            if (draw.Jocker == player.Jocker)
            {
                bonus = 1;
            }
            return saveCompare;
        }
    }
}
