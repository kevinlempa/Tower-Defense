using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadFirstScene : MonoBehaviour
{
    public void RestartGame() {
        SceneManager.LoadScene(0);
    }
}
