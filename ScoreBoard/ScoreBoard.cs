using System;
using System.Linq;

namespace BowlingScore
{
    public static class ScoreBoard
    {
        public static int GetScore(string game)
        {
            char[] frame = game.ToCharArray();
            var sum = 0;
            foreach (char turn in frame)
            {
             sum+= turn == '-' ? 0: int.Parse(turn.ToString());
            }
            return sum;

        }


    }
}
