using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using TMPro;


public class UIScript : MonoBehaviour
{
    public TMP_Text levelText;
    private static int counter = 1;
    float timeToWait = 0.5f, fillQuantity = 0.1f;
    private int count = 0;
    public Slider sliderValue;
    public GameObject success, fail;

    private void Start()
    {
        success.SetActive(false);
        fail.SetActive(false);
        string[] levelName = levelText.text.Split(' ');
        levelName[1] = counter.ToString();
        levelText.text = levelName[0] + " " + levelName[1];
    }
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

    public void Level()
    {
        success.SetActive(true);
        string[] levelName = levelText.text.Split(' ');
        counter = int.Parse(levelName[1]);
        counter++;
    }

    public void Fail()
    {
        fail.SetActive(true);

    }
    public void ExitGame()
    {
        Application.Quit();
    }

}
