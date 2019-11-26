using System;
using System.Linq;

namespace BowlingScore
{
    public static class ScoreBoard
    {
        public static int GetScore(string scoreCard)
        {
            var frames = scoreCard.Split('|');
            return frames.Select(x => GetFrameScore(x)).Sum();
        }

        public static int GetFrameScore(string frame)
        {
            var score = 0;
            foreach (char turn in frame)
            {
                score += turn == '-' ? 0 : int.Parse(turn.ToString());
            }
            return score;
        }

        public static int GetScoreOnSpareFrame(string scoreCard)
        {
            var score = 0;
            var game = scoreCard.Split('|');
            for (var frame = 0; frame < game.Length; frame++)
            {
                for (var ball = 0; ball < game[frame].Length; ball++)
                {
                    if (game[frame][ball] == '/')
                    {
                        score += 10 + int.Parse(game[frame + 1][0].ToString());
                    }
                    else
                    {
                        score += game[frame][ball] == '-' ? 0 : int.Parse(game[frame][ball].ToString());   
                    }
                }

            }
            return score;
        }

    }
}
