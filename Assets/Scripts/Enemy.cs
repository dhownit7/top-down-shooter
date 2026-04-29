using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 2f;
    public int health = 3;
    public int damage = 1;

    private Transform player;
    private Rigidbody2D rb;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (player != null)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            rb.velocity = direction * moveSpeed;
        }
    }

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;

        // Flash white when hit
        StartCoroutine(FlashWhite());

        if (health <= 0)
        {
            Die();
        }
    }

    IEnumerator FlashWhite()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        Color original = sr.color;
        sr.color = Color.white;
        yield return new WaitForSeconds(0.05f);
        sr.color = original;
    }

    void Die()
    {
        CameraShake.instance.Shake(0.1f, 0.15f);
        Destroy(gameObject);
        if (GameManager.instance != null)
            GameManager.instance.AddScore(10);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth ph = other.GetComponent<PlayerHealth>();
            if (ph != null)
            {
                ph.TakeDamage(damage);
            }
        }

        if (other.CompareTag("Bullet"))
        {
            TakeDamage(1);
            if (other.gameObject != null && other.gameObject.activeInHierarchy)
            {
                ObjectPool.instance.ReturnToPool("Bullet", other.gameObject);
            }
        }
    }
}