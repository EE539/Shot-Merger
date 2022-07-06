using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMerge : MonoBehaviour
{
    CreateBullet addBullet;
    int count = 0;
    GameObject bullets = GameObject.FindGameObjectWithTag("Bullet");
   private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(gameObject.name == "x2 Cube"){
                if(addBullet.bulletCount < 3){
                    for(GameObject bullet in bullets){
                        Destroy(bullet);
                    }
                    bulletCount *= 2;
                }
            } 
        }

    }
}
