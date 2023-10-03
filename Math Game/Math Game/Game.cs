using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Math_Game.Program;

namespace Math_Game
{
    public class Game
    {
        public DateTime DateTime { get; set; }

        public int Score { get; set; }

        public Operation OperationName { get; set; }

        public Game(Operation operation)
        {

            DateTime = DateTime.Now;
            Score = 0;
            OperationName = operation;

        }

        public override string ToString()
        {
            const string FORMAT = "{0, -15} Score:{1, -10} {2, -20}";

           return String.Format( FORMAT, OperationName, this.Score,this.DateTime);
        }
    }
}
