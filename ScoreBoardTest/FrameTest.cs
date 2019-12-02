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
    }
}
