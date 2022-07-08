using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    public GameObject player ;
    public Vector3 offset = new Vector3(-0.09f, 0.08f,0.08f);
    private void Update()
    {
        transform.position = new Vector3(player.transform.position.y, player.transform.position.x, player.transform.position.z) + offset;
    }

}
