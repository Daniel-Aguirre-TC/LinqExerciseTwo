using System;
using System.Collections.Generic;
using System.Text;

namespace LinqExercise
{
    public abstract class Game
    {
        public static List<Game> All = new List<Game>()
            {
                new N64Game("Super Mario 64", 1996),
                new N64Game("Pilotwings 64", 1996),
                new N64Game("Wave Race 64", 1996),
                new N64Game("Star Wars: Shadows of the Empire", 1997),
                new N64Game("Mario Kart 64", 1997),
                new N64Game("Star Fox 64", 1997),
                new N64Game("Top Gear Rally", 1997),
                new N64Game("Diddy Kong Racing", 1997),
                new GamecubeGame("Luigi's Mansion", 2001),
                new GamecubeGame("Super Monkey Ball", 2001),
                new GamecubeGame("Dark Summit", 2002),
                new GamecubeGame("Gauntlet: Dark Legacy", 2002),
                new GamecubeGame("Resident Evil 2", 2003),
                new GamecubeGame("The Sims", 2003),
                new GamecubeGame("Pikmin 2", 2004),
                new GamecubeGame("X-Men Legends", 2004),
                new PSGame("Castlevania: Symphony of the Night", 1997),
                new PSGame("Metal Gear Solid", 1998),
                new PSGame("Resident Evil 2", 1998),
                new PSGame("Suikoden II", 1999),
                new PSGame("Xenogears", 1998),
                new PSGame("Final Fantasy VII", 1997),
                new PSGame("Resident Evil", 1996),
                new PSGame("Tekken 3", 1998),
            };


        public string Name { get; set; }
        public int YearReleased { get; set; }
        abstract public string GameConsole { get; set; }

        public Game(string name, int yearReleased)
        {
            Name = name;
            YearReleased = yearReleased;
        }
    }

}
