using System;
using System.Collections.Generic;

namespace Bowling.Score
{
	public class BowlingGame
	{
		private readonly List<Frame> _frames = new List<Frame>();

		public int Score()
		{
			Add(new Open(0, 0));
			Add(new Open(0, 0));

			for (int i = 0; i < 10; i++)
				_frames[i].AddBonus(_frames[i + 1], _frames[i + 2]);

			int counter = 0;
			_frames.ForEach( frame => counter += frame.Score());
			return counter;
		}

		public void Roll(int firstRoll, int secondRoll)
		{
			if (GameFinished()) 
				throw new GameOverException();

			Add(Frame.Create(firstRoll, secondRoll));
		}

		public void RollStrike()
		{
			Roll(10, 0);
		}

		private bool GameFinished()
		{
			return _frames.Count.Equals(10);
		}

		private void Add(Frame frame)
		{
			_frames.Add(frame);
		}

		public void RollLastFrame(int firstRoll, int secondRoll, int thirdRoll)
		{
			Add(Frame.Create(firstRoll,secondRoll,thirdRoll));
		}
	}
}
