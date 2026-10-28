using UnityEngine;

public class EnemyScripts : MonoBehaviour
{
    public float health = 50.0f;

    private void TakeDamage(int value)
    {
        health -= value;
        if (health <= 0f)
        {
        }
    }

    public float GetHealth()
    {
        return health;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        TakeDamage(10);
        Debug.Log("health: " + health);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
