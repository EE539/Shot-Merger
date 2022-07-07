using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMerge : MonoBehaviour
{
    CreateBullet bulletTimer;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(gameObject.tag == "x2" || gameObject.tag == "+2" || gameObject.tag == "+1" || gameObject.tag == "x3")
            {
                AddBullet(gameObject.tag);
                MergeObjects(collision.gameObject);
            } 
        }
    }
    void AddBullet(string operation)
    {

        if (CreateBullet.bulletCount < 3)
        {
            Destroy(GameObject.FindGameObjectWithTag("Bullet"));
            if (operation[0].Equals('x')) {
                CreateBullet.bulletCount *= (int)char.GetNumericValue(operation[1]);
            }
            else
            {
                CreateBullet.bulletCount += (int)char.GetNumericValue(operation[1]);
            }
            CreateBullet.gameObjectDestroyed = true;
        }
        if (CreateBullet.bulletCount > 3)
        {
            CreateBullet.bulletCount = 3;
            bulletTimer.desiredCreationTime -= 0.03f;
            
        }
    }
    void MergeObjects(GameObject player)
    {
        this.transform.parent = player.transform;
        CreateBullet.extraPosition = CreateBullet.extraPosition + transform.localScale.z + 0.1f;
    }
}
