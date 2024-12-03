using System;
using JetBrains.Annotations;
using UnityEngine;

namespace _Project.Scripts.Player
{
    public class Wallet : MonoBehaviour
    {
        private int _coins;

        public event Action<int> CoinsChanged; 
        
        public int Coins
        {
            get => _coins;
            private set
            {
                if (value != _coins)
                {
                    _coins = value;
                    CoinsChanged?.Invoke(_coins);
                }
            }
        }
        
        public void Collect([NotNull] Coin coin)
        {
            if (coin == null) throw new ArgumentNullException(nameof(coin));
            if (coin.Value <= 0) throw new ArgumentException(nameof(coin.Value));
            
            Coins += coin.Value;
            Destroy(coin.gameObject);
        }
    }
}