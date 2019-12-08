using System;
using System.Linq;

namespace BowlingScore
{
    public class Frame
    {
        public bool isSpareFrame { get; }
        public bool isStrikeFrame { get; }
        public int ballOnePinsHit { get; set; }
        public int ballTwoPinsHit { get; set; }

        public Frame(string turns)
        {
            this.isSpareFrame = IsSpareFrame(turns);
            this.isStrikeFrame = IsStrikeFrame(turns);
            this.ballOnePinsHit = GetFirstPinsHit(turns[0]);
            this.ballTwoPinsHit = turns.Length == 2 ? GetSecondPinsHit(turns[1]) : 0;
        }

        public bool IsSpareFrame(string turns)
        {
            return turns.Contains('/');
        }
        public bool IsStrikeFrame(string turns)
        {
            return turns == "X";
        }

        public int GetFirstPinsHit(char turn)
        {
            var pinsHit = 0;
            if (!this.isStrikeFrame)
            {
                pinsHit = CountForGutterOrPins(turn);
            }
            else
            {
                pinsHit = 10;
            }
            return pinsHit;
        }

        public int GetSecondPinsHit(char turn)
        {
            var pinsHit = 0;
            if (!this.isSpareFrame)
            {
                pinsHit = CountForGutterOrPins(turn);
            }
            else
            {
                pinsHit = 10 - this.ballOnePinsHit;
            }
            return pinsHit;
        }

        private static int CountForGutterOrPins(char turn)
        {
            return turn == '-' ? 0 : int.Parse(turn.ToString()); ;
        }

    }
}