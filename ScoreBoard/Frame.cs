using System;
using System.Linq;

namespace BowlingScore
{
    public class Frame
    {
        public bool isSpareFrame {get;}
        public bool isStrikeFrame {get;}

        public Frame( string turns)
        {
            this.isSpareFrame = IsSpareFrame(turns);
            this.isStrikeFrame = IsStrikeFrame(turns);
        }

        public bool IsSpareFrame( string turns)
        {
            return turns.Contains('/');
        }
        public bool IsStrikeFrame(string turns)
        {
            return turns == "X";
        }

    }
}