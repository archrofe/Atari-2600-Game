using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightCross : MonoBehaviour
{

    public Transform punchTarget;
    public Transform punchReturn;
    public float rightSpeed = 1;
    
    // public float crossSpeed = .5f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Punch();
    }

    void Punch()
    {
        // if user presses G, then Left Jab!
        if (Input.GetKey(KeyCode.H))
        {
            float step1 = rightSpeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, punchTarget.position, step1);

            
        }

        if (Input.GetKeyUp(KeyCode.H))
        {
            float step2 = 2;
            transform.position = Vector2.MoveTowards(transform.position, punchReturn.position, step2);
        }

        /*if (Input.GetKey(KeyCode.H))
        {
            float step = crossSpeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, punchTarget.position, step);


        }*/
    }

    /*void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Punch Target"))
        {
            float step = jabSpeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, punchReturn.position, step);
        }

    }*/

}

