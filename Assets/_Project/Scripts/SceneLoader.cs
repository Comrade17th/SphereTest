using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Project.Scripts
{
    public class SceneLoader : MonoBehaviour
    {
        private void Start() =>
            SceneManager.LoadScene(1);
    }
}