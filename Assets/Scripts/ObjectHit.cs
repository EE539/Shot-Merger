using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ObjectHit : MonoBehaviour
{
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
            Debug.Log("Failed :(");
        }
    }
}
