using System;
using System.Collections.Generic;
using System.Linq;

namespace BowlingScore
{
    public class RollNew
    {
        public char roll;
        public int pinsHit;
        public int  PinsHit
        {
            get { 
                return pinsHit;
                }
            set
            {
                if (this.roll == '-')
                {
                    this.pinsHit = 0;
                }
                else if(this.roll == 'X')
                {
                    this.pinsHit = 10;
                }
                else
                {
                    this.pinsHit = value;
                }
            }
        }
        public RollNew(char roll)
        {
           this.roll = roll;
        }

    }
}