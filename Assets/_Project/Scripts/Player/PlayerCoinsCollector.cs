using System;
using JetBrains.Annotations;
using UnityEngine;

namespace _Project.Scripts.Player
{
    [RequireComponent(typeof(Collider))]
    public class PlayerCoinsCollector : MonoBehaviour
    {
        private Wallet _wallet; // to Construct

        private void Start()
        {
            _wallet = new Wallet();
        }

        private void OnTriggerEnter([NotNull] Collider other)
        {
            if (other == null) throw new ArgumentNullException(nameof(other));
            
            Debug.Log($"smth triggered");
            
            if (other.TryGetComponent(out Coin coin))
            {
                Debug.Log($"coin triggered");
                _wallet.Collect(coin);
            }
        }
    }
}