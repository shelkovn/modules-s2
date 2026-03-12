using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace l6fbpw.Model
{
    public class CharacterFactory
    {
        private Dictionary<string, Character> _characters = new();
        public Character GetCharacter(char c, string font, int fontsize)
        {
            string key = $"{font}_{fontsize}_{c}";
            if (!_characters.ContainsKey(key))
            {
                _characters[key] = new Character(c, font, fontsize);
                Console.WriteLine($"Creating new character: {key}");
            }
            return _characters[key];
        }
        public int GetCount() => _characters.Count;
    }
}
