﻿using UnityEngine;

public class ColumnPool : MonoBehaviour
{
    public int columnPoolSize = 5;
    public GameObject columnPrefab;
    public float spawnRate = 1.2f;
    public float columnMin = -1.5f;
    public float columnMax = 2f;

    private GameObject[] columns;
    private Vector2 objectPoolPosition = new Vector2(-15f, -25f);
    private float timeSinceLastSpawned;
    private float spawnXPosition = 10f;
    private int currentColumn = 0;

    void Awake()
    {
        columns = new GameObject[columnPoolSize];
        for (int i = 0; i < columnPoolSize; i++)
        {
            columns[i] = Instantiate(columnPrefab, objectPoolPosition, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameControl.instance.isPaused && GameControl.instance.isPlaying)
        {
            timeSinceLastSpawned += Time.deltaTime;
            if (timeSinceLastSpawned >= spawnRate)
            {
                timeSinceLastSpawned = 0;
                var spawnYPosition = Random.Range(columnMin, columnMax);
                columns[currentColumn].transform.position = new Vector2(spawnXPosition, spawnYPosition);
                currentColumn++;
                if (currentColumn == columnPoolSize)
                {
                    currentColumn = 0;
                }
            }
        }
    }
}
