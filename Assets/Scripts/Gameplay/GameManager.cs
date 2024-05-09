using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public List<Transform> spawnPoints;
    public List<Transform> followPoints;
    public TextMeshProUGUI scoreText;
    public float spawnRate = 1.0f;
    private float timer = 0.0f;

    public Menu menuScript;

    private int clickedSpritesCount = 0;

    private float gameTime = 0.0f; // Tiempo de juego

    void Start()
    {
        SpriteController.OnSpriteClicked += HandleSpriteClicked;
        SpriteController.OnGameOver += HandleGameOver;
    }

    void OnDestroy()
    {
        //deja de escuchar el evento cuando el GameManager sea destruido
        SpriteController.OnSpriteClicked -= HandleSpriteClicked;
        SpriteController.OnGameOver -= HandleGameOver;
    }

    void Update()
    {
        gameTime += Time.deltaTime;
        timer += Time.deltaTime;
        if (timer >= 1.0f / (1.0f + gameTime * 0.1f)) //la tasa de aparición aumenta con el tiempo de juego
        {
            SpawnSprite();
            timer = 0.0f;
        }
    }

    void SpawnSprite()
    {
        GameObject sprite = ObjectPooling.Instance.RequestObject();

        //establece la posición inicial del sprite en un punto de generación específico
        int spawnPointIndex = Random.Range(0, spawnPoints.Count);
        sprite.transform.position = spawnPoints[spawnPointIndex].position;

        //velocidad del sprite
        SpriteController spriteController = sprite.GetComponent<SpriteController>();
        spriteController.speed = Random.Range(1f, 5f) + gameTime * 0.05f; //aumenta en 0.1 por segundo

        //puntos a seguir del sprite
        spriteController.pointsToFollow.Clear();
        spriteController.pointsToFollow.Add(followPoints[spawnPointIndex]);
    }

    void HandleSpriteClicked(SpriteController sprite)
    {
        clickedSpritesCount++;
        scoreText.text = "" + clickedSpritesCount;
    }

    void HandleGameOver()
    {
        // Muestra el mensaje de "Game Over"
        Debug.Log("Gameover chabito");
        menuScript.showDeathScreen();
    }
}





