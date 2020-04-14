using System;
using UnityEngine;
using UnityEngine.UI;

public class Medal : MonoBehaviour
{
    private Animator animator;
    public Text scoreText;
    public Text highScoreText;

    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
        string medal = GetMedalName(PlayerPrefs.GetInt("HIGHSCORE"));
        Debug.Log(medal);
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName(medal))
        {
            Debug.Log(animator.GetCurrentAnimatorStateInfo(0).shortNameHash);
            animator.SetTrigger(medal);
        }
        scoreText.text = PlayerPrefs.GetInt("SCORE").ToString();
        highScoreText.text = PlayerPrefs.GetInt("HIGHSCORE").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private string GetMedalName(int highscore)
    {
        if (highscore <= 20)
        {
            return "White";
        }
        else if (highscore > 20 && highscore <= 40)
        {
            return "Brozen";
        }

        return "Gold";
    }
}
