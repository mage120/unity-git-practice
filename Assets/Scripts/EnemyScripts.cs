using Unity.VisualScripting;
using UnityEngine;

public class EnemyScripts : MonoBehaviour
{
    public float health = 50.0f;
    
    private void TakeDamage(int value)
    {
        health -= value;
        if (health <= 0f)
        {
            Die();
        }
        Debug.Log("Enemy Health : " + health);
    }
    public void TakeDamage(float ratio)
    {
        health -= (int)(health * ratio);
        if (health <= 0f)
        {
            Die();
        }
    }

    private void Die()
    {
        //EventManager.RungEnemyDieEvent();
        Destroy(this.gameObject);
    }
    public float GetHealth()
    {
        return health;
    }

    public void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Bullet"))
        {
            TakeDamage(10);
            coll.gameObject.SetActive(false);
        }
        if (coll.gameObject.CompareTag("Player"))
        {
            TakeDamage(20);
        }
    }
    
    public virtual void Move()
    {

    }
}
