using System;
using System.Linq;

namespace BowlingScore
{
    public static class ScoreBoard
    {
        public static int GetTotalScore(string scoreCard)
        {
            var frames = scoreCard.Split('|');
            return frames.Select(x => GetScoreIncludesSpareFrame(x)).Sum();
        }

        public static int GetScoreIncludesSpareFrame(string scoreCard)
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
                    else if(game[frame][ball] == 'X')
                    {
                        score += GetScoreOnStrikeFrame(game[frame]);
                    } 
                    else
                    {
                        score += GetScoreOnGutterOrPinsFrame(game[frame][ball]);   
                    }
                }
            }
            return score;
        }

        public static int GetScoreOnGutterOrPinsFrame( char turn)
        {
            return turn == '-' ? 0 : int.Parse(turn.ToString());;
        }

        public static int GetScoreOnSpareFrame( string frame)
        {
            return 10 + (frame + 1)[0] == '-' ? 0 : int.Parse((frame + 1)[0].ToString());
        }

        public static int GetScoreOnStrikeFrame(string frame)
        {
            var nextFrameTurn1 = (frame + 1)[0] == '-' ? 0 : (frame + 1)[0] == 'X' ? 10 : int.Parse((frame + 1)[0].ToString());
            var nextFrameTurn2 = (frame + 1)[1] == '-' ? 0 : (frame + 1)[1] == '/' ? 10 - (frame + 1)[0] == '-' ? 0 : int.Parse((frame + 1)[0].ToString()) : int.Parse((frame + 1)[0].ToString());
            return 10 + nextFrameTurn2 + nextFrameTurn2;
        }

        
        

    }
}
