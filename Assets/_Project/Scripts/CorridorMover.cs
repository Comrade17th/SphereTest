using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Project.Scripts
{
    public class CorridorMover : MonoBehaviour
    {
        [SerializeField] private List<CorridorItem> _items;

        [SerializeField] private float _deadLine = -5;
        [SerializeField] private float _speed;

        private void Update()
        {
            if(_speed <= 0)
                return;

            foreach (CorridorItem item in _items) 
                item.transform.position -= new Vector3(0, _speed * Time.deltaTime, 0);

            DestroyUnderDeadLine();
        }

        private void DestroyUnderDeadLine()
        {
            CorridorItem firstSection = _items[0];

            if (firstSection.transform.position.y <= _deadLine)
            {
                firstSection.Destroy();
                _items.Remove(firstSection);
            }
        }
    }
}