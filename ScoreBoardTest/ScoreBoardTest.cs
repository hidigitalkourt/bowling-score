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
            var frames = "";
            var expected = 0;
            var actual = ScoreBoard.GetScore(frames);

            actual.Should().Be(expected);
        }

        [Fact]
        public void ReturnZeroForTwoGutterBalls()
        {
            var frames = "--";
            var expected = 0;
            var actual = ScoreBoard.GetScore(frames);

            actual.Should().Be(expected);
        }

        [Fact]
        public void ReturnOneForOneGutterBallOnePin()
        {
            var frames = "-1";
            var expected = 1;
            var actual = ScoreBoard.GetScore(frames);

            actual.Should().Be(expected);
        }
    }
}
