using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBullet : MonoBehaviour
{
    public static int bulletCount = 1;
    private float position = -0.02f, positionOfBullet = 0;
    public GameObject bullet;
    [HideInInspector] public static bool gameObjectDestroyed = true;

    // Update is called once per frame
    void Update()
    {
        if (gameObjectDestroyed)
        {
            float posX = transform.position.x + position, posY = transform.position.y, posZ = transform.position.z;
            Vector3 pos = new Vector3(posX, posY, posZ);
            
            for (int i = 0; i < bulletCount; i++)
            {
                Instantiate(bullet, pos, bullet.transform.rotation);
                positionOfBullet = positionOfBullet + 0.02f;
                posX = transform.position.x + position + positionOfBullet;
                pos.x = posX;
            }
            gameObjectDestroyed = false;
            positionOfBullet = 0;
        }
    }
    
}
