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
            string[,,] w = new string[,,]
        {
            {
                { "I"   ,   "I"   ,   "I"      },
                { "You" ,   "You" ,   "You"    },
                { "He"  ,   "She" ,   "It"     },
                { "We"  ,   "We"  ,   "We"     },
                { "You" ,   "You" ,   "You"    },
                { "They",   "They",   "They"   }
            },
            {
                { "Play",   "Play",   "Play"   },
                { "Play",   "Play",   "Play"   },
                { "Plays",  "Plays",  "Plays"  },
                { "Play",   "Play",   "Play"   },
                { "Play",   "Play",   "Play"   },
                { "Play",   "Play",   "Play"   }
            },
            {
                { "A game", "A game", "A game" },
                { "A game", "A game", "A game" },
                { "A game", "A game", "A game" },
                { "A game", "A game", "A game" },
                { "A game", "A game", "A game" },
                { "A game", "A game", "A game" }
            },
            {
                { "Do",     "Do",     "Do"     },
                { "Do",     "Do",     "Do"     },
                { "Does",   "Does",   "Does"   },
                { "Do",     "Do",     "Do"     },
                { "Do",     "Do",     "Do"     },
                { "Do",     "Do",     "Do"     }
            }
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
            TextMore tM = new TextMore(type, w);

            tM.WriteText();
            Console.ReadLine();
        }
    }
}
