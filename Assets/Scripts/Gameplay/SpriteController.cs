using UnityEngine;

public class SpriteController : MonoBehaviour
{
    public float speed = 1.0f;
    public Vector2 direction;

    void Start()
    {
        direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    void OnMouseDown()
    {
        FindObjectOfType<GameManager>().IncreaseScore();

        Destroy(gameObject);
    }

    void OnBecameInvisible()
    {
        FindObjectOfType<GameManager>().EndGame();

        Destroy(gameObject);
    }
}
