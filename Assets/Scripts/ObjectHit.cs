using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ObjectHit : MonoBehaviour
{
    public UIScript fail;
    public Movement isAlive;
    public TextMeshProUGUI numberText;
    int textToInt;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            textToInt = int.Parse(numberText.text);
            if(textToInt > 0)
            {
                textToInt--;
                numberText.text = textToInt.ToString();
            }
            if(textToInt <= 0)
            {
                Destroy(gameObject);
                Destroy(numberText);

            }
            Destroy(collision.gameObject);
            CreateBullet.gameObjectDestroyed = true;
            
        }
        else if(collision.gameObject.tag == "Player")
        {
            isAlive.aliveState = false;
            collision.gameObject.GetComponent<Rigidbody>().useGravity = true;
            collision.gameObject.GetComponent<Movement>().enabled = false;
            GameObject ChildGameObject1 = collision.gameObject.transform.GetChild(0).gameObject;
            GameObject ChildGameObject2 = collision.gameObject.transform.GetChild(1).gameObject;

            ChildGameObject1.transform.Translate(0, -0.05f, 0);
            ChildGameObject2.transform.Translate(0, 0.05f, 0);

            for(int count = 3; count < collision.gameObject.transform.childCount; count++)
            {
                Destroy (collision.gameObject.transform.GetChild(count).gameObject);
            }
            fail.Fail();
        }
    }
}
