using System;
using System.Collections.Generic;
using System.Linq;


namespace BowlingScore
{
    public class ScoreBoard
    {
        private int gameScore;
        public ScoreBoard( string game)
        {
            this.gameScore = GetTotalScore(game);
        }
        private int GetTotalScore(string scoreCard)
        {
            if (scoreCard.Length == 0) return 0;
            char[] charSeparators = new char[] { '|' };
            var score = 0;
            var game = scoreCard.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries)
                .Select(frame => new Frame(frame))
                .ToList();

            for (var frame = 0; frame < 10; frame++)
            {
                int framesToAddForBonusBalls;
                if (game[frame].isStrikeFrame)
                {
                    framesToAddForBonusBalls = frame < 9 ? 3 : 2;
                    score += GetScoreOnStrikeFrame(game.GetRange(frame, framesToAddForBonusBalls));

                }
                else if (game[frame].isSpareFrame)
                {
                    framesToAddForBonusBalls = 2;
                    score += GetScoreOnSpareFrame(game.GetRange(frame, framesToAddForBonusBalls));
                }
                else
                {
                    score += GetScoreOnGutterOrPinsFrame(game[frame]);
                }

            }
            return score;
        }

        private int GetScoreOnGutterOrPinsFrame(Frame frame)
        {
            return frame.ballOnePinsHit + frame.ballTwoPinsHit;
        }

        private int GetScoreOnSpareFrame(List<Frame> frames)
        {
            var currentFramePinsHit = frames[0].ballOnePinsHit + frames[0].ballTwoPinsHit;
            return currentFramePinsHit + frames[1].ballOnePinsHit;
        }

        private int GetScoreOnStrikeFrame(List<Frame> frames)
        {
            var bonusPinsList = new List<int>();
            var currentFramePinsHit = frames[0].ballOnePinsHit;

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
            return currentFramePinsHit + bonusPinsList.GetRange(0, 2).Sum();
        }
    }
}
