using System;
using BowlingScore;
using FluentAssertions;
using Xunit;

namespace BowlingScoreTest
{
    public class RollTest
    {
        [Fact]
        public void ReturnsNinePinsHitForSpare()
        {
            var roll = '/';
            var prevRoll = '1';
            var expected = 9;
            var actual = new Roll(prevRoll,roll);

            actual.PinsHit.Should().Be(expected);
        }

        [Fact]
        public void ReturnsTenPinsForStrike()
        {
            var roll = 'X';
            var expected = 10;
            var prevRoll = '1';

            var actual = new Roll(prevRoll,roll);

            actual.PinsHit.Should().Be(expected);
        }

        [Fact]
        public void ReturnsZeroPinsHitForGutter()
        {
            var roll = '-';
            var expected = 0;
            var prevRoll = '1';
            var actual = new Roll(prevRoll,roll);

            actual.PinsHit.Should().Be(expected);
        }

        [Fact]
        public void ReturnsFivePins()
        {
            var roll = '5';
            var expected = 5;
            var prevRoll = '1';
            var actual = new Roll(prevRoll,roll);

            actual.PinsHit.Should().Be(expected);
        }
    }
}
