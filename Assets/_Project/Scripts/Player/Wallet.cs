using System;
using JetBrains.Annotations;

namespace _Project.Scripts
{
    public class Wallet
    {
        private int _coins;

        public event Action<int> CoinsChanged; 
        
        public int Coins
        {
            get => _coins;
            private set
            {
                if(value != _coins)
                    CoinsChanged?.Invoke(_coins);
            }
        }
        
        public void Collect([NotNull] Coin coin)
        {
            if (coin == null) throw new ArgumentNullException(nameof(coin));
            if (coin.Value <= 0) throw new ArgumentException(nameof(coin.Value));
            
            Coins += coin.Value;
            UnityEngine.Object.Destroy(coin.gameObject);
        }
    }
}