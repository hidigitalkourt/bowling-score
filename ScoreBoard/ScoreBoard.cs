using System;
using System.Collections.Generic;
using System.Linq;


namespace BowlingScore
{
    public static class ScoreBoard
    {
        public static int GetTotalScore(string scoreCard)
        {
            if (scoreCard.Length == 0) return 0;
            char[] charSeparators = new char[] { '|' };
            var score = 0;
            var game = scoreCard.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries)
                .Select(frame => new Frame(frame))
                .ToList();

            for (var frameIndex = 0; frameIndex < 10; frameIndex++)
            {
                score += game[frameIndex].isOpenFrame ? GetScoreOnGutterOrPinsFrame(game[frameIndex]) : 0;
                score += game[frameIndex].isSpareFrame ? GetScoreOnSpareFrame(game[frameIndex + 1]) : 0;

                if (game[frameIndex].isStrikeFrame)
                {
                    int framesToAddForBonusBalls = frameIndex < 9 ? 3 : 2;
                    score += GetScoreOnStrikeFrame(game.GetRange(frameIndex, framesToAddForBonusBalls));
                }
            }
            return score;
        }

        private static int GetScoreOnGutterOrPinsFrame(Frame frame)
        {
            return frame.ballOnePinsHit + frame.ballTwoPinsHit;
        }

        private static int GetScoreOnSpareFrame(Frame frame)
        {
            return 10 + frame.ballOnePinsHit;
        }

        private static int GetScoreOnStrikeFrame(List<Frame> frames)
        {
            var bonusPinsList = new List<int>();

            foreach (var frame in frames)
            {
                if (!frame.isStrikeFrame || frame.isSpareFrame)
                {
                    bonusPinsList.Add(frame.ballOnePinsHit);
                    bonusPinsList.Add(frame.ballTwoPinsHit);
                }
                if (frame.isStrikeFrame)
                {
                    bonusPinsList.Add(frame.ballOnePinsHit);
                }
            }
            return 10 + bonusPinsList.GetRange(0, 2).Sum();
        }
    }
}
