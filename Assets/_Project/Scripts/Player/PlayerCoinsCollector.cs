using System;
using _Project.Scripts.Entities;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Player
{
    [RequireComponent(typeof(Collider))]
    public class PlayerCoinsCollector : MonoBehaviour
    {
        private Wallet.Wallet _wallet;
        
        [Inject]
        private void Construct(Wallet.Wallet wallet)
        {
            _wallet = wallet;
        }
        
        private void OnTriggerEnter( Collider other)
        {
            if (other == null) throw new ArgumentNullException(nameof(other));
            
            if (other.TryGetComponent(out Coin coin))
            {
                _wallet.Collect(coin);
            }
        }
    }
}