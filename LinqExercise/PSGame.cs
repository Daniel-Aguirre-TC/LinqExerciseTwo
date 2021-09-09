using System;
using System.Collections.Generic;
using System.Text;

namespace LinqExercise
{
    public class PSGame : Game
    {
        public override string GameConsole { get; set; } = "PlayStation One";
        public PSGame(string name, int yearReleased) : base(name, yearReleased)
        {

        }
    }
    
}
