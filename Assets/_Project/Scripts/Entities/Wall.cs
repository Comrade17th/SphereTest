using _Project.Scripts.Entities;
using UnityEngine;

namespace _Project.Scripts
{
	public class Wall : MonoBehaviour, IDamager
	{
		public int Damage => 1;
	}
}