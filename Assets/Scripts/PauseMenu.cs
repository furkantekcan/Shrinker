using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject gamePlayUI;
    private TextMeshProUGUI scoreText;
    private int score = 0;

    // Update is called once per frame
    private void Start() 
    {
        scoreText = gamePlayUI.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Key down!");
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

        scoreText.text = score.ToString();

    }

    public void Replay()
    {
        pauseMenuUI.SetActive(false);
        gamePlayUI.SetActive(true);
        Time.timeScale = 1f;
        GameIsPaused = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        gamePlayUI.SetActive(true);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        gamePlayUI.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void QuitGame()
    {
        Debug.Log("Quiting game!");
        Application.Quit();
    }

    private void SetScore()
    {
        score += 1;
    }

    private void OnEnable() {
        Player.onScoreChanged += SetScore;
    }
    private void OnDisable() {
        Player.onScoreChanged -= SetScore;
    }
}
