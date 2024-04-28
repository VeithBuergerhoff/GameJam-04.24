using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGameHelper : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
