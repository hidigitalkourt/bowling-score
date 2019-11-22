using System;

namespace BowlingScore
{
    public static class ScoreBoard
    {
        public static int GetScore(string frames)
        {
            if (frames.Length == 0)
            {
                return 0;
            }
            var game = frames.Split('|');
            var sum = 0;
            for (var frame = 0; frame < game.Length; frame ++)
            {   
                foreach( var ball in frame.ToString())
                {
                    sum += int.Parse(ball.ToString());
                }
               
            }
            return sum;
        }


    }
}
