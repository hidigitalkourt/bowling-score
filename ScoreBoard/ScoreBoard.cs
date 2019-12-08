using System;
using System.Collections.Generic;
using System.Linq;


namespace BowlingScore
{
    public static class ScoreBoard
    {
        public static int GetTotalScore(string scoreCard)
        {
            if( scoreCard.Length == 0) return 0;
            char[] charSeparators = new char[] {'|'};
            var score = 0;
            var game = scoreCard.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries)
                .Select(frame => new Frame(frame))
                .ToList();

            for (var frame = 0; frame < 10; frame++)
            {

                if (game[frame].isStrikeFrame)
                {
                    score += GetScoreOnStrikeFrame(game.GetRange(frame, 3));
                }
                else if (game[frame].isSpareFrame)
                {
                    score += GetScoreOnSpareFrame(game.GetRange(frame, 2));
                }
                else 
                {
                    score += GetScoreOnGutterOrPinsFrame(game[frame]);
                }

            }
            return score;
        }

        public static int GetScoreOnGutterOrPinsFrame(Frame frame)
        {
            return frame.ballOnePinsHit + frame.ballTwoPinsHit;
        }

        public static int GetScoreOnSpareFrame(List<Frame> frames)
        {
            var currentFramePinsHit = frames[0].ballOnePinsHit + frames[0].ballTwoPinsHit;
            return currentFramePinsHit + frames[1].ballOnePinsHit;
        }

        public static int GetScoreOnStrikeFrame(List<Frame> frames)
        {
            var bonusPinsList = new List<int>();
            var currentFramePinsHit = frames[0].ballOnePinsHit;

            foreach (var frame in frames.GetRange(1, 2))
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
