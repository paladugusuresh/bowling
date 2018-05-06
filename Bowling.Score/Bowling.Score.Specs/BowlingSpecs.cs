
using Bowling.Score;
using Bowling.Score.Specs.Infrastructure;



namespace specs_for_bowling
{
	// when rolling all gutter balls, the score is 0.
	public class when_rolling_all_gutter_balls : concerns 
	{
		private BowlingGame _game;

		protected override void context()
		{
			_game = new BowlingGame();
			for (int i = 0; i < 10; i++) { _game.Roll(0,0); }
		}

		[Specification]
		public void scores_zero()
		{
			_game.Score().should_equal(0);
		}
	}

	// when rolling all 1s, the score is 20.
	public class when_rolling_all_ones : concerns
	{
		private BowlingGame _game;

		protected override void context()
		{
			_game = new BowlingGame();
			for (int i = 0; i < 10; i++) { _game.Roll(1,1); }
		}

		[Specification]
		public void scores_twenty()
		{
			_game.Score().should_equal(20);
		}
	}

	// when the first frame is a spare and each subsequent roll score 2, the score is 48.
	public class when_first_frame_spare_rest_rolling_all_twos : concerns
	{
		private BowlingGame _game;

		protected override void context()
		{
			_game = new BowlingGame();
			_game.Roll(9,1);

			for (int i = 0; i < 9; i++) { _game.Roll(2,2); }
		}

		[Specification]
		public void scores_forty_eight()
		{
			_game.Score().should_equal(48);
		}
	}

	// when the first 2 frames are spares with [5,5] and subsequent rolls score 2, the score is 59.
	public class when_first_two_frames_are_spare_rest_rolling_all_twos : concerns
	{
		private BowlingGame _game;

		protected override void context()
		{
			_game = new BowlingGame();
			_game.Roll(5,5);
			_game.Roll(5,5);

			for (int i = 0; i < 8; i++) { _game.Roll(2,2); }
		}

		[Specification]
		public void scores_fifty_nine()
		{
			_game.Score().should_equal(59);
		}
	}

	// when 10 frames have been bowled, don't allow any more to be bowled.
	public class when_ten_frames_have_been_played : concerns
	{
		private BowlingGame _game;

		protected override void context()
		{
			_game = new BowlingGame();
			for (int i = 0; i < 10; i++) { _game.Roll(0,0); }
		}

		[Specification]
		public void the_game_is_over()
		{
			typeof (GameOverException).should_be_thrown_by(() => _game.Roll(0, 0));
		}
	}

	// when the first frame is a strike and subsequent rolls score 2, the score is 50.
	public class when_first_frame_strike_rest_roll_all_twos : concerns
	{
		private BowlingGame _game;

		protected override void context()
		{
			_game = new BowlingGame();
			_game.RollStrike();
			for (int i = 0; i < 9; i++) { _game.Roll(2,2); }
		}

		[Specification]
		public void scores_fifty()
		{
			_game.Score().should_equal(50);
		}
	}

	// when the first 2 frames are strikes and the rest score 2, the score is 68.
	public class when_first_2_frames_strikes_rest_roll_all_twos : concerns
	{
		private BowlingGame _game;

		protected override void context()
		{
			_game = new BowlingGame();
			_game.RollStrike();
			_game.RollStrike();
			for (int i = 0; i < 8; i++) { _game.Roll(2, 2); }
		}

		[Specification]
		public void scores_sixty_eight()
		{
			_game.Score().should_equal(68);
		}
	}

	// when rolling a perfect game, the score is 300.
	public class when_rolling_a_perfect_game : concerns
	{
		private BowlingGame _game;

		protected override void context()
		{
			_game = new BowlingGame();
			for (int i = 0; i < 9; i++) _game.RollStrike();
			_game.RollLastFrame(10,10,10);
		}

		[Specification]
		public void scores_three_hundred()
		{
			_game.Score().should_equal(300);
		}
	}

	// when rolling alternate strikes and spares, the score is 200.
	public class when_rolling_alternate_strikes_and_spares : concerns
	{
		private BowlingGame _game;
	
		protected override void context()
		{
			_game = new BowlingGame();
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
		}

		[Specification]
		public void scores_two_hundred()
		{
			_game.Score().should_equal(200);			
		}
	}
}
