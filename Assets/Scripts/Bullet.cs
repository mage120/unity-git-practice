using UnityEngine;

public class Bullet : MonoBehaviour
{
    void Start()
    {
        Invoke("DestroySelf", 2f);
    }

    void DestroySelf()
    {
        Destroy(gameObject);
    }
}
