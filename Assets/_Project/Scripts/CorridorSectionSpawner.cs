using UnityEngine;

namespace _Project.Scripts
{
	public class CorridorSectionSpawner : MonoBehaviour
	{
		[SerializeField] private GameObject _sectionPrefab; // to asset path
		// add assets service
		
		public CorridorSection Spawn(Vector3 at)
		{
			GameObject section = Instantiate(_sectionPrefab, at, Quaternion.identity);
			return section.GetComponent<CorridorSection>();
		}
	}
}