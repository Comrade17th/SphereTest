﻿using _Project.Scripts.Player;
using UnityEngine;
using Zenject;

namespace _Project.Common.Infrastructure
{
    public class LocationInstaller : MonoInstaller
    {
        [SerializeField] private Transform _startPoint;
        [SerializeField] private GameObject _playerPrefab;
        
        public override void InstallBindings()
        {
            Container.Bind<Wallet>().AsSingle();
            
            Player player = Container
                .InstantiatePrefabForComponent<Player>(_playerPrefab, _startPoint.position, Quaternion.identity, null);
            
            // Container
            //     .Bind<Wallet>()
            //     .FromInstance(wallet)
            //     .AsSingle();
        }
    }
}