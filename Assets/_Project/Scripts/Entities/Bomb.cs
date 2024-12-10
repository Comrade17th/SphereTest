using UnityEngine;

namespace _Project.Scripts.Entities
{
	public class Bomb : MonoBehaviour, IDamager
	{
		public int Damage => 1;
	}
}