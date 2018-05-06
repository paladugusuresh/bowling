namespace Bowling.Score
{
	public class Spare : Frame
	{
		public Spare(int firstRoll, int secondRoll) : base(firstRoll, secondRoll) { }

		public override void AddBonus(Frame framePlusOne, Frame framePlusTwo)
		{
			_frameScore += framePlusOne.FirstRoll();
		}
	}
}