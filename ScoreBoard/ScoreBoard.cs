using System;
using System.Linq;

namespace BowlingScore
{
    public static class ScoreBoard
    {
        public static int GetScore(string game)
        {
            var frames = game.Split('|');
            return frames.Select( x => GetFrameSum(x)).Sum();
        }

        public static int GetFrameSum(string frame)
        {
            var sum = 0;
            foreach (char turn in frame)
            {
                sum += turn == '-' ? 0 : int.Parse(turn.ToString());
            }
            return sum;
        }

        public static int GetSumOnSpareFrame(string frame)
        {
            return 0;
        }

    }
}
