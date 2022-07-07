using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class UIScript : MonoBehaviour
{
    float timeToWait = 0.5f, fillQuantity = 0.1f;
    private int count = 0;
    public Slider sliderValue;
    public void RestartButton()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex; //Get the index of the scene
        SceneManager.LoadScene(currentSceneIndex);
    }
    float CalculateSliderValue()
    {
        if(count == 0)
        {
            if (sliderValue.value == 1)
                count = 1;
            return sliderValue.value + Time.deltaTime;
        }
        else
        {
            if (sliderValue.value == 0)
                count = 0;
            return sliderValue.value - Time.deltaTime;
        }
            
       
    }
    private void Update()
    {
        sliderValue.value = CalculateSliderValue();
    }

}
