
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace Bowling.Score.Tests
{
	[TestFixture]
	public class BowlingTest
	{
		private BowlingGame _game;

		[SetUp]
		public void SetUp()
		{
			_game = new BowlingGame();
		}

		[Test]
		public void TestRollingAllGutterBalls()
		{
			for (int i = 0; i < 10; i++) { _game.Roll(0, 0); }
			Assert.AreEqual(0, _game.Score());
		}

		[Test]
		public void TestRollingAllOnes()
		{
			for (int i = 0; i < 10; i++) { _game.Roll(1, 1); }
			Assert.AreEqual(20, _game.Score());
		}

		[Test]
		public void TestFirstFrameSpareOthersRollingAllTwos()
		{
			_game.Roll(9,1);
			for (int i = 0; i < 9; i++) { _game.Roll(2, 2); }
			Assert.AreEqual(48, _game.Score());
		}

		[Test]
		public void TestFirstTwoFramesSparesOthersAllRollTwos()
		{
			_game.Roll(5,5);
			_game.Roll(5,5);
			for (int i = 0; i < 8; i++) { _game.Roll(2, 2); }
			Assert.AreEqual(59, _game.Score());
		}

		[Test]
		public void TestGameOver()
		{
			for (int i = 0; i < 10; i++) { _game.Roll(0, 0); }
            void CheckFunction()
            {
                _game.Roll(0, 0);
            }
            Assert.Throws(typeof(GameOverException), CheckFunction);
        }

        [Test]
		public void TestFirstFrameStrikeOthersRollAllTwos()
		{
			_game.RollStrike();
			for (int i = 0; i < 9; i++) { _game.Roll(2, 2); }
			Assert.AreEqual(50,_game.Score());
		}

		[Test]
		public void TestFirstTwosFramesStrikeOthersRollAllTwos()
		{
			_game.RollStrike();
			_game.RollStrike();
			for (int i = 0; i < 8; i++) { _game.Roll(2, 2); }
			Assert.AreEqual(68,_game.Score());
		}

		[Test]
		public void TestPerfectGame()
		{
			for (int i = 0; i < 9; i++) { _game.RollStrike(); }
			_game.RollLastFrame(10,10,10);
			Assert.AreEqual(300,_game.Score());
		}

		[Test]
		public void TestAlternatingStrikesAndSpares()
		{
			_game.RollStrike();
			_game.Roll(4, 6);
			_game.RollStrike();
			_game.Roll(7, 3);
			_game.RollStrike();
			_game.Roll(9, 1);
			_game.RollStrike();
			_game.Roll(5, 5);
			_game.RollStrike();
			_game.RollLastFrame(8, 2, 10);
			Assert.AreEqual(200, _game.Score());
		}

	}
}
