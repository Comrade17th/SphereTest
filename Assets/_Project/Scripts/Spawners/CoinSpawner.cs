using UnityEngine;

namespace _Project.Scripts.Spawners
{
	public class CoinSpawner : MonoBehaviour
	{
		[SerializeField] private GameObject prefab;

		public void Spawn(Vector3 at, Transform parent)
		{
			GameObject coin = Instantiate(prefab, at, Quaternion.identity, parent);
		}
	}
}