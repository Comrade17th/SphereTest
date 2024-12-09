using System.Collections.Generic;
using UnityEngine;

namespace _Project.Scripts.Spawners
{
    public class CorridorSection : MonoBehaviour
    {
        [SerializeField] private Transform _leftWall;
        [SerializeField] private Transform _rightWall;

        [SerializeField] private Transform _minBorderLeft;
        [SerializeField] private Transform _minBorderRight;

        [SerializeField] private List<Transform> _spawnPoints;
        [SerializeField] private float _coinSpawnChance = 75;
        [SerializeField] private float _bombSpawnChance = 25;

        [SerializeField] private bool _isRandomWidth;

        private CoinSpawner _coinSpawner;
        private ObstucleSpawner _obstucleSpawner;
        
        public void Init(CoinSpawner coinSpawner, ObstucleSpawner obstucleSpawner)
        {
            _coinSpawner = coinSpawner;
            _obstucleSpawner = obstucleSpawner;
            
            SpawnEntities();
            RandomBorder();
        }

        private void RandomBorder()
        {
            if (_isRandomWidth)
            {
                _leftWall.position = RandomGenerator.GetPositionX(_leftWall,_leftWall, _minBorderLeft);
                _rightWall.position = RandomGenerator.GetPositionX(_rightWall, _minBorderRight, _rightWall);
            }
        }

        private void SpawnEntities()
        {
            foreach (Transform spawnPoint in _spawnPoints)
            {
                if (RandomGenerator.CheckChanceFromHundred(_coinSpawnChance))
                    _coinSpawner.Spawn(spawnPoint.position, spawnPoint);
                else if(RandomGenerator.CheckChanceFromHundred(_bombSpawnChance))
                    _obstucleSpawner.Spawn(spawnPoint.position, spawnPoint);
            }
        }
    }
}