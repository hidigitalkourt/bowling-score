using System;
using System.Collections.Generic;
using System.Linq;


namespace BowlingScore
{
    public class ScoreBoard
    {
        public int GetTotalScore(string scoreCard)
        {
            var frames = GetFrames(scoreCard);
            if (frames.Count == 0) return 0;
            var score = 0;

            for (var frameIndex = 0; frameIndex < 10; frameIndex++)
            {
                score += frames[frameIndex].isOpenFrame ? GetScoreOnOpenFrame(frames[frameIndex]) :
                        frames[frameIndex].isSpareFrame ? GetScoreOnSpareFrame(frames[frameIndex + 1]) :
                        frames[frameIndex].isStrikeFrame ? GetScoreOnStrikeFrame(frames.GetRange(frameIndex, frameIndex < 9 ? 3 : 2)) : 0;
            }
            return score;
        }

        private List<Frame> GetFrames(string scoreCard)
        {
            var charSeparators = new char[] { '|' };
            return scoreCard.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries)
                .Select(frame => new Frame(frame))
                .ToList();
        }

        private int GetScoreOnOpenFrame(Frame frame)
        {
            return frame.ballOnePinsHit + frame.ballTwoPinsHit;
        }

        private int GetScoreOnSpareFrame(Frame frame)
        {
            return 10 + frame.ballOnePinsHit;
        }

        private int GetScoreOnStrikeFrame(List<Frame> frames)
        {
            var bonusPinsList = new List<int>();

            for (var frameIndex = 0; frameIndex < 2; frameIndex++)
            {
                if (frames[frameIndex].isOpenFrame || frames[frameIndex].isSpareFrame)
                {
                    bonusPinsList.Add(frames[frameIndex].ballOnePinsHit);
                    bonusPinsList.Add(frames[frameIndex].ballTwoPinsHit);
                }
                if (frames[frameIndex].isStrikeFrame)
                {
                    bonusPinsList.Add(frames[frameIndex].ballOnePinsHit);
                }
            }
            return 10 + bonusPinsList.GetRange(0, 2).Sum();
        }
    }
}
