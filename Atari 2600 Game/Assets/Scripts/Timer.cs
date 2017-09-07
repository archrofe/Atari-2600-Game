using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float timer;
    public string clockTime;
    public Text clockText;

    private static int score1;
    private static int score2;

    private static bool timerStarted;

    // Use this for initialization
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            WhoWon();
        }

        timerStarted = Title.startTimer; // calling startTimer bool from Title script

        if (timerStarted == true)
        {
            if (timer <= 0)
            {
                WhoWon();
                timerStarted = false; // resets timerStarted so that it needs to be activated again to start counting again
            }

            if (timer > 0) // if we are greater than Zero
            {

                timer -= Time.deltaTime; // count down... this alone may take us past Zero

                int mins = Mathf.FloorToInt(timer / 60); // FloorToInt, rounds up
                int secs = Mathf.FloorToInt(timer - mins * 60);

                clockTime = string.Format("{0:0}:{1:00}", mins, secs);
                clockText.text = clockTime;
                
            }
        }

        
  

    }
    
    void WhoWon()
    {
        

        // calling Score counters from P1Score and P2Score scripts
        score1 = P1Score.score;
        score2 = P2Score.score;
        
        if (score1 < score2)
        {
            SceneManager.LoadScene(2);
        }

        if (score1 > score2)
        {
            SceneManager.LoadScene(3);
        }

        if (score1 == score2)
        {
            SceneManager.LoadScene(4);
        }

    }
}