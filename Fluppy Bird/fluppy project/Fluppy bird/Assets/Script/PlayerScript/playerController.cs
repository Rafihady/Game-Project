using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playerController : MonoBehaviour
{
    [SerializeField] private float jumpforce;
    Rigidbody2D rb;

    public GameObject LoseScrenn;

    [SerializeField] private int Score, HighScore;
    public Text ScoreUI, HighScoreUI;
    string HIGHSCORE = "HIGHSCORE";

    [Header("Pipe Speed Settings")]
    [SerializeField] private float basePipeSpeed = 2f;
    [SerializeField] private int scoreStep = 10;
    [SerializeField] private float speedPerStep = 1f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        Time.timeScale = 1f;
        PipeController.pipeSpeed = basePipeSpeed;

        HighScore = PlayerPrefs.GetInt(HIGHSCORE, 0);

        if (ScoreUI != null)
            ScoreUI.text = "Score = 0";

        if (HighScoreUI != null)
            HighScoreUI.text = "HIGHSCORE = " + HighScore.ToString();

        if (LoseScrenn != null)
            LoseScrenn.SetActive(false);
    }

    private void Update()
    {
        Jump();
    }

    private void Jump()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (SoundManager.singleton != null)
                SoundManager.singleton.Playsound(0);

            rb.velocity = Vector2.up * jumpforce;
        }
    }

    void PlayerLose()
    {
        if (SoundManager.singleton != null)
            SoundManager.singleton.Playsound(1);

        if (Score > HighScore)
        {
            HighScore = Score;
            PlayerPrefs.SetInt(HIGHSCORE, HighScore);
        }

        if (HighScoreUI != null)
            HighScoreUI.text = "HIGHSCORE = " + HighScore.ToString();

        if (LoseScrenn != null)
            LoseScrenn.SetActive(true);

        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        PipeController.pipeSpeed = basePipeSpeed;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitToMenu()
    {
        Time.timeScale = 1f;
        PipeController.pipeSpeed = basePipeSpeed;
        SceneManager.LoadScene("MenuStart");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("obstacle"))
        {
            PlayerLose();
        }
    }

    void Addscore()
    {
        if (SoundManager.singleton != null)
            SoundManager.singleton.Playsound(2);

        Score++;

        if (ScoreUI != null)
            ScoreUI.text = "Score = " + Score.ToString();

        int step = Score / scoreStep;
        PipeController.pipeSpeed = basePipeSpeed + step * speedPerStep;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Score"))
        {
            Addscore();
        }
    }
}
