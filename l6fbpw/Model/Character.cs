using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace l6fbpw.Model
{
    public class Character
    {
        char _symbol;
        string _font; 
        int _fontSize;

        public Character(char c, string font, int size)
        {
            _symbol = c;
            _font = font;
            _fontSize = size;
        }

        public void Draw(int x, int y)
        {
            Console.WriteLine($"{_font} {_fontSize} {_symbol} {x} {y}");
        }
    }
}
