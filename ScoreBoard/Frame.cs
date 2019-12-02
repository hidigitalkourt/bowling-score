using System;
using System.Linq;

namespace BowlingScore
{
    public class Frame
    {
        public bool isSpareFrame {get;}

        public Frame( string turns)
        {
            this.isSpareFrame = IsSpareFrame(turns);
        }

        public bool IsSpareFrame( string turns)
        {
            return turns.Contains('/');
        }
   
    }
}