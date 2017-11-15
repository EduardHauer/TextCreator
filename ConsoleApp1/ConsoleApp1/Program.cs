using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TextCreator;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] n = new string[,]
            {
                { "I", "You", "He", "She", "It", "We", "You", "They" },
                { "Game", "Game", "Game", "Game", "Game", "Game", "Game", "Game" }
            };

            string[,] v = new string[,]
            {
                { "Play", "Play", "Play", "Plays", "Plays", "Plays", "Play", "Play", "Play" },
                { "Be", "Am", "Are", "Is", "Is", "Is", "Are", "Are", "Are" }
            };

            string[,] h = new string[,]
            {
                { "Do", "Do", "Does", "Does", "Does", "Do", "Do", "Do" }
            };

            bool[] s = new bool[]
            {
                false,
                true
            };

            Random r = new Random();

            string type;

            switch (r.Next(3))
            {
                case 0:
                    type = "+";
                    break;
                case 1:
                    type = "-";
                    break;
                default:
                    type = "?";
                    break;

            }

            TextCreatorPlus tM = new TextCreatorPlus(type, 3, n, v, h, new int[] { 0, 1 }, s);

            tM.WriteText();

            Console.ReadLine();
        }
    }
}
