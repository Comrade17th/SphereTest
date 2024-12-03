﻿using System;
using TMPro;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Player
{
    public class WalletView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _coins;
        
        [SerializeField] private Wallet _wallet;

        private void OnEnable()
        {
            if (_wallet)
                _wallet.CoinsChanged += Write;
        }

        private void OnDisable() => 
            _wallet.CoinsChanged -= Write;

        [Inject]
        private void Construct(Wallet wallet)
        {
            _wallet = wallet;
            _wallet.CoinsChanged += Write;
        }

        private void Write(int amount)
        {
            _coins.text = $"Coins: {amount}";
        }
    }
}