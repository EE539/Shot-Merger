using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBullet : MonoBehaviour
{
    public GameObject bullet;


    // Start is called before the first frame update
    void Start()
    {
        Instantiate(bullet);
        //Debug.Log(transform.position);
        //bullet.transform.position = GameObject.FindWithTag("Player").transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (BulletMovement.gameObjectDestroyed)
        {
            Instantiate(bullet);
            bullet.transform.position = new Vector3 (transform.position.x - 0.02f, transform.position.y, transform.position.z + 5.3f);
            BulletMovement.gameObjectDestroyed = false;
        }
    }
}
