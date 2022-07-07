using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMerge : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(gameObject.tag == "x2"){
                if(CreateBullet.bulletCount < 3){
                    Destroy(GameObject.FindGameObjectWithTag("Bullet"));
                    CreateBullet.bulletCount *= 2;
                    CreateBullet.gameObjectDestroyed = true;
                }
            } 
        }
        //To do -> Merge blocks with gun
        //To do -> Make block disapear if hits barel before it touches it
    }
}
