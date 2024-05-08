using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] spritePrefabs;
    public float spawnRate = 1.0f;
    public int score = 0;

    void Start()
    {
        InvokeRepeating("SpawnSprite", spawnRate, spawnRate);
    }

    void SpawnSprite()
    {
        GameObject spritePrefab = spritePrefabs[Random.Range(0, spritePrefabs.Length)];

        bool spawnFromLeft = Random.value < 0.5f;

        Vector2 spawnPosition = new Vector2(spawnFromLeft ? 0 : Screen.width, Random.Range(0, Screen.height));

        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(spawnPosition);

        GameObject sprite = Instantiate(spritePrefab, worldPosition, Quaternion.identity);

        SpriteController spriteController = sprite.GetComponent<SpriteController>();
        spriteController.direction = spawnFromLeft ? Vector2.right : Vector2.left;
    }

    public void IncreaseScore()
    {
        score++;
    }

    public void EndGame()
    {
        CancelInvoke("SpawnSprite");
        Debug.Log("Game Over");
    }
}
