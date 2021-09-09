using System;
using System.Collections.Generic;
using System.Text;

namespace LinqExercise
{
    class GamecubeGame : Game
    {

        public override string GameConsole { get; set; } = "Gamecube";

        public GamecubeGame(string name, int yearReleased) : base(name, yearReleased)
        {
            
        }

    }
}
