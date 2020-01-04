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
            var actual = new ScoreBoard().GetTotalScore(game);

            actual.Should().Be(expected);
        }

        [Fact]
        public void ReturnsZeroForGutterBalls()
        {
            var game = "--|--|--|--|--|--|--|--|--|--";
            var expected = 0;
            var actual = new ScoreBoard().GetTotalScore(game);

            actual.Should().Be(expected);
        }

        [Fact]
        public void ReturnNineForAllGutterBallsExceptOneTurn()
        {
            var game = "-9|--|--|--|--|--|--|--|--|--";
            var expected = 9;
            var actual = new ScoreBoard().GetTotalScore(game);

            actual.Should().Be(expected);
        }

        [Fact]
        public void ReturnsNinetyForAllBallsOnSecondTurn()
        {
            var game = "9-|9-|9-|9-|9-|9-|9-|9-|9-|9-";
            var expected = 90;
            var actual = new ScoreBoard().GetTotalScore(game);

            actual.Should().Be(expected);
        }

        [Fact]
        public void ReturnsOneHundredFiftyForAllSpareFrames()
        {

            var game = "5/|5/|5/|5/|5/|5/|5/|5/|5/|5/||5";
            var expected = 150;
            var actual = new ScoreBoard().GetTotalScore(game);

            actual.Should().Be(expected);
        }

        [Fact]
        public void ReturnTwentyEightForOneSpareInFirstFrame()
        {
            var game = "-/|9-|--|--|--|--|--|--|--|--";
            var expected = 28;
            var actual = new ScoreBoard().GetTotalScore(game);

            actual.Should().Be(expected);
        }

        [Fact]
        public void ReturnsFiftySixForOneSpareInFirstFrameAndOneSpareInThrirdFrame()
        {
            var game = "-/|9-|-/|9-|--|--|--|--|--|--";
            var expected = 56;
            var actual = new ScoreBoard().GetTotalScore(game);

            actual.Should().Be(expected);
        }
        [Fact]
        public void ReturnTwentyEightForOneSpareInLastFrame()
        {
            var game = "--|--|--|--|--|--|--|--|-/|9-";
            var expected = 28;
            var actual = new ScoreBoard().GetTotalScore(game);

            actual.Should().Be(expected);
        }

        [Fact]
        public void ReturnsThreeHunddredForAllStrikeFrames()
        {
            var game = "X|X|X|X|X|X|X|X|X|X||XX";
            var expected = 300;
            var actual = new ScoreBoard().GetTotalScore(game);

            actual.Should().Be(expected);
        }

        [Fact]
        public void ReturnsSixteyForThreeStrikesInFirstThreeFramesAndOneSpare()
        {
            var game = "X|X|X|-/|--|--|--|--|--|--||--";
            var expected = 80;
            var actual = new ScoreBoard().GetTotalScore(game);

            actual.Should().Be(expected);
        }

        [Fact]
        public void ReturnScoreForOneStrikeInFirstFrameFivePinsAndOneSpareInSecondFrameAndThreePinsInThrirdFrame()
        {
            var game = "X|5/|3-|--|--|--|--|--|--|--||--";
            var expected = 36;
            var actual = new ScoreBoard().GetTotalScore(game);

            actual.Should().Be(expected);
        }

        
        public void ReturnsCorrectScoreForMixedFrames()
        {

            var game = "X|7/|9-|X|-8|8/|-6|X|X|X||81";
            var expected = 167;
            var actual = new ScoreBoard().GetTotalScore(game);

            actual.Should().Be(expected);
        }
    }
}
