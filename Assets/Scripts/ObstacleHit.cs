using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleHit : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("please be true 0.0 " + collision.collider.gameObject.transform.tag); //hayat�m�n anlam�
        string[] name = collision.collider.gameObject.transform.name.Split(' ');
        if (name.Length > 1 && (name[1].Equals("Cube") || name[1].Equals("Cubes")))
            Destroy(collision.collider.gameObject);
    }
}
