using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    public static bool startTimer; // this is needed to prevent Timer from starting on Main Title screen
    

    // Use this for initialization
    void Start()
    {
        startTimer = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            
            SceneManager.LoadScene(1);
            startTimer = true;
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (Input.GetKey(KeyCode.F1))
        {
            SceneManager.LoadScene(0);
        }

        

    }
    
}
