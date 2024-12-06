using System;
using _Project.Scripts.Entities;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Player
{
    [RequireComponent(
        typeof(Collider),
        typeof(Rigidbody))]
    public class Player : MonoBehaviour
    {
        private Health.Health _health;
        
        [Inject]
        private void Construct(Health.Health health)
        {
            _health = health;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IDamager damager))
            {
                _health.TakeDamage(damager.Damage);
                Destroy(other.gameObject);
            }
                
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.TryGetComponent(out IDamager damager))
                _health.TakeDamage(damager.Damage);
        }
    }
}