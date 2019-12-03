using System;
using System.Linq;

namespace BowlingScore
{
    public class Frame
    {
        public bool isSpareFrame {get;}
        public bool isStrikeFrame {get;}
        public int ballOne {get; set;}
        public int ballTwo {get; set;}

        public Frame( string turns)
        {
            this.isSpareFrame = IsSpareFrame(turns);
            this.isStrikeFrame = IsStrikeFrame(turns);
            this.ballOne = GetFirstPinsHit(turns[0]);
            this.ballTwo = turns.Length == 2 ? GetSecondPinsHit(turns[1]) : 0;
        }

        public bool IsSpareFrame( string turns)
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
                pinsHit = turn == '-' ? 0 : int.Parse(turn.ToString());
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
                pinsHit = turn == '-' ? 0 : int.Parse(turn.ToString());
            }
            else
            {
                pinsHit = 10 - this.ballOne;
            }
            return pinsHit;
        }

        

    }
}