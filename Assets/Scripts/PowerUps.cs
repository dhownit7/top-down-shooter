using UnityEngine;

public class Powerup : MonoBehaviour
{
    public enum PowerupType { Health, DamageBoost }
    public PowerupType type;
    public int healthAmount = 1;
    public float boostDuration = 5f;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (type == PowerupType.Health)
            {
                PlayerHealth ph = other.GetComponent<PlayerHealth>();
                if (ph != null)
                    ph.Heal(healthAmount);
            }
            else if (type == PowerupType.DamageBoost)
            {
                // We'll implement this next
            }

            Destroy(gameObject);
        }
    }
}