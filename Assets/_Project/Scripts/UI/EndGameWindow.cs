using _Project.Scripts.Player.Health;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

namespace _Project.Scripts.UI
{
	public class EndGameWindow : MonoBehaviour
	{
		[SerializeField] private Button _restartButton;
		
		private Health _health;

		[Inject]
		private void Construct(Health health)
		{
			_health = health;
			_health.Zero += OnHealthZero;
			_restartButton.onClick.AddListener(OnRestart);
		}

		private void OnRestart() =>
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);

		private void OnHealthZero() =>
			gameObject.SetActive(true);
	}
}