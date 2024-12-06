using _Project.Scripts;
using _Project.Scripts.EnviromentMover;
using _Project.Scripts.Player;
using _Project.Scripts.Player.Health;
using _Project.Scripts.Player.Wallet;
using _Project.Scripts.Spawners;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace _Project.Common.Infrastructure
{
    public class MainInstaller : MonoInstaller
    {
        [SerializeField] private Transform _startPoint;
        [SerializeField] private GameObject _playerPrefab;
        [SerializeField] private CoinSpawner _coinSpawnerPrefab;
        [SerializeField] private ObstucleSpawner _obstucleSpawnerPrefab;
        
        public override void InstallBindings()
        {
            Container.Bind<CorridorMoverModel>().AsSingle();
            Container.Bind<Wallet>().AsSingle();
            Container.Bind<Health>().AsSingle();
            Container.Bind<SpeedDifficulty>().AsSingle();
            
            Player player = Container
                .InstantiatePrefabForComponent<Player>(_playerPrefab, _startPoint.position, Quaternion.identity, null);
            
            BindCoinSpawner();
            BindObstucleSpawner();
        }

        private void BindObstucleSpawner()
        {
            ObstucleSpawner obstucleSpawner = Container
                .InstantiatePrefabForComponent<ObstucleSpawner>(_obstucleSpawnerPrefab, _startPoint.position, Quaternion.identity, null);
            Container
                .Bind<ObstucleSpawner>()
                .FromInstance(obstucleSpawner)
                .AsSingle();
        }

        private void BindCoinSpawner()
        {
            CoinSpawner coinSpawner = Container
                .InstantiatePrefabForComponent<CoinSpawner>(_coinSpawnerPrefab, _startPoint.position, Quaternion.identity, null);
            Container
                .Bind<CoinSpawner>()
                .FromInstance(coinSpawner)
                .AsSingle();
        }
    }
}