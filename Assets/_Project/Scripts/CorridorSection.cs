using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

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

    public static class RandomGenerator
    {
        public static Vector3 GetPositionX(Transform original, Transform minInclusive, Transform maxInclusive)
        {
            float randomX = Random.Range(minInclusive.position.x, maxInclusive.position.x);
            return new Vector3(randomX, original.position.y, original.position.z);
        }
    }
}