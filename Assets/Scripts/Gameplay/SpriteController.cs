using System;
using UnityEngine;
using System.Collections.Generic;

public class SpriteController : MonoBehaviour
{
    public float speed;
    public List<Transform> pointsToFollow;
    private int currentPointIndex = 0;

    // Evento que se dispara cuando el sprite es destruido
    public static event Action<SpriteController> OnSpriteDestroyed = delegate { };

    // Evento que se dispara cuando el sprite es clickeado
    public static event Action<SpriteController> OnSpriteClicked = delegate { };

    // Evento que se dispara cuando se cumple la condición de derrota
    public static event Action OnGameOver = delegate { };

    private bool isClicked = false;

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, pointsToFollow[currentPointIndex].position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, pointsToFollow[currentPointIndex].position) < 0.1f)
        {
            currentPointIndex = (currentPointIndex + 1) % pointsToFollow.Count;
        }
    }

    void OnMouseDown()
    {
        isClicked = true;
        OnSpriteClicked(this);
        ObjectPooling.Instance.DespawnObject(gameObject);
    }

    void OnBecameInvisible()
    {
        if (!isClicked)
        {
            OnGameOver();
        }
        Destroy(gameObject);
    }
}




