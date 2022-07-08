using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyExtraBullets : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collisions = " + collision.gameObject.tag);
        if (collision.gameObject.tag.Equals("Player"))
        {
            Destroy(this.gameObject);
        }
    }
}
