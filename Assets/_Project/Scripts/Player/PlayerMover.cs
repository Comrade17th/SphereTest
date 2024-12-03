using System;
using UnityEngine;

namespace _Project.Scripts.Player
{
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField] private LayerMask inputRaycast;
        [SerializeField] private float _border = 2.5f;
        [SerializeField] private float _speed = 10f;
        
        private Camera _camera;
        
        private void Awake()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            if (Input.GetMouseButton(0)) 
                Move();
        }

        private void Move()
        {
            Vector3 newPosition = GetNewPosition();
            float step = _speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, newPosition, step);
        }

        private Vector3 GetNewPosition()
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out RaycastHit hit, inputRaycast);
            float positionX = Math.Clamp(hit.point.x, -_border, _border);
            
            return new Vector3(positionX, transform.position.y, transform.position.z);;
        }
    }
}