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
            var actual = ScoreBoard.GetScore(game);

            actual.Should().Be(expected);
        }

        [Fact]
        public void ReturnZeroForAllGutterBalls()
        {
            var game = "--";
            var expected = 0;
            var actual = ScoreBoard.GetScore(game);

            actual.Should().Be(expected);
        }

        [Fact]
        public void ReturnOneForOneGutterBallOnePin()
        {
            var game = "-1";
            var expected = 1;
            var actual = ScoreBoard.GetScore(game);

            actual.Should().Be(expected);
        }

    }
}
