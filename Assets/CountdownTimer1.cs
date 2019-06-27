using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer1 : MonoBehaviour {
    
    [SerializeField] private Text uiText;
    [SerializeField] private float mainTimer;
    [SerializeField] private float deduction;
    //[SerializeField] private float increment; //bonus when specials are added

    [SerializeField] private Button PassBtn1;
    [SerializeField] private Button PassBtn2;

    [SerializeField] private Text PlusSpecialText;
    [SerializeField] private Text MinusSpecialText;


    private float timer;
    private bool canCount;
    private bool ended;
    private bool isRunning;
    private bool penalty;
    private bool special;

    private bool gameStart;

    private int round;

    private float specialTime;

    private int specialNum;

    private float specialTimer;

    private float plusTimer;
    private float minusTimer;

    private float waitTime;

    //for special names
    private enum Specials {one, two, three};

    
    public GameObject goLight1;
    public GameObject stopLight1;
    public GameObject goLight2;
    public GameObject stopLight2;

    public GameObject specialPlus;
    
    // Use this for initialization
    void Start () {

        Time.timeScale = 1.0f;

        canCount = true;
        ended = false;
        isRunning = false;
        penalty = false;
        timer = GameSettings.timerTime;
        uiText.text = timer.ToString("f3");


        goLight1.SetActive(true);
        stopLight1.SetActive(false);
        goLight2.SetActive(true);
        stopLight2.SetActive(false);


        specialNum = 0;

        plusTimer = 0.0f;
        minusTimer = 0.0f;

        gameStart = true;
        
    }


    IEnumerator StarterCountdown()
    {
        yield return new WaitForSeconds(3);
        PassBtn1.onClick.Invoke();
        /*if (Random.value > 0.5)
        {
            PassBtn1.onClick.Invoke();
        }
        else
        {
            PassBtn1.onClick.Invoke();
        }*/

    }

    // Update is called once per frame
    void Update()
    {
        
        if (gameStart == true)
        {
            StarterCountdown();
        }

        if (special)
        {
			//need to add penalty if pressed while on cooldown
            if (specialNum == 1)
            {
                specialTime = PlusTime(GameSettings.timerTime);
                timer += Time.deltaTime + specialTime;


                specialTimer = 5.00f;
                plusTimer = specialTimer;
                PlusSpecialText.text = plusTimer.ToString("f3");
            }
            else if (specialNum == 2)
            {
                specialTime = MinusTime(GameSettings.timerTime);
                timer -= Time.deltaTime + specialTime;

                specialTimer = 7.00f;
                minusTimer = specialTimer;
                MinusSpecialText.text = minusTimer.ToString("f3");
            }

            uiText.text = timer.ToString("f3");
            special = false;
            specialNum = 0;
        }

        //If button is pressed while your timer is not running, you receive a penalty and your timer is updated
        else if (penalty)
        {
            timer -= Time.deltaTime + deduction;
            uiText.text = timer.ToString("f3");
            penalty = false;
        }

        //Starts timer for opposing side one button is pressed
        else if (timer >= 0.0f && canCount && isRunning)
        {
            timer -= Time.deltaTime;
            uiText.text = timer.ToString("f3");
        }

        else if (timer <= 0.0f && !ended)
        {
            GameOver();
        }




            if (plusTimer > 0f && !ended)
            {
                plusTimer -= Time.deltaTime;
                PlusSpecialText.text = plusTimer.ToString("f3");
            }
            else if (plusTimer <= 0f)
            {
                PlusSpecialText.text = "Ready!";

            }


            if (minusTimer > 0f && !ended)
            {
                minusTimer -= Time.deltaTime;
                MinusSpecialText.text = minusTimer.ToString("f3");
            }
            else if (minusTimer <= 0f)
            {
                MinusSpecialText.text = "Ready!";

            }

        

    }


    public void PauseBtn()
    {
        if (gameStart == true)
        {
            gameStart = false;
        }
        //Causes penalty deduction if button is pressed out of turn
        if (!canCount && !isRunning && gameStart == false)
        {
            penalty = true;
        }
        canCount = false;
        isRunning = false;
        
    }

    public void PressBtn()
    {
        if(gameStart == true)
        {
            gameStart = false;
        }
        canCount = true;
        isRunning = true;

    }


    public void PauseGame()
    {
        PauseBtn();
        canCount = true;
    }
    
    public void ResetBtn()
    {
        Start();
    }

    void GameOver()
    {
        //have text pop up win/lose
        Time.timeScale = 0.0f;

        if (timer <= 0)
        {
            //show lose
            uiText.text = "You Lose";
        }
        if (timer > 0f)
        {
            //show win
            uiText.text = "You Win";
        }
                
    }
    
    
    public void Lights1() //passbtn1 onclick()
    {
        goLight1.SetActive(true);
        stopLight1.SetActive(false);
        goLight2.SetActive(false);
        stopLight2.SetActive(true);
    }


    public void Lights2() //passbtn2 onclick()
    {
        goLight1.SetActive(false);
        stopLight1.SetActive(true);
        goLight2.SetActive(true);
        stopLight2.SetActive(false);
    }
    


    public void SpecialPlusButton()
    {
        if(PlusSpecialText.text == "Ready!")
        {
            special = true;
            specialNum = 1;
        }
        else
        {
            penalty = true;
            //deduction = 1; works
        }
        
    }

    public void SpecialMinusButton()
    {
        if (MinusSpecialText.text == "Ready!")
        {
            special = true;
            specialNum = 2;
        }
        else
        {
            penalty = true;
        }
        
    }


    private float PlusTime(float maxTime)
    {
        float add = 0f;
        add = maxTime * .1f;

        return add;
    }

    private float MinusTime(float maxTime)
    {
        float minus = 0f;
        minus = maxTime * .05f;

        return minus;
    }


}
