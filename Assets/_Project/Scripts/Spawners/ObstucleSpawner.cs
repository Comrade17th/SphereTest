using UnityEngine;

namespace _Project.Scripts.Spawners
{
	public class ObstucleSpawner : MonoBehaviour
	{
		[SerializeField] private GameObject prefab;

		public void Spawn(Vector3 at, Transform parent)
		{
			GameObject coin = Instantiate(prefab, at, prefab.transform.rotation, parent);
		}
	}
}