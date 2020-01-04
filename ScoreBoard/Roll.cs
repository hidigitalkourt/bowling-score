using System;
using System.Collections.Generic;
using System.Linq;

namespace BowlingScore
{
    public class Roll
    {
        
        public char roll;
        private char prevRoll;
        public int pinsHit;
        public bool isStrike;
        public bool isSpare;

        public int  PinsHit
        {
            get { 
                if (this.roll == '-')
                {
                    this.pinsHit = 0;
                }
                else if(this.roll == 'X')
                {
                    this.pinsHit = 10;
                }
                else if(this.roll == '/')
                {
                    this.pinsHit = 10 - (prevRoll == '-' ? 0 : int.Parse(this.prevRoll.ToString()));
                }
                else 
                {
                    this.pinsHit = int.Parse(this.roll.ToString());
                }
                return this.pinsHit;
                }
            set
            {
                this.pinsHit = value;
            }
        }
        public Roll(char prevRoll, char roll)
        {
           this.roll = roll;
           this.prevRoll = prevRoll;
           this.isStrike = IsStrike(roll);
           this.isStrike = IsSpare(roll);
        }
        private bool IsStrike( char roll)
        {
            return roll == 'X';
        }
        private bool IsSpare(char roll)
        {
            return roll == '/';
        }
    }
}