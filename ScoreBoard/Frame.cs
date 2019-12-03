using System;
using System.Linq;

namespace BowlingScore
{
    public class Frame
    {
        public bool isSpareFrame {get;}
        public bool isStrikeFrame {get;}
        public int ballOne {get; set;}

        public Frame( string turns)
        {
            this.isSpareFrame = IsSpareFrame(turns);
            this.isStrikeFrame = IsStrikeFrame(turns);
            this.ballOne = GetPinsHit(turns);
        }

        public bool IsSpareFrame( string turns)
        {
            return turns.Contains('/');
        }
        public bool IsStrikeFrame(string turns)
        {
            return turns == "X";
        }

        public int GetPinsHit( string turns)
        {
            var pinsHit = 0;
            if( !IsStrikeFrame(turns))
            {
                pinsHit =  turns[0] == '-' ? 0 : int.Parse(turns[0].ToString());
            }
            else
            {
                pinsHit = 10;
            }
            return this.ballOne = pinsHit;
        }

    }
}