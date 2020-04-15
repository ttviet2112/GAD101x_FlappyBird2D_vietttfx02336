using UnityEngine;

public class MenuController : MonoBehaviour
{
    public static int currentBirdIndex;
    public GameObject birdBlue;
    public GameObject birdGreen;
    public GameObject birdRed;

    // Start is called before the first frame update
    void Start()
    {
        if (currentBirdIndex == 0)
            birdBlue.SetActive(true);
        else if (currentBirdIndex == 1)
            birdGreen.SetActive(true);
        else
            birdRed.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnSwitchBirdClicked()
    {
        birdBlue.SetActive(false);
        birdRed.SetActive(false);
        birdGreen.SetActive(false);
        if (currentBirdIndex == 0)
        {
            currentBirdIndex = 1;
            birdGreen.SetActive(true);
        }
        else if (currentBirdIndex == 1)
        {
            currentBirdIndex = 2;
            birdRed.SetActive(true);
        }
        else 
        {
            currentBirdIndex = 0;
            birdBlue.SetActive(true);
        }
    }

    public void StartGame()
    {
        FadeScene.instance.FadeToScene(1);
    }
}