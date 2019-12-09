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
            var actual = new ScoreBoard(game);

            actual.Equals(expected);
        }

        [Fact]
        public void ReturnsZeroForGutterBalls()
        {
            var game = "--|--|--|--|--|--|--|--|--|--";
            var expected = 0;
            var actual = new ScoreBoard(game);

            actual.Equals(expected);
        }

        [Fact]
        public void ReturnNineForAllGutterBallsExceptOneTurn()
        {
            var game = "--|--|--|--|--|--|--|--|--|-9";
            var expected = 9;
            var actual = new ScoreBoard(game);

            actual.Equals(expected);
        }

        [Fact]
        public void ReturnsNinetyForAllBallsOnSecondTurn()
        {
            var game = "9-|9-|9-|9-|9-|9-|9-|9-|9-|9-";
            var expected = 90;
            var actual = new ScoreBoard(game);

            actual.Equals(expected);
        }

        [Fact]
        public void ReturnsOneHundredFiftyForAllSpareFrames()
        {

            var game = "5/|5/|5/|5/|5/|5/|5/|5/|5/|5/||5";
            var expected = 150;
            var actual = new ScoreBoard(game);

            actual.Equals(expected);
        }

        [Fact]
        public void ReturnTwentyEightForOneSpare()
        {
            var game = "--|--|--|--|--|--|--|--|-/|9-";
            var expected = 28;
            var actual = new ScoreBoard(game);

            actual.Equals(expected);
        }

        [Fact]
        public void ReturnsThreeHunddredForAllStrikeFrames()
        {
            var game = "X|X|X|X|X|X|X|X|X|X||XX";
            var expected = 300;
            var actual = new ScoreBoard(game);

            actual.Equals(expected);
        }
    }
}
