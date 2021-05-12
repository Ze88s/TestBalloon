using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour
{
    public Slider slider;
    public Text text;
    public Button button;
  
    public void RestartLevel()
    {
         SceneManager.LoadScene( SceneManager.GetActiveScene().buildIndex ) ;
    }

    // Update is called once per frame
    void Update()
    {
        if (slider.value== slider.maxValue)
        {
            text.text="YOU WIN!";
            button.gameObject.SetActive(true);
          
        }
        if (slider.value==slider.minValue)
        {
            button.gameObject.SetActive(true);
             text.text="YOU LOSE!";
        }
    }
}
