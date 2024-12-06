using System;
using UnityEngine;

namespace _Project.Scripts.Entities
{
    [Serializable]
    public class Coin : MonoBehaviour
    {
        [field: SerializeField] public int Value { get; private set; }
    }
}