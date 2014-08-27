using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Anachron
{
    class World
    {
        private List<Character> _characters = new List<Character>();

        public void AddCharacter(Character character)
        {
            _characters.Add(character);
        }

        public List<Character> Characters { get { return _characters; } }
    }
}
