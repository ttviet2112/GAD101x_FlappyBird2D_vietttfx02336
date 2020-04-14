using UnityEngine;

public class Bird : MonoBehaviour
{
    public float upForce = 200f;
    public AudioClip flyAudioClip;

    private bool isDead = false;
    private Rigidbody2D rb2d;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead && GameControl.instance.isPlaying && !GameControl.instance.isPaused)
        {
            if (Input.GetMouseButtonDown(0))
            {
                rb2d.velocity = Vector2.zero;
                rb2d.AddForce(new Vector2(0, upForce));
                anim.SetTrigger("Flap");
                SoundManager.instance.PlaySingle(flyAudioClip);
            }
        }
    }

    void OnCollisionEnter2D()
    {
        if (!isDead && GameControl.instance.isPlaying)
        {
            rb2d.velocity = Vector2.zero;
            isDead = true;
            anim.SetTrigger("Die");
            GameControl.instance.BirdDied(); 
        }
    }
}
