using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Anachron
{
    class World
    {

        private Character _player = new Character();
        private List<Character> _otherPlayers = new List<Character>();

        public void AddPlayer(Character character)
        {
            _otherPlayers.Add(character);
        }

        public List<Character> OtherPlayers { get { return _otherPlayers; } }
        
        public Character Player { get { return _player;  } }
        
        public List<Character> AllPlayers { 
            get {
                _otherPlayers.Add(Player);
                return _otherPlayers;
            }
        }
    }
}
