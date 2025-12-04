using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour
{
    public void ExitGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MenuStart");
    }
}
