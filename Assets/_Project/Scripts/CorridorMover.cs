using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace _Project.Scripts
{
    public class CorridorMover : MonoBehaviour
    {
        [SerializeField] private List<CorridorSection> _sections; // remove serialize
        [SerializeField] private CorridorSectionSpawner _spawner; // to construct
        
        [SerializeField] private float _deadLineY = -5; // TO SD
        [SerializeField] private float _targetSpeed = 1;
        [SerializeField] private float _speed = 0; //to SD
        [SerializeField] private float _sectionOffset;// to SD
        [SerializeField] private float _startSectionsCount = 15;

        private void Start()
        {
            StartLevel();
        }

        private void Update()
        {
            if(_speed <= 0)
                return;

            foreach (CorridorSection item in _sections) 
                item.transform.position -= new Vector3(0, _speed * Time.deltaTime, 0);

            DestroyUnderDeadLine();
        }

        public void StartLevel()
        {
            ResetLevel();
            _speed = _targetSpeed; // to async raise
        }

        public void ResetLevel()
        {
            _speed = 0;
            while (_sections.Count > 0)
            {
                Destroy(_sections[0].gameObject);
                _sections.RemoveAt(0);
            }

            for (int i = 0; i < _startSectionsCount; i++)
            {
                _sections.Add(_spawner.Spawn(GetSpawnPosition()));
            }
        }

        private void DestroyUnderDeadLine()
        {
            if(_sections.Count == 0)
                return;
            
            CorridorSection firstSection = _sections[0];

            if (firstSection.transform.position.y <= _deadLineY)
            {
                _sections.RemoveAt(0);
                Destroy(firstSection.gameObject);
                _sections.Add(_spawner.Spawn(GetSpawnPosition()));
            }
        }

        private Vector3 GetSpawnPosition()
        {
            if (_sections.Count > 0)
                return _sections[_sections.Count - 1].transform.position + new Vector3(0, _sectionOffset, 0);
            else
                return Vector3.zero;
        }
    }
}