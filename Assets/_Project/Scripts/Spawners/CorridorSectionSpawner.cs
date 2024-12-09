using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Spawners
{
	public class CorridorSectionSpawner : MonoBehaviour
	{
		[SerializeField] private List<GameObject> _sectionsPrefabs;
		
		private CoinSpawner _coinSpawner;
		private ObstucleSpawner _obstucleSpawner;

		[Inject]
		public void Construct(CoinSpawner coinSpawner, ObstucleSpawner obstucleSpawner)
		{
			_coinSpawner = coinSpawner;
			_obstucleSpawner = obstucleSpawner;
		}

		public CorridorSection Spawn(Vector3 at)
		{
			GameObject sectionPrefab = _sectionsPrefabs[Random.Range(0, _sectionsPrefabs.Count - 1)];
			GameObject section = Instantiate(sectionPrefab, at, sectionPrefab.transform.rotation);
			var corridorSection = section.GetComponent<CorridorSection>();
			
			corridorSection.Init(_coinSpawner, _obstucleSpawner);
			return corridorSection;
		}
	}
}