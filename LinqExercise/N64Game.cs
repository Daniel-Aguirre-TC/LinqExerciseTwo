using System;
using System.Collections.Generic;
using System.Text;

namespace LinqExercise
{
    public class N64Game : Game
    {
        public override string GameConsole { get; set; } = "Nintendo 64";
        public N64Game(string name, int yearReleased) : base(name, yearReleased)
        {

        }
    }
}
