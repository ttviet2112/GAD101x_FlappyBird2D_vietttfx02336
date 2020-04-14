using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    public static GameControl instance;
    public GameObject gameOverText;
    public GameObject gameOverPanel;
    public float scrollSpeed = -3.5f;
    public Text scoreText;
    public GameObject bird;
    public Button pauseButton;
    public Button playButton;
    public Button mainMenuButton;
    public Button tapToStartButon;
    public AudioClip pingAudioClip;
    public AudioClip deadAudioClip;
    public bool isPlaying;
    public bool isPaused;

    private int score = 0;
    private int highscore;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        highscore = PlayerPrefs.GetInt("HIGHSCORE");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnStartGame()
    {
        isPlaying = true;
        pauseButton.gameObject.SetActive(true);
        bird.SetActive(true);
        tapToStartButon.gameObject.SetActive(false);
        PlayerPrefs.SetInt("SCORE", score);
    }

    public void BirdDied()
    {
        SoundManager.instance.PlaySingle(deadAudioClip);        
        
        scoreText.text = string.Empty;
        gameOverText.SetActive(true);
        gameOverPanel.SetActive(true);
        mainMenuButton.gameObject.SetActive(true);
        playButton.gameObject.SetActive(true);
        pauseButton.gameObject.SetActive(false);
        isPlaying = false;
    }

    public void BirdScored()
    {
        if (isPaused || !isPlaying)
        {
            return;
        }

        SoundManager.instance.PlaySingle(pingAudioClip);
        score++;
        scoreText.text = $"Score: {score}";
        if (score > highscore)
        {
            highscore = score;
            PlayerPrefs.SetInt("HIGHSCORE", highscore);
        }
        
        PlayerPrefs.SetInt("SCORE", score);
    }

    public void OnPauseButtonClicked()
    {
        gameOverPanel.SetActive(true);
        mainMenuButton.gameObject.SetActive(true);
        playButton.gameObject.SetActive(true);
        pauseButton.gameObject.SetActive(false);
        scoreText.text = string.Empty;
        isPaused = true;
        Time.timeScale = 0;
    }

    public void OnPlayButtonClicked()
    {
        Time.timeScale = 1;
        if (isPaused)
        {
            gameOverPanel.SetActive(false);
            mainMenuButton.gameObject.SetActive(false);
            playButton.gameObject.SetActive(false);
            pauseButton.gameObject.SetActive(true);
            scoreText.text = $"Score: {score}";
            isPaused = false;
        }
        else
        {
            FadeScene.instance.FadeToScene(1);
        }        
    }

    public void OnMainMenuButtonClicked()
    {
        Time.timeScale = 1;
        FadeScene.instance.FadeToScene(0);
    }
}
