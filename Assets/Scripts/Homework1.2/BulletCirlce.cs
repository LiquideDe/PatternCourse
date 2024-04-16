using UnityEngine;

public class BulletCirlce : MonoBehaviour
{
    private const int speed = 2;
    private const int lifeTime = 5;
    private float howLongLive = 0;

    // Update is called once per frame
    void Update()
    {
        howLongLive += Time.deltaTime;
        if(howLongLive > lifeTime)
        {
            Destroy(gameObject);
        }

        transform.Translate(transform.forward * speed * Time.deltaTime);
    }
}
