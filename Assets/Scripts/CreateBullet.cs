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
            float posX = transform.position.x + position, posY = transform.position.y, posZ = transform.position.z + extraPosition;
            Vector3 pos = new Vector3(posX, posY, posZ);

            timer += Time.deltaTime;
            if (gameObjectDestroyed || timer == desiredCreationTime)
            {
                if (transform.childCount <= 3)
                {                    
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
                else if(transform.childCount > 3)
                {
                    List<Vector3> position = new List<Vector3>();
                    foreach (Transform child in this.transform)
                    {
                        string[] childName = child.name.Split(' ');
                        if(childName.Length < 2)
                        {
                            continue;
                        }
                        if (childName[1].Equals("Cube") || childName[1].Equals("Cubes"))
                        {
                            for(int counterCube = 0; counterCube<child.childCount; counterCube++)
                                if(child.GetChild(counterCube).tag.Equals("Cube"))
                                    position.Add(child.GetChild(counterCube).transform.GetComponent<Renderer>().bounds.center); //çocuðun merkezi alýndý
                            
                            for(int i = 0; i < position.Count; i++)
                            {
                                for(int count = 0; count < bulletCount; count++)
                                {
                                    Instantiate(bullet, position[i], bullet.transform.rotation);
                                }
                            }
                            gameObjectDestroyed = false;
                            positionOfBullet = 0;
                        }
                    }
                }
            }
        }
        else
            gameObjectDestroyed = true;
        
    }
    
}
