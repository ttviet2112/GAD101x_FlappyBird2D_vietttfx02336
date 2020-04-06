using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeScene : MonoBehaviour
{
    public static FadeScene instance = null;
    public Animator animator;

    private int sceneIndexNeedToLoad;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FadeToScene(int sceneIndex)
    {
        sceneIndexNeedToLoad = sceneIndex;
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeOutComplete()
    {
        SceneManager.LoadScene(sceneIndexNeedToLoad);
    }
}
