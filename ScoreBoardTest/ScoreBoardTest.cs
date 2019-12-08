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
        public void ReturnsZeroForGutterBalls()
        {
            var game = "--|--|--|--|--|--|--|--|--|--";
            var expected = 0;
            var actual = ScoreBoard.GetTotalScore(game);

            actual.Should().Be(expected);
        }

        [Fact]
        public void ReturnNineForAllGutterBallsExceptOneTurn()
        {
            var game = "--|--|--|--|--|--|--|--|--|-9";
            var expected = 9;
            var actual = ScoreBoard.GetTotalScore(game);

            actual.Should().Be(expected);
        }

        [Fact]
        public void ReturnsNinetyForAllBallsOnSecondTurn()
        {
            var game = "9-|9-|9-|9-|9-|9-|9-|9-|9-|9-";
            var expected = 90;
            var actual = ScoreBoard.GetTotalScore(game);

            actual.Should().Be(expected);
        }

        [Fact]
        public void ReturnTwentyEightForOneSpare()
        {
            var game = "--|--|--|--|--|--|--|--|-/|9-";
            var expected = 28;
            var actual = ScoreBoard.GetTotalScore(game);

            actual.Should().Be(expected);
        }
    }
}
