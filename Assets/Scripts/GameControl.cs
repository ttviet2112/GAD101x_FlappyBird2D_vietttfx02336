using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    public static GameControl instance;
    public GameObject gameOverText;
    public float scrollSpeed = -0.5f;
    public Text scoreText;
    public GameObject bird;
    public GameObject tapToStart;
    public AudioClip pingAudioClip;
    public AudioClip deadAudioClip;

    private int score = 0;
    private int highscore;
    public bool GameOver;
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
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!GameOver)
            {
                Time.timeScale = 1;
                bird.SetActive(true);
                tapToStart.SetActive(false);
            }
            else
            {
                SceneManager.LoadScene(1);
            }
            
        }
    }

    public void BirdDied()
    {
        SoundManager.instance.PlaySingle(deadAudioClip);
        gameOverText.SetActive(true);
        Time.timeScale = 0;
        GameOver = true;
        if (score > highscore)
        {
            highscore = score;
        }
        
        PlayerPrefs.SetInt("HIGHSCORE", highscore);
    }

    public void BirdScored()
    {
        if (Time.timeScale == 0)
        {
            return;
        }

        SoundManager.instance.PlaySingle(pingAudioClip);
        score++;
        scoreText.text = $"Score: {score}";
    }
}
