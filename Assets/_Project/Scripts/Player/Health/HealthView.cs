using TMPro;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Player.Health
{
	public class HealthView : MonoBehaviour
	{
		[SerializeField] private TextMeshProUGUI _field;
        
		private Health _health;

		private void OnEnable()
		{
			if (_health != null)
				_health.CurrentChanged += Write;
		}

		private void OnDisable()
		{
			if (_health != null)
				_health.CurrentChanged -= Write;
		}

		[Inject]
		private void Construct(Health health)
		{
			_health = health;
			Write(health.Current);
			_health.CurrentChanged += Write;
		}

		private void Write(int amount) =>
			_field.text = $"Health: {amount}";
	}
}