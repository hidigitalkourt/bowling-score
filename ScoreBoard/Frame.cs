using System;
using System.Collections.Generic;
using System.Linq;

namespace BowlingScore
{
    public class Frame
    {
        public bool isSpareFrame { get; }
        public bool isStrikeFrame { get; }
        public int ballOnePinsHit { get; set; }
        public int ballTwoPinsHit { get; set; }
        public int bonusOneHitCount { get; set; }
        public int score { get; set; }

        public Frame(string turns)
        {
            this.isSpareFrame = IsSpareFrame(turns);
            this.isStrikeFrame = IsStrikeFrame(turns);
            this.ballOnePinsHit = GetFirstPinsHit(turns[0]);
            this.ballTwoPinsHit = turns.Length == 2 ? GetSecondPinsHit(turns[1]) : 0;
            this.bonusOneHitCount = 10;
            this.score = GetsFrameScore();
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
            return turn == '-' ? 0 : turn == 'X' ? 10 : int.Parse(turn.ToString()); ;
        }

        private static int GetsFrameScore()
        {
            return new List<int>{0}.Sum();
        }

    }
}