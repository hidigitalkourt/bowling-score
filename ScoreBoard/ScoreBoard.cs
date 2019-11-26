using System;
using System.Linq;

namespace BowlingScore
{
    public static class ScoreBoard
    {
        public static int GetScore(string game)
        {
            var frames = game.Split('|');
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

        public static int GetScoreOnSpareFrame(string game)
        {
            var score = 0;
            // var frames = game.Split('|');
            game.Split('|')
                .Select((frames, frame) => 
                    frames.Select((ball, index) => ball == '/'
                    ? 10 + int.Parse(frames[0])
                    :(ball == '-') ? 0 : int.Parse(ball.ToString()));
            // for (var frame = 0; frame < frames.Length; frame++)
            // {
            //     for (var ball = 0; ball < frames[frame].Length; ball++)
            //     {
            //         if (frames[frame][ball] == '/')
            //         {
            //             score += 10 + int.Parse(frames[frame + 1][0].ToString());
            //         }
            //         else
            //         {
            //             score += frames[frame][ball] == '-' ? 0 : int.Parse(frames[frame][ball].ToString());   
            //         }
            //     }
            // }
            return score;
        }

    }
}
