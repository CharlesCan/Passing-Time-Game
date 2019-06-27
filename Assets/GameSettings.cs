using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameSettings : MonoBehaviour {


    [SerializeField] private Text uiText;

    [SerializeField] static public float timerTime = 5;
    [SerializeField] private float timerIncr;
    [SerializeField] private float timerDecr;
    [SerializeField] private float handicap;


    void Start()
    {
        uiText.text = timerTime.ToString("f");

    }
    
    void Update()
    {
        uiText.text = timerTime.ToString("f");
    }



    public void GameMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void DefaultSettings()
    {

    }

    public void CustomSettings()
    {

    }

    public void DecreaseTimer ()
    {
        if (timerTime >= 10)
        {
            timerTime -= 5;
        }

        else if (timerTime <= 5 && timerTime > 1)
        {
            timerTime -= 1;
        }
        else if (timerTime == 1)
        {
            //tell user cant go below 1
        }
        else
        {
            //what the hell happened
        }
    }

    public void IncreaseTimer()
    {
        if (timerTime < 5 && timerTime >= 1)
        {
            timerTime += 1;
        }
        else if (timerTime >= 5 && timerTime < 30)
        {
            timerTime += 5;
        }
        else if (timerTime == 30)
        {
            //tell user cant above 30
        }
        else
        {
            //what the hell happened
        }
    }

    public void DecreaseHandicap()
    {
        if (handicap <= 10 && handicap > 1)
        {
            handicap -= 1;
        }
        else if (handicap == 1)
        {
            //tell user cant go below 1
        }
        else
        {
            //what the hell happened
        }
    }

    public void IncreaseHandicap()
    {
        if (handicap < 10 && handicap >= 1)
        {
            handicap += 1;
        }
        else if (handicap == 10)
        {
            //tell user cant above 10
        }
        else
        {
            //what the hell happened
        }
    }

    public void SetBonusIncr(float bonus)
    {

    }

    public void SetPenaltyDecr(float penalty)
    {

    }

    public void SetTimer()
    {

    }


}
