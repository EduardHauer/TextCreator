using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextCreator
{
    class TextCreator
    {
        public WordSignature wS;

        string[] sP;

        public string[,,] w;

        public TextCreator(string _s, char _sS = ' ', char _eS = '.', string[,,] _w = null)
        {
            if(_w != null)
            {
                w = _w;
            }
            wS = new WordSignature(_s, _sS, _eS);
        }

        private void StructurePluss()
        {
            var str = wS.s.Split(new char[] { ':' }).ToArray();
            sP = str;
        }

        private string GenerateText()
        {
            Random r = new Random();
            int _a = r.Next(6);
            int b = r.Next(3);
            bool c = r.Next(2) == 1;

            string text = "";

            if (wS.sS != ' ') text += wS.sS;

            for (int i = 0; i < sP.Length; i++)
            {
                int j = 0;
                if(sP[i][0] == '{')
                {
                    j++;
                    if (c)
                    {
                        break;
                    }
                }
                if(sP[i][j] == 'n' && (sP[i].Length == 1 || j == 1))
                {
                    if (i > 0) text += $" {w[0, _a, b].ToLower()}";
                    else text += w[0, _a, b];
                }
                else if (sP[i][j] == 'v' && (sP[i].Length == 1 || j == 1))
                {
                    if (i > 0) text += $" {w[1, _a, b].ToLower()}";
                    else text += w[1, _a, b];
                }
                else if (sP[i][j] == 'o' && (sP[i].Length == 1 || j == 1))
                {
                    if (i > 0) text += $" {w[2, _a, b].ToLower()}";
                    else text += w[2, _a, b];
                }
                else if (sP[i][j] == 'h' && (sP[i].Length == 1 || j == 1))
                {
                    if (i > 0) text += $" {w[3, _a, b].ToLower()}";
                    else text += w[3, _a, b];
                }
                else if (sP[i] == "not" || sP[i] == "{not}")
                {
                    if (j == 1) sP[i].Remove(sP[i].Length - 1).Remove(0, 1);
                    if (i > 0) text += $" {sP[i]}";
                    else text += sP[i];
                    _a = 0;
                }
            }

            text += wS.eS;

            return text;
        }

        public void WriteText()
        {
            StructurePluss();
            Console.WriteLine(GenerateText());
        }
    }

    public class TextMore
    {
        private TextCreator tC;

        WordSignatureMore wSM = new WordSignatureMore();

        public TextMore(string type, string[,,] _w = null)
        {
            tC = new TextCreator("");
            if (_w != null)
            {
                tC.w = _w;
            }
            switch (type)
            {
                case "+":
                    tC.wS = wSM.y;
                    break;
                case "-":
                    tC.wS = wSM.n;
                    break;
                case "?":
                    tC.wS = wSM.q;
                    break;
                default:
                    break;
            }
        }

        public void WriteText()
        {
            tC.WriteText();
        }
    }

    class WordSignature
    {
        public string s;

        public char sS;

        public char eS;

        public WordSignature(string _s, char _sS, char _eS)
        {
            s = _s;
            sS = _sS;
            eS = _eS;
        }
    }

    class WordSignatureMore
    {
        public WordSignature y = new WordSignature("n:v:{o}", ' ', '.');

        public WordSignature n = new WordSignature("n:h:not:v:{o}", ' ', '.');

        public WordSignature q = new WordSignature("h:n:v:{o}", ' ', '?');

        public WordSignatureMore()
        {
        }
    }

    class Var<T>
    {
        private static T variable;

        public T Get
        {
            get => variable;
        }

        public T Set
        {
            set => variable = value;
        }

        public Var()
        {
        }
    }
}
