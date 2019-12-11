using System;
using BowlingScore;
using FluentAssertions;
using Xunit;

namespace BowlingScoreTest
{
    public class FrameTest
    {
        [Fact]
        public void ReturnsTrueForSpareFrame()
        {
            var frame = "5/";
            var expected = true;
            var actual = new Frame(frame).isSpareFrame;

            actual.Should().Be(expected);
        }

        [Fact]
        public void ReturnsTrueForStrikeFrame()
        {
            var frame = "X";
            var expected = true;
            var actual = new Frame(frame).isStrikeFrame;

            actual.Should().Be(expected);
        }

        [Fact]
        public void ReturnsZeroForBallOne()
        {
            var frame = "-/";
            var expected = 0;
            var actual = new Frame(frame).ballOnePinsHit;

            actual.Should().Be(expected);
        }

        [Fact]
        public void ReturnsFiveForBallOne()
        {
            var frame = "5/";
            var expected = 5;
            var actual = new Frame(frame).ballOnePinsHit;

            actual.Should().Be(expected);
        }

        [Fact]
        public void ReturnsTenForBallOne()
        {
            var frame = "X";
            var expected = 10;
            var actual = new Frame(frame).ballOnePinsHit;

            actual.Should().Be(expected);
        }

        [Fact]
        public void ReturnsZeroForBallTwo()
        {
            var frame = "--";
            var expected = 0;
            var actual = new Frame(frame).ballTwoPinsHit;

            actual.Should().Be(expected);
        }

        [Fact]
        public void ReturnsZeroForBallTwoStrikeFrame()
        {
            var frame = "X";
            var expected = 0;
            var actual = new Frame(frame).ballTwoPinsHit;

            actual.Should().Be(expected);
        }

        [Fact]
        public void ReturnsFiveForBallTwo()
        {
            var frame = "-5";
            var expected = 5;
            var actual = new Frame(frame).ballTwoPinsHit;

            actual.Should().Be(expected);
        }

        [Fact]
        public void ReturnsTenForBallTwo()
        {
            var frame = "-/";
            var expected = 10;
            var actual = new Frame(frame).ballTwoPinsHit;

            actual.Should().Be(expected);
        }

    }
}
