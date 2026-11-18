using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int enemyHealth = 10;
    private bool isDying = false;

    void Update()
    {
        Death();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Sword"))
        {
            enemyHealth -= 10;
        }
    }

    void Death()
    {
        if (enemyHealth <= 0 && !isDying)
        {
            StartCoroutine(DeathRoutine());
        }
    }

    IEnumerator DeathRoutine()
    {
        isDying = true;

        GetComponent<SpriteRenderer>().color = Color.black;

        yield return new WaitForSeconds(1f);

        Destroy(gameObject);
    }
}
