using System;
using BowlingScore;
using FluentAssertions;
using Xunit;

namespace BowlingScoreTest
{
    public class ScoreBoardTest
    {
        [Fact]
        public void ReturnZeroForNoScore()
        {
            var game = "";
            var expected = 0;
            var actual = ScoreBoard.GetTotalScore(game);

            actual.Should().Be(expected);
        }

        [Fact]
        public void ReturnNineForAllGutterBallsExceptOneTurn()
        {
            var game = "--|--|--|--|--|--|--|--|--|-9||";
            var expected = 9;
            var actual = ScoreBoard.GetTotalScore(game);

            actual.Should().Be(expected);
        }

        [Fact]
        public void ReturnTwentyEightForOneSpare()
        {
            var game = "--|--|--|--|--|--|--|--|-/|9-||";
            var expected = 28;
            var actual = ScoreBoard.GetScoreIncludesSpareFrame(game);

            actual.Should().Be(expected);
        }
        
        [Fact]
        public void ReturnFourtyEightForOneStrikeOneSpareNinePins()
        {
            var game = "--|--|--|--|--|--|--|X|1/|9-||";
            var expected = 48;
            var actual = ScoreBoard.GetScoreOnStrikeFrame(game);

            actual.Should().Be(expected);
        }


    }
}
