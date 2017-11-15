using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextCreator
{
    class TextCreator
    {
        public TextStructure tS;

        string[] sP;

        public string[,] n;

        public string[,] v;

        public string[,] h;

        public int f;

        public bool[] s;

        public string[] article = new string[] { "A", "The" };

        public int[] o;

        public TextCreator(string _tS, int _f, string[,] _n, string[,] _v, string[,] _h, int[] _o, bool[] _s = null, char _sS = ' ', char _eS = '.')
        {
            if (_s == null)
            {
                _s = new bool[_n.GetLength(0)];
            }

            n = _n;

            v = _v;

            h = _h;

            f = _f;

            s = _s;

            o = _o;

            tS = new TextStructure(_tS, _sS, _eS);
        }

        private void StructurePlus()
        {
            var str = tS.s.Split(new char[] { ':' }).ToArray();
            sP = str;
        }

        private string GenerateText()
        {
            Random r = new Random();

            string text = "";

            if (tS.sS != ' ') text += tS.sS;

            int u = 0;

            int g = 0;

            for (int i = 0; i < sP.Length; i++)
            {
                if(sP[i][0] == '{')
                {
                    if (r.Next(1) == 1)
                    {
                        break;
                    }

                    sP[i] = sP[i].Remove(sP[i].Length - 1).Remove(0, 1);
                }

                if(sP[i] == "n")
                {
                    if (s[o[u]] && i == 0) { text += $"{article[g]} {n[o[u], f].ToLower()}"; g = 1; }
                    else if (i > 0 && s[o[u]]) { text += $" {article[g].ToLower()} {n[o[u], f].ToLower()}"; g = 1; }
                    else if (i > 0) text += $" {n[o[u], f].ToLower()}";
                    else text += n[o[u], f];
                    u++;
                }
                else if (sP[i] == "v")
                {
                    if (i > 0) text += $" {v[0, f + 1].ToLower()}";
                    else text += v[0, f + 1];
                }
                else if (sP[i] == "a" || sP[i] == "a")
                {
                    if (s[o[u]] && i == 0) { text += $"{article[g]} {n[o[u], f].ToLower()}"; g = 1; }
                    else if (i > 0 && s[o[u]]) { text += $" {article[g].ToLower()} {n[o[u], f].ToLower()}"; g = 1; }
                    else if (i > 0) text += $" {n[o[u], f].ToLower()}";
                    else text += n[o[u], f];
                    u++;
                }
                else if (sP[i] == "h")
                {
                    if (i > 0) text += $" {h[0, f].ToLower()}";
                    else text += h[0, f];
                }
                else if (sP[i][0] != ' ')
                {
                    if (i > 0) text += $" {sP[i]}";
                    else text += sP[i];
                    f = 0;
                }
            }

            text += tS.eS;

            return text;
        }

        public void WriteText()
        {
            StructurePlus();
            Console.WriteLine(GenerateText());
        }
    }

    public class TextCreatorPlus
    {
        private TextCreator tC;

        TextStructures wSM = new TextStructures();

        public TextCreatorPlus(string type,int _f, string[,] _n, string[,] _v, string[,] _h, int[] _o, bool[] _s = null)
        {
            tC = new TextCreator("", _f, _n, _v, _h, _o, _s);

            switch (type)
            {
                case "+": tC.tS = wSM.y; break;
                case "-": tC.tS = wSM.n; break;
                case "?": tC.tS = wSM.q; break;
                default: break;
            }
        }

        public void WriteText()
        {
            tC.WriteText();
        }
    }

    class TextStructure
    {
        public string s;

        public char sS;

        public char eS;

        public TextStructure(string _s, char _sS, char _eS)
        {
            s = _s;
            sS = _sS;
            eS = _eS;
        }
    }

    class TextStructures
    {
        public TextStructure y;

        public TextStructure n;

        public TextStructure q;

        public TextStructures(TextStructure _y, TextStructure _n, TextStructure _q)
        {
            y = _y;
            n = _n;
            q = _q;
        }

        public TextStructures()
        {
            y = new TextStructure("n:v:{a}", ' ', '.');
            n = new TextStructure("n:h:not:v:{a}", ' ', '.');
            q = new TextStructure("h:n:v:{a}", ' ', '?');
        }
    }
}
