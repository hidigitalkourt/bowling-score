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
                .SelectMany(ball => ball)
                .ToList();
            if (generatedRolls.Count > 0)
            {
                rolls.Add(new Roll('0', generatedRolls[0]));
                for (var i = 1; i < generatedRolls.Count; i++)
                {
                    rolls.Add(new Roll(generatedRolls[i - 1], generatedRolls[i]));
                }
            }
        }

        public int GetTotalScore(string scoreCard)
        {
            GetRolls(scoreCard);

            if (rolls.Count == 0)
            {
                return 0;
            }
            var score = 0;
            var frameIndex = 0;
            for (var frame = 0; frame < 10; frame++)
            {
                if (rolls[frameIndex].roll == 'X')
                {
                    score += GetStrikeFrameCount(frameIndex);
                    frameIndex++;
                }
                else if (rolls[frameIndex + 1].roll == '/')
                {
                    score += GetSpareFrameCount(frameIndex);
                    frameIndex += 2;
                }
                else
                {
                    score += GetScoreOnOpenFrame(frameIndex);
                    frameIndex += 2;
                }

            }
            return score;
        }
       

        private int GetScoreOnOpenFrame(int frameIndex)
        {
            return rolls[frameIndex].PinsHit + rolls[frameIndex + 1].PinsHit;
        }
        private int GetSpareFrameCount(int frameIndex)
        {
            return 10 + rolls[frameIndex + 2].PinsHit;
        }
        private int GetStrikeFrameCount(int frameIndex)
        {
            return 10 + rolls[frameIndex + 1].PinsHit + rolls[frameIndex + 2].PinsHit;
        }

    }
}
