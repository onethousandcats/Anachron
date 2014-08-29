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

        public Character Player { get { return _player; } set { _player = value; } }
        
        public List<Character> AllPlayers { 
            get {
                List<Character> allPlayers = new List<Character>();

                foreach (var o in OtherPlayers)
                {
                    allPlayers.Add(o);
                }

                allPlayers.Add(_player);

                return allPlayers;
            }
        }
    }
}
