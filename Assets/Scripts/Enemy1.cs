using UnityEngine;

public class Enemy1 : EnemyScripts
{
    public float downSpeed = 2f;
    public float sideSpeed = 3f;

    private int direction = 1;

    private void Start()
    {
        if (gameCamera == null || enemySprite == null || body == null)
            return;

        float top = gameCamera.transform.position.y
                    + gameCamera.orthographicSize;

        Vector2 pos = body.position;
        pos.y = top + enemySprite.bounds.extents.y;
        body.position = pos;

        Move();
    }

    private void FixedUpdate()
    {
        if (gameCamera == null || enemySprite == null || body == null)
            return;

        float cameraWidth = gameCamera.orthographicSize
                            * gameCamera.aspect;

        float left = gameCamera.transform.position.x
                     - cameraWidth;

        float right = gameCamera.transform.position.x
                      + cameraWidth;

        if (enemySprite.bounds.max.x >= right)
        {
            direction = -1;
        }

        if (enemySprite.bounds.min.x <= left)
        {
            direction = 1;
        }

        Move();
    }

    public override void Move()
    {
        if (body == null) return;   

        Vector2 velocity = new Vector2(
            direction * sideSpeed, -downSpeed);

#if UNITY_6000_0_OR_NEWER
        body.linearVelocity = velocity;
#else
        body.velocity = velocity;
#endif
    }
}