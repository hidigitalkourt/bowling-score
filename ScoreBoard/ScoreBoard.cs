using System;
using System.Collections.Generic;
using System.Linq;

namespace BowlingScore
{
    public class ScoreBoard
    {
        private List<Roll> rolls = new List<Roll>();
        
        private void GetRolls(string scoreCard)
        {
            var charSeparators = new char[] { '|' };
            var generatedRolls = scoreCard.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries)
                .Select(frame => frame.Select(x => new Roll(x)))
                .SelectMany(x => x)
                .ToList();
            rolls.AddRange(generatedRolls);
        }

        public int GetTotalScore(string scoreCard)
        {
            GetRolls(scoreCard);

            if (rolls.Count == 0)
            {
                return 0;
            }

            var score = 0;
            var frameIndex =0;
            for (var frame = 0; frame < 10; frame++)
            {
                if(rolls[frameIndex].isStrike)
                {
                  score += GetStrikeFrameCount(frameIndex);
                  frameIndex ++;  
                }
                else if(rolls[frameIndex].isSpare)
                {
                    score += GetSpareFrameCount(frameIndex);
                    frameIndex += 2;
                }
                else
                {
                    score += GetScoreOnOpenFrame(frameIndex);
                }
            }
            return score;
        }

        private int GetScoreOnOpenFrame(int frameIndex)
        {
            return rolls[frameIndex].pinsHit + rolls[frameIndex+1].pinsHit;
        }

        private int GetSpareFrameCount(int frameIndex)
        {
            return 10 - rolls[frameIndex - 1].pinsHit + rolls[frameIndex + 1].pinsHit;
        }

        private int GetStrikeFrameCount(int frameIndex)
        {
            return 10 + rolls[frameIndex+1].pinsHit + rolls[frameIndex+2].pinsHit;
        }


    }
}
