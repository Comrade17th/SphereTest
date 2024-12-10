using TMPro;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Player.Wallet
{
    public class WalletView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _coins;
        
        private Wallet _wallet;

        private void OnEnable()
        {
            if (_wallet != null)
                _wallet.CoinsChanged += Write;
        }

        private void OnDisable()
        {
            if (_wallet != null)
                _wallet.CoinsChanged -= Write;
        }

        [Inject]
        private void Construct(Wallet wallet)
        {
            _wallet = wallet;
            _wallet.CoinsChanged += Write;
        }

        private void Write(int amount) =>
            _coins.text = $"Coins: {amount}";
    }
}