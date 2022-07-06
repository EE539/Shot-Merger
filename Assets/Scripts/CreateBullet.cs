using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBullet : MonoBehaviour
{
    public int bulletCount = 1;
    public GameObject bullet;
    [HideInInspector] public static bool gameObjectDestroyed = true;

    // Update is called once per frame
    void Update()
    {
        if (gameObjectDestroyed)
        {
            for(int count = 0; count < bulletCount; count++){
                Instantiate(bullet);
                bullet.transform.position = new Vector3 (transform.position.x - 0.02f, transform.position.y, transform.position.z + 2f); 
            }        
            gameObjectDestroyed = false;
        }
    }
    
}
