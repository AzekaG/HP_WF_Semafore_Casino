using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HP_WF_Semafore_Casino.Model
{
    internal class Player
    {
        public static int PlayerNumber = 0;
        public int PlayerNum = 0;
        public string Name { get; set; }
        public int Balance { get; set; }
        public int Number { get; set; }

        public int Rate { get; set; }

        public Player() 
        {
            ++PlayerNumber;
            PlayerNum = PlayerNumber;
        }

        public void UpdateCashDouble()      //в случае выиграша Баланс*=2
        {
            Balance *= 2;
        }
        public void UpdateCashLoseGame()
        {
            Balance -= Rate;
        }
        public void SetRate(int rate)
        {
            this.Rate = rate;
        }

        public override string ToString()
        {
            return $"{PlayerNum} {Name}  : {Balance} $ , Number {Number} , Rate : {Rate} $";
        }



    }
}
