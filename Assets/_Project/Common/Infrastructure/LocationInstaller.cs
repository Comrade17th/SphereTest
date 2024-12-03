using _Project.Scripts.Player;
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
            Wallet wallet = Container
                .InstantiatePrefabForComponent<Wallet>(_playerPrefab, _startPoint.position, Quaternion.identity, null);

            Container
                .Bind<Wallet>()
                .FromInstance(wallet)
                .AsSingle();
        }
    }
}