using System.Collections.Generic;
using UnityEngine;

namespace _Project.Scripts
{
	public class CorridorSectionSpawner : MonoBehaviour
	{
		[SerializeField] private List<GameObject> _sectionsPrefabs;
		
		public CorridorSection Spawn(Vector3 at)
		{
			GameObject sectionPrefab = _sectionsPrefabs[Random.Range(0, _sectionsPrefabs.Count - 1)];
			GameObject section = Instantiate(sectionPrefab, at, Quaternion.identity);
			var corridorSection = section.GetComponent<CorridorSection>();
			corridorSection.Init();
			return corridorSection;
		}
	}
}