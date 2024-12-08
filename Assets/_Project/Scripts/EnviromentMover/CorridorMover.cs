using System.Collections.Generic;
using System.Threading.Tasks;
using _Project.Scripts.Entities;
using _Project.Scripts.Player.Health;
using _Project.Scripts.Spawners;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.EnviromentMover
{
    public class CorridorMover : MonoBehaviour
    {
        [SerializeField] private CorridorSectionSpawner _spawner;
        [SerializeField] private float _speed = 0;
        
        private List<CorridorSection> _sections = new ();
        private Health _health;
        private SpeedDifficulty _speedDifficulty;
        private CorridorMoverModel _model;
        
        private float DeadLineY => _model.DeadLineY;
        private float BaseSpeed => _model.BaseSpeed;
        private float SectionOffset => _model.SectionOffset;
        private float StartSectionsCount => _model.StartSectionsCount;

        [Inject]
        private void Constuct(CorridorMoverModel model ,SpeedDifficulty speedDifficulty, Health health)
        {
            _model = model;
            _speedDifficulty = speedDifficulty;
            _health = health;

            _speedDifficulty.NewSpeedReaching += NewSpeedReachingHandler;
            _health.Zero += OnHealthZero;
        }

        private void OnHealthZero()
        {
            _speed = 0;
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
            RaiseSpeed(1);
        }

        public void ResetLevel()
        {
            _speed = 0;
            
            while (_sections.Count > 0)
            {
                Destroy(_sections[0].gameObject);
                _sections.RemoveAt(0);
            }

            for (int i = 0; i < StartSectionsCount; i++)
            {
                _sections.Add(_spawner.Spawn(GetSpawnPosition()));
            }
        }

        private void NewSpeedReachingHandler(float speedMultiplyer)
        {
            RaiseSpeed(speedMultiplyer);
        }
        
        private async Task RaiseSpeed(float speedMultiplyer)
        {
            int millisecondsInSecond = 1000;
            int steps = 10;
            float seconds = 2f;
            
            float delta = speedMultiplyer * BaseSpeed - _speed;
            float speedStep = delta / steps;
            int milisecondStep = (int) (seconds * millisecondsInSecond) / steps; 

            for (int i = 0; i < steps; i++)
            {
                _speed += speedStep;
                await Task.Delay(milisecondStep);
            }
        }

        private void DestroyUnderDeadLine()
        {
            if(_sections.Count == 0)
                return;
            
            CorridorSection firstSection = _sections[0];

            if (firstSection.transform.position.y <= DeadLineY)
            {
                _sections.RemoveAt(0);
                Destroy(firstSection.gameObject);
                _sections.Add(_spawner.Spawn(GetSpawnPosition()));
            }
        }

        private Vector3 GetSpawnPosition()
        {
            if (_sections.Count > 0)
                return _sections[_sections.Count - 1].transform.position + new Vector3(0, SectionOffset, 0);
            else
                return Vector3.zero;
        }
    }
}