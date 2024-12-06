using System;
using System.Threading.Tasks;
using UnityEngine;

namespace _Project.Scripts.Player.Health
{
	public class Health
	{
		private int _godModeMiliseconds = 1000;
		private int _current;
		private bool _isGodMode;
		
		public event Action<int> CurrentChanged;

		public event Action Zero;
		
		public int Max { get; private set; }
		public int Current
		{
			get => _current;
			private set
			{
				if (value != _current)
				{
					_current = value;
					CurrentChanged?.Invoke(Current);
				}
			}
		}

		public Health(int max = 3)
		{
			if (max <= 0)
				throw new ArgumentOutOfRangeException(nameof(max));
			
			Max = max;
			Current = Max;
			
			Debug.Log($"{Current}");
		}

		public async void TakeDamage(int damage = 0)
		{
			if (damage < 0)
				throw new ArgumentOutOfRangeException(nameof(damage));

			if (_isGodMode == false)
			{
				Current -= damage;
				await EnableGodMode();
			}
			
			if(Current <= 0)
				Zero?.Invoke();
		}

		private async Task EnableGodMode()
		{
			_isGodMode = true;	
			await Task.Delay(_godModeMiliseconds);
			_isGodMode = false;
		}
	}
}