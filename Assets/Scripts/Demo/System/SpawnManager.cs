using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] public List<GameObject> enemies;

    Vector3 leftEdge, rightEdge;
    bool isGameOver;
    float lastSpawnTime, spawnTime = 0.5f;

    void Start()
    {
        lastSpawnTime = 0f;
        isGameOver = false;
        Camera cam = Camera.main;
        rightEdge = Camera.main.ScreenToWorldPoint(new Vector3(cam.pixelWidth, cam.pixelHeight, cam.nearClipPlane));
        leftEdge = Camera.main.ScreenToWorldPoint(new Vector3(0f, cam.pixelHeight, cam.nearClipPlane));

        rightEdge.y = leftEdge.y = 0f;
        // so that spawned object are out of screen at first
        rightEdge.z = leftEdge.z = rightEdge.z + 25f;

        Events.gameOverEvent += OnGameOver;
    }

    void OnGameOver()
    {
        isGameOver = true;
    }

    void Update()
    {
        while(!isGameOver && Time.time - lastSpawnTime >= spawnTime)
        {
            float randX = Random.Range(leftEdge.x + 15, rightEdge.x - 15);
            Vector3 pos = new Vector3(randX, 0f, rightEdge.z);
            Instantiate(enemies[Random.Range(0, enemies.Count - 1)], pos, Quaternion.identity);
            lastSpawnTime = Time.time;
        }
    }
}
