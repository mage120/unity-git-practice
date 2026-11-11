using UnityEngine;

public class Player : MonoBehaviour
{
    public float health = 100.0f;

    private void TakeDamage(int value)
    {
        health -= value;
        if (health <= 0f)
        {
            Die();
        }
        Debug.Log("Player Health : " + health);
    }
    private void Die()
    {
        //EventManager.RungEnemyDieEvent();
        Destroy(this.gameObject);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        TakeDamage(20);
        Destroy(collision.gameObject);
    }
}
