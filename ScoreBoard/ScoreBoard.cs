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
                if( turn == '-')
                {
                    sum+=0;
                }
                else
                {
                    sum+= int.Parse(turn.ToString());
                }
              
            }
            return sum;

        }


    }
}
