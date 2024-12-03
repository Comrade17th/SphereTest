using System;
using UnityEngine;

namespace _Project.Scripts
{
    [Serializable]
    public class Coin : MonoBehaviour
    {
        [field: SerializeField] public int Value { get; private set; }
    }
}