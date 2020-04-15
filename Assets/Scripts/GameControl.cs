using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    public static GameControl instance;
    public GameObject gameOverPanel;
    public float scrollSpeed = -3.5f;
    public Text scoreText;
    public GameObject bird;
    public Button pauseButton;
    public Button tapToStartButon;
    public AudioClip pingAudioClip;
    public AudioClip deadAudioClip;
    public bool isPlaying;
    public bool isPaused;
    public GameObject whiteMedal;
    public GameObject brozenMedal;
    public GameObject goldMedal;
    public Text scoreGameOverText;
    public Text highscoreText;

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
    }

    public void BirdDied()
    {
        SoundManager.instance.PlaySingle(deadAudioClip);
        ShowGameOverPanel();
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
    }

    public void OnPauseButtonClicked()
    {
        ShowGameOverPanel();
        isPaused = true;
        Time.timeScale = 0;
    }

    public void OnPlayButtonClicked()
    {
        Time.timeScale = 1;
        if (isPaused)
        {
            gameOverPanel.SetActive(false);
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

    private void ShowGameOverPanel()
    {
        scoreGameOverText.text = score.ToString();
        highscoreText.text = highscore.ToString();

        whiteMedal.SetActive(false);
        brozenMedal.SetActive(false);
        goldMedal.SetActive(false);

        if (highscore <= 20)
        {
            whiteMedal.SetActive(true);
        }
        else if (highscore > 20 && highscore < 40)
        {
            brozenMedal.SetActive(true);
        }

        goldMedal.SetActive(true);

        gameOverPanel.SetActive(true);
        pauseButton.gameObject.SetActive(false);
        scoreText.text = string.Empty;
    }
}
