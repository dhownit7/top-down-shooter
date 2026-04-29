using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public float lifetime = 2f;
    private float spawnTime;

    void OnEnable()
    {
        spawnTime = Time.time;
    }

    void Update()
    {
        if (!gameObject.activeInHierarchy) return;

        transform.Translate(Vector2.up * speed * Time.deltaTime);

        if (Time.time >= spawnTime + lifetime)
        {
            ReturnToPool();
        }
    }

    void ReturnToPool()
    {
        if (gameObject.activeInHierarchy)
        {
            ObjectPool.instance.ReturnToPool("Bullet", gameObject);
        }
    }
}