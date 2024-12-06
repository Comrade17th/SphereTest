using System;
using System.Collections.Generic;
using _Project.Scripts.Player.Wallet;
using Zenject;

namespace _Project.Scripts.EnviromentMover
{
	public class SpeedDifficulty
	{
		private readonly Wallet _wallet;
		private readonly List<CoinsSpeedPair> _coinsSpeed;
		private int _currentCoinsReaching;

		public event Action<float> NewSpeedReaching; 

		[Inject]
		public SpeedDifficulty(Wallet wallet)
		{
			_wallet = wallet;
			_wallet.CoinsChanged += OnCoinsChanged;
			
			_coinsSpeed = new List<CoinsSpeedPair>()
			{
				new CoinsSpeedPair(10, 1.5f),
				new CoinsSpeedPair(25, 2f),
				new CoinsSpeedPair(50, 3f),
				new CoinsSpeedPair(100, 4f)
			};
		}

		private void OnCoinsChanged(int coins)
		{
			if(_currentCoinsReaching >= _coinsSpeed.Count)
				return;

			CoinsSpeedPair currentPair = _coinsSpeed[_currentCoinsReaching];
			
			if (coins == currentPair.Coins)
			{
				NewSpeedReaching?.Invoke(currentPair.Speed);
				_currentCoinsReaching++;
			}
		}
	}
}