using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<Transform> spawnPoints;
    public List<Transform> followPoints;
    public float spawnRate = 1.0f;
    private float timer = 0.0f;

    private int clickedSpritesCount = 0;

    void Start()
    {
        SpriteController.OnSpriteClicked += HandleSpriteClicked;
    }

    void OnDestroy()
    {
        //deja de escuchar el evento cuando el GameManager sea destruido
        SpriteController.OnSpriteClicked -= HandleSpriteClicked;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnRate)
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
        spriteController.speed = Random.Range(1f, 5f);

        //puntos a seguir del sprite
        spriteController.pointsToFollow.Clear();
        spriteController.pointsToFollow.Add(followPoints[spawnPointIndex]);
    }

    void HandleSpriteClicked(SpriteController sprite)
    {
        clickedSpritesCount++;
        Debug.Log("Sprites clickeados: " + clickedSpritesCount);
    }
}





