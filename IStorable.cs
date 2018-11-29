using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFinalStage
{
    public interface IStorable
    {
        //properties
        int Jocker { get; set; }
        int Number { get; set; }
        List<int> FiveNumbers { get; set; }

        //methods
        int PlayJocker(string declareRandomOrManually);
        void PrintJocker();
        List<int> PlayFiveNumbers(string declareRandomOrManually);
        void PrintFiveNumbers();
    }
}
