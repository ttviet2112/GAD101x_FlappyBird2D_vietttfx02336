﻿using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        
            rb2d.velocity = new Vector2(GameControl.instance.scrollSpeed, 0);
        
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (GameControl.instance.GameOver)
        //{
        //    rb2d.velocity = Vector2.zero;
        //}
    }
}
