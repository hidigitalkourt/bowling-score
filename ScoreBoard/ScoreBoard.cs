using System;
using System.Collections.Generic;
using System.Linq;


namespace BowlingScore
{
    public class ScoreBoard
    {
        private List<Frame> frames;
        public int totalScore {get;}

        public ScoreBoard(string scoreCard)
        {
            this.frames = GetFrames(scoreCard);
            this.totalScore = GetTotalScore(this.frames);
        }

        private List<Frame> GetFrames( string scoreCard)
        {
            var charSeparators = new char[] { '|' };
            return scoreCard.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries)
                .Select(frame => new Frame(frame))
                .ToList();
        }

        private int GetTotalScore(List<Frame> frames)
        {
            if (frames.Count == 0) return 0;
            var score = 0;

            for (var frameIndex = 0; frameIndex < 10; frameIndex++)
            {
                score+= frames[frameIndex].isOpenFrame ? GetScoreOnOpenFrame(frames[frameIndex]) : 
                        frames[frameIndex].isSpareFrame ? GetScoreOnSpareFrame(frames[frameIndex + 1]) : 0;

                if (frames[frameIndex].isStrikeFrame)
                {
                    int framesToAddForBonusBalls = frameIndex < 9 ? 3 : 2;
                    score += GetScoreOnStrikeFrame(frames.GetRange(frameIndex, framesToAddForBonusBalls));
                }
            }
            return score;
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

            foreach (var frame in frames)
            {
                if (frame.isOpenFrame || frame.isSpareFrame)
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
