using UnityEngine;
using UnityEngine.SceneManagement;

public class MemuManager : MonoBehaviour
{
    void Start()
    {
        Time.timeScale = 1f;
    }

    public void StartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("SampleScene");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("exit");
    }
}
