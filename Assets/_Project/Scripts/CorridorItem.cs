using System;
using UnityEngine;

namespace _Project.Scripts
{
    public abstract class CorridorItem: MonoBehaviour, ISpawnable<CorridorItem>
    {
        public event Action<CorridorItem> Destroying;

        public void Destroy()
        {
            Debug.Log($"destroyed");
            Destroying?.Invoke(this);
        }
    }
}