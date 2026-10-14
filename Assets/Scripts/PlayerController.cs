using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f; // public 외부 공용, private 비공개
      
    public GameObject bulletPrefab;
    public float bulletSpeed = 100f;

    private void Start()
    {
         
    }

    private void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(x, y, 0);
        transform.position += direction.normalized * speed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            for (int i = 0; i < 3; i++)
            {
                GameObject bullet = Instantiate(bulletPrefab);

                Vector3 bulletPos = transform.position;
                bulletPos.y += 0.3f * i;

                bullet.transform.position = bulletPos;

                bullet.GetComponent<Rigidbody2D>()
                    .AddForce(Vector2.up * bulletSpeed);
            }
        }
    }
}