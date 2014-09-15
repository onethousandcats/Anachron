using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Anachron
{
    class World
    {
        private const int TerminalVelocity = 6;
        private const int Gravity = 1; 

        private Character _player = new Character();
        private List<Character> _otherPlayers = new List<Character>();
        public List<Collidable> Objects = new List<Collidable>();

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

        public void CheckFloor() 
        {
            //for each player
            foreach (Character c in this.AllPlayers)
            {
                c.falling = true;

                foreach (Collidable g in this.Objects)
                {
                    if (g.CollidesWith(c))
                    {
                        c.Grounded();
                    }
                }
            }
        }

        public void ApplyGravity()
        {
            foreach (Character c in this.AllPlayers)
            {
                if (c.falling)
                {
                    //apply gravity
                    c.vy = c.vy == TerminalVelocity ? TerminalVelocity : c.vy + Gravity;
                    c.y += c.vy;
                }
            }
        }
    }
}
