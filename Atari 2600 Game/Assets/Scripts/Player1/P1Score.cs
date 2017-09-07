using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class P1Score : MonoBehaviour
{


    public static int score;
    public Text scoreText;

	// Use this for initialization
	void Start ()
    {
        score = 0;
        SetScoreText();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    //private void OnCollisionEnter2D(Collision2D other)
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("P1Fist"))
        {
            score = score + 1;
            SetScoreText();
        }
    }

        void SetScoreText()
    {
        scoreText.text = "" + score.ToString();
    }
}
