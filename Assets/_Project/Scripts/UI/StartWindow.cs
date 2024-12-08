using _Project.Scripts.EnviromentMover;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _Project.Scripts.UI
{
	public class StartWindow : MonoBehaviour
	{
		[SerializeField] private Button _startButton;
		
		private CorridorMover _corridorMover;

		[Inject]
		private void Construct(CorridorMover corridorMover)
		{
			_corridorMover = corridorMover;
			_startButton.onClick.AddListener(OnStartButtonClicked);
		}

		private void OnStartButtonClicked()
		{
			_corridorMover.StartLevel();
			gameObject.SetActive(false);
		}
	}
}