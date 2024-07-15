using UnityEngine;
using UnityEngine.SceneManagement;

namespace Utils
{
    public class SceneController : MonoBehaviour
    {
        public void LoadScene(int sceneId)
        {
            SceneManager.LoadScene(sceneId);
        }
    }
}
