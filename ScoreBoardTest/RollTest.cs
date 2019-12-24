using System;
using BowlingScore;
using FluentAssertions;
using Xunit;

namespace BowlingScoreTest
{
    public class RollTest
    {
        [Fact]
        public void ReturnsTrueForSpare()
        {
            var roll = '/';
            var expected = true;
            var actual = new Roll(roll).isSpare;

            actual.Should().Be(expected);
        }

        [Fact]
        public void ReturnsTrueForStrike()
        {
            var roll = 'X';
            var expected = true;
            var actual = new Roll(roll).isStrike;

            actual.Should().Be(expected);
        }

        [Fact]
        public void ReturnsTrueForGutter()
        {
            var roll = '-';
            var expected = true;
            var actual = new Roll(roll).isGutter;

            actual.Should().Be(expected);
        }

        [Fact]
        public void ReturnsZero()
        {
            var roll = '-';
            var expected = 0;
            var actual = new Roll(roll).pinsHit;

            actual.Should().Be(expected);
        }

        [Fact]
        public void ReturnsFive()
        {
            var roll = '5';
            var expected = 5;
            var actual = new Roll(roll).pinsHit;

            actual.Should().Be(expected);
        }

        [Fact]
        public void ReturnsTenForAStrike()
        {
            var roll = 'X';
            var expected = 10;
            var actual = new Roll(roll).pinsHit;

            actual.Should().Be(expected);
        }
        [Fact]
        public void ReturnsTenForASpare()
        {
            var roll = '/';
            var expected = 10;
            var actual = new Roll(roll).pinsHit;

            actual.Should().Be(expected);
        }

    }
}
