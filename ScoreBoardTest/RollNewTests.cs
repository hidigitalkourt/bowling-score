using System;
using BowlingScore;
using FluentAssertions;
using Xunit;

namespace BowlingScoreTest
{
    public class RollNewTestNew
    {
        [Fact]
        public void ReturnsTrueForSpare()
        {
            var roll = '/';
            var expected = 5;
            var actual = new RollNew(roll);
            actual.PinsHit = 5;

            actual.PinsHit.Should().Be(expected);
        }

        [Fact]
        public void ReturnsTrueForStrike()
        {
            var roll = 'X';
            var expected = 10;
            var actual = new RollNew(roll);

            actual.PinsHit.Should().Be(expected);
        }

        [Fact]
        public void ReturnsTrueForGutter()
        {
            var roll = '-';
            var expected = 0;
            var actual = new RollNew(roll);

            actual.PinsHit.Should().Be(expected);
        }

        [Fact]
        public void ReturnsFive()
        {
            var roll = '5';
            var expected = 5;
            var actual = new RollNew(roll);
            actual.PinsHit = 5;

            actual.PinsHit.Should().Be(expected);
        }
    }
}
