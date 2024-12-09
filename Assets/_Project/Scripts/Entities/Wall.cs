using _Project.Scripts.Entities;
using UnityEngine;

namespace _Project.Scripts
{
	public class Wall : MonoBehaviour, IDamager
	{
		[field: SerializeField] public int Damage { get; private set; } = 1;
	}
}