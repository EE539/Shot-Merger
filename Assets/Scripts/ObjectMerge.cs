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
                AddBullet(collision.gameObject, gameObject.tag);
                MergeObjects(collision.gameObject);
            } 
        }
    }
    void AddBullet(GameObject player, string operation)
    {
        if (operation[0].Equals('x')) {
            player.GetComponent<CreateBullet>().desiredCreationTime /= (int)char.GetNumericValue(operation[1]);
        }
        else
        {
            player.GetComponent<CreateBullet>().desiredCreationTime -= (int)char.GetNumericValue(operation[1])/10;    //CreateBullet.bulletCount += (int)char.GetNumericValue(operation[1]);
        }
        CreateBullet.gameObjectDestroyed = true;
        
    }
    void MergeObjects(GameObject player)
    {
        List<Vector3> distanceToPlayer = new List<Vector3>();
        float nearestDistance = float.MaxValue, centeralized = 0;
        int whichChild = 0;

        for (int count = 0; count < this.transform.childCount; count++) //Child objelerin lokasyonlar�n� ald�m
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
        }//hangisi player'a yak�n
        centeralized = transform.GetComponent<Renderer>().bounds.center.x - transform.GetChild(whichChild - 1).GetComponent<Renderer>().bounds.center.x;
        if (player.transform.childCount <= 3)
        {
            if (centeralized != 0) //sol veya sa�
            {
                transform.position = new Vector3(player.transform.position.x - 0.02f + centeralized, transform.position.y, transform.position.z);
            }
            else //orta veya tek k�p
            {
                transform.position = new Vector3(player.transform.position.x - 0.02f, transform.position.y, transform.position.z);
            }
            
            //en yak�n objeyi player ile birle�tir birle�tirme
        } // ilk obje

        else //player'�n de�il, �arpt��� k�p�n merkezinden al!
        {
            if (centeralized != 0) //sol veya sa�
            {
                transform.position = new Vector3(player.transform.position.x - 0.02f + centeralized, transform.position.y, transform.position.z);
            }
            else //orta veya tek k�p
            {
                transform.position = new Vector3(player.transform.position.x - 0.02f, transform.position.y, transform.position.z);
            }
        } //ilk objeden sonra
        
        this.transform.parent = player.transform;
        
        //CreateBullet.extraPosition = CreateBullet.extraPosition + transform.localScale.z + 0.1f;

    }
}
