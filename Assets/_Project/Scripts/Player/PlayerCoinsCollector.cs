using System;
using JetBrains.Annotations;
using UnityEngine;

namespace _Project.Scripts.Player
{
    [RequireComponent(typeof(Collider))]
    public class PlayerCoinsCollector : MonoBehaviour
    {
        [SerializeField] private Wallet _wallet;

        private void OnTriggerEnter([NotNull] Collider other)
        {
            if (other == null) throw new ArgumentNullException(nameof(other));
            
            if (other.TryGetComponent(out Coin coin))
            {
                _wallet.Collect(coin);
            }
        }
    }
}