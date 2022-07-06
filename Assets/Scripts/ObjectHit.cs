using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHit : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
            Destroy(this);
        }
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("Failed :(");
        }

    }
}
