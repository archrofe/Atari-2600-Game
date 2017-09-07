using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;




public class Player1 : MonoBehaviour
{
    public float movementSpeed = 1;
    public float acceleration = 10f;
    public float deceleration = .1f;

    


    private Rigidbody2D rigid;

    // Use this for initialization
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();

        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        // ShortCuts();
    }

    void Movement()
    {
        // If user presses D
        if (Input.GetKey(KeyCode.D))
        {
            // Move Right
            rigid.AddForce(transform.right * acceleration);
        }
        //If user presses A
        if (Input.GetKey(KeyCode.A))
        {
            // Move Left
            rigid.AddForce(-transform.right * acceleration);
        }

        if (Input.GetKey(KeyCode.W))
        {
            // Move Up
            rigid.AddForce(transform.up * acceleration);
        }
        
        if (Input.GetKey(KeyCode.S))
        {
            // Move Down
            rigid.AddForce(-transform.up * acceleration);
        }

        //Deceleration
        rigid.velocity += -rigid.velocity * deceleration;
    }
    
    
}