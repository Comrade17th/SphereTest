using System.Collections.Generic;
using _Project.Scripts.Player;
using UnityEngine;

namespace _Project.Scripts
{
    public class CorridorSection : MonoBehaviour
    {
        [SerializeField] private Transform _leftWall;
        [SerializeField] private Transform _rightWall;

        [SerializeField] private Transform _minBorderLeft;
        [SerializeField] private Transform _minBorderRight;

        [SerializeField] private List<Transform> _spawnPoints;

        [SerializeField] private bool _isRandomWidth;

        public void Init()
        {
            if (_isRandomWidth)
            {
                _leftWall.position = RandomGenerator.GetPositionX(_leftWall,_leftWall, _minBorderLeft);
                _rightWall.position = RandomGenerator.GetPositionX(_rightWall, _minBorderRight, _rightWall);
            }
        }
    }
}