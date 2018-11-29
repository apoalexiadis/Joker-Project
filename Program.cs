using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectFinalStage
{
    class Program
    {
        static void Main(string[] args)
        {
            //--------------------------------i create my game-------------------------------
            Game jockerGame = new Game();

            //----------------------------------players----------------------------------------------
            var playerNumbers = jockerGame.EnterPlayers();

            //---------------------------------draw-------------------------------------
            var listWithAllDraws = jockerGame.MakeDrawsAndPrintTheirWinningCategories();

            //------------------------------compute Statistics----------------------------------------
            jockerGame.ComputeStatistics();

        }
    
    }
}
