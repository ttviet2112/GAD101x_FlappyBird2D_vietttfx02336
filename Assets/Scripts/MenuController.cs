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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnSwitchBirdClicked()
    {
        if (currentBirdIndex == 0)
        {
            currentBirdIndex = 1;
            birdBlue.SetActive(false);
            birdGreen.SetActive(true);
            birdRed.SetActive(false);
        }
        else if (currentBirdIndex == 1)
        {
            currentBirdIndex = 2;
            birdBlue.SetActive(false);
            birdGreen.SetActive(false);
            birdRed.SetActive(true);
        }
        else 
        {
            currentBirdIndex = 0;
            birdBlue.SetActive(true);
            birdGreen.SetActive(false);
            birdRed.SetActive(false);
        }
    }

    public void StartGame()
    {
        FadeScene.instance.FadeToScene(1);
    }
}
