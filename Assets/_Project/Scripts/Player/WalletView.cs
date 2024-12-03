using TMPro;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Player
{
    public class WalletView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _coins;
        
        private Wallet _wallet;

        [Inject]
        public void Construct(Wallet wallet)
        {
            _wallet = wallet;
        }
    }
}