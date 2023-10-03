using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Math_Game
{
    public class Game
    {
        public DateTime DateTime { get; set; }

        public int Score { get; set; }

        public Game()
        {

            DateTime = DateTime.Now;
            Score = 0;

        }

        public override string ToString()
        {
            return $"Score: {this.Score}       {this.DateTime}";
        }
    }
}
