using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [HideInInspector] public static bool gameObjectDestroyed = false;
    public float speedOfBullet = 10;
    float time = 0;
    // Update is called once per frame

    void FixedUpdate()
    {  
        time += Time.deltaTime;
        float yAxis = -speedOfBullet * Time.deltaTime;
        transform.Translate(0, yAxis, 0);
        if (time >= 1)
        {
            Debug.Log("Will be destroyed");
            Destroy(gameObject);
            gameObjectDestroyed = true;
            time = 0;
        }
            
    }
}
