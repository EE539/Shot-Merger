using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBullet : MonoBehaviour
{
    public Movement isAlive;
    public static int bulletCount = 1;
    private float position = -0.02f, positionOfBullet = 0;
    [HideInInspector]public static float extraPosition = 0;
    public GameObject bullet;
    float timer;
    public float desiredCreationTime = 1;
    [HideInInspector] public static bool gameObjectDestroyed = true;

    // Update is called once per frame
    void Update()
    {
        if (isAlive.aliveState)
        {
            timer += Time.deltaTime;
            if (gameObjectDestroyed || timer == desiredCreationTime)
            {
                if (transform.childCount <= 3)
                {
                    float posX = transform.position.x + position, posY = transform.position.y, posZ = transform.position.z + extraPosition;
                    Vector3 pos = new Vector3(posX, posY, posZ);

                    for (int i = 0; i < bulletCount; i++)
                    {
                        Instantiate(bullet, pos, bullet.transform.rotation);
                        positionOfBullet = positionOfBullet + 0.02f;
                        posX = transform.position.x + position + positionOfBullet;
                        pos.x = posX;
                    }
                    gameObjectDestroyed = false;
                    positionOfBullet = 0;
                }
                else
                {
                    for (int childCounter = 0; childCounter < this.transform.childCount; childCounter++)
                    {
                        Debug.Log("childCounter = " + childCounter);
                        string[] childName = this.transform.GetChild(childCounter).name.Split(" ");
                        if (childName.Length >= 2)
                        {
                            Debug.Log("Entered 2");
                            if (childName[1].Equals("Cubes") || childName[1].Equals("Cube")) //x2 Cubes veya +1 Cube
                            {
                                Debug.Log("Entered 3");
                                int counterCube = 0;
                                Transform aCube = transform.GetChild(childCounter);
                                while (counterCube < aCube.childCount)
                                {
                                    Debug.Log("Entered 4");
                                    if (aCube.GetChild(counterCube).tag.Equals("Cube"))
                                    {
                                        Debug.Log("Entered 5");
                                        Instantiate(bullet, aCube.GetChild(counterCube).transform.GetComponent<Renderer>().bounds.center, bullet.transform.rotation);
                                    }
                                    counterCube++;
                                }
                            }
                        }
                    }
                }
               
            }
        }
        else
            gameObjectDestroyed = true;
        
    }
    
}
