using System;
using System.Collections.Generic;
using System.Linq;

namespace BowlingScore
{
    public class Roll
    {
        public bool isGutter { get; }
        public bool isSpare { get; }
        public bool isStrike { get; }
        public int pinsHit { get; set; }
       

        public Roll(char roll)
        {
            this.isGutter = IsGutter(roll);
            this.isSpare = IsSpare(roll);
            this.isStrike = IsStrike(roll);
            this.pinsHit = GetPinsHit(roll);
        }

        public bool IsGutter(char rolls)
        {
            return rolls == '-';
        }
        public bool IsSpare(char rolls)
        {
            return rolls == '/';
        }
        public bool IsStrike(char rolls)
        {
            return rolls == 'X';
        }

        public int GetPinsHit(char roll)
        {
            var pinsHit = 0;
            if (this.isStrike)
            {
                pinsHit = CountForGutterOrPins(roll);
            }
            else
            {
                pinsHit = 10;
            }
            return pinsHit;
        }

        private static int CountForGutterOrPins(char roll)
        {
            return roll == '-' ? 0 : roll == 'X' ? 10 : int.Parse(roll.ToString()); ;
        }

    }
}