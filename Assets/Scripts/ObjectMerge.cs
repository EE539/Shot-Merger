using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMerge : MonoBehaviour
{
    CreateBullet bulletTimer;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (gameObject.tag == "x2" || gameObject.tag == "+2" || gameObject.tag == "+1" || gameObject.tag == "x3")
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
        List<Vector3> distanceToPlayer = new List<Vector3>();
        float nearestDistance = float.MaxValue, centeralized = 0;
        int whichChild = 0;

        for (int count = 0; count < this.transform.childCount; count++) //Child objelerin lokasyonlarýný aldým
        {
            distanceToPlayer.Add(this.transform.GetChild(count).position);
        }
        foreach (Vector3 distance in distanceToPlayer)
        {
            if (Vector3.Distance(player.transform.position, distance) < nearestDistance)
            {
                nearestDistance = Vector3.Distance(player.transform.position, distance);
                whichChild++;
            }
        }//hangisi player'a yakýn
        centeralized = transform.GetComponent<Renderer>().bounds.center.x - transform.GetChild(whichChild - 1).GetComponent<Renderer>().bounds.center.x;
        if (player.transform.childCount <= 3)
        {
            if (centeralized != 0) //sol veya sað
            {
                transform.position = new Vector3(player.transform.position.x - 0.02f + centeralized, transform.position.y, transform.position.z);
            }
            else //orta veya tek küp
            {
                transform.position = new Vector3(player.transform.position.x - 0.02f, transform.position.y, transform.position.z);
            }
            
            //en yakýn objeyi player ile birleþtir birleþtirme
        } // ilk obje

        else //player'ýn deðil, çarptýðý küpün merkezinden al!
        {
            if (centeralized != 0) //sol veya sað
            {
                transform.position = new Vector3(player.transform.position.x - 0.02f + centeralized, transform.position.y, transform.position.z);
            }
            else //orta veya tek küp
            {
                transform.position = new Vector3(player.transform.position.x - 0.02f, transform.position.y, transform.position.z);
            }
        } //ilk objeden sonra
        //this.gameObject.AddComponent<CollisionDetector>();
        //this.gameObject.GetComponent<CollisionDetector>().player = player;
        /*en yakýn küpü silahýn namlusuna ekle*/
        //ikinci küpü en yakýn birleþme noktasýna ekle
        this.transform.parent = player.transform;
        //CreateBullet.extraPosition = CreateBullet.extraPosition + transform.localScale.z + 0.1f;

    }
}
