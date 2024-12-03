using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Project.Scripts.Player
{
    public class SceneLoader : MonoBehaviour
    {
        private void Start()
        {
            SceneManager.LoadScene(1);
        }
    }
}