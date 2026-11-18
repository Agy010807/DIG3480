using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public float destroyTime = 3f;
    public int damage = 10;

    public Rigidbody2D rb;

    void Start()
    {
        rb.linearVelocity = transform.up * speed;
        Destroy(gameObject, destroyTime);
    }

    // Detects when the bullet enters another 2D trigger/collider
    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object we hit has the "Enemy" tag
        if (other.CompareTag("Enemy"))
        {
            // Try to get the Enemy script attached to the hit object
            Enemy enemy = other.GetComponent<Enemy>();

            if (enemy != null)
            {
                enemy.enemyHealth -= damage;

                // Optional: Destroy the enemy if health hits 0
                if (enemy.enemyHealth <= 0)
                {
                    Destroy(enemy.gameObject);
                }
            }

            // Destroy the bullet so it doesn't pass through
            Destroy(gameObject);
        }
    }
}
