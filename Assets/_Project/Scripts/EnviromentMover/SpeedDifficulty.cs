using System;
using System.Collections.Generic;
using _Project.Scripts.Player.Wallet;
using Zenject;

namespace _Project.Scripts.EnviromentMover
{
	public class SpeedDifficulty
	{
		private readonly Wallet _wallet;
		private readonly Dictionary<int, float> _difficulties;
		private Dictionary<int, float>.Enumerator _difficultiesEnumerator;

		private int _currentCoinsReaching;

		public event Action<float> NewSpeedReaching; 

		[Inject]
		public SpeedDifficulty(Wallet wallet)
		{
			_wallet = wallet;
			_wallet.CoinsChanged += OnCoinsChanged;

			_difficulties = new Dictionary<int, float>()
			{
				{10, 1.5f},
				{25, 2f},
				{50, 3f},
				{100, 4f},
			};

			_difficultiesEnumerator = _difficulties.GetEnumerator();
			_difficultiesEnumerator.MoveNext();
		}

		private void OnCoinsChanged(int coins)
		{
			KeyValuePair<int, float> currentPair = _difficultiesEnumerator.Current;
			
			if (coins == currentPair.Key)
			{
				NewSpeedReaching?.Invoke(currentPair.Value);
				_difficultiesEnumerator.MoveNext();
			}
		}
	}
}