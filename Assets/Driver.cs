using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 275f;
    [SerializeField] float moveSpeed = 25f;
    [SerializeField] float boostSpeed = 35f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Time.deltaTime adjust everything by framerate
        float steerAmount = (Input.GetAxis("Horizontal")) * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0,0, -steerAmount);
        transform.Translate(0, moveAmount,0);
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Booster")
        {
            moveSpeed = boostSpeed;
        }
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        moveSpeed = 25f;    
    }
}
