﻿using UnityEngine;

public class MenuController : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    public void StartGame()
    {
        FadeScene.instance.FadeToScene(1);
    }
}
