using System;
using UnityEngine;
using System.Collections.Generic;

public class SpriteController : MonoBehaviour
{
    public float speed;
    public List<Transform> pointsToFollow;
    private int currentPointIndex = 0;

    public static event Action<SpriteController> OnSpriteDestroyed = delegate { };

    public static event Action<SpriteController> OnSpriteClicked = delegate { };

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
        OnSpriteClicked(this);
        ObjectPooling.Instance.DespawnObject(gameObject);
    }

    void OnBecameInvisible()
    {
        OnSpriteDestroyed(this);
        ObjectPooling.Instance.DespawnObject(gameObject);
    }
}



