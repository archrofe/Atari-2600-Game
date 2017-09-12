using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public Text countText;
    public Text winText;

    private int count;

    // Use this for initialization
    void Start()
    {
        count = 0;
        SetCountText();
        winText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        Shortcuts();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Oil Barrel"))
        {
            other.gameObject.SetActive(false);
            count = count + 100;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "Score: " + count;
        if (count >= 1000)
        {
            winText.text = "You Win!";
        }
    }

    void Shortcuts()
    {
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
