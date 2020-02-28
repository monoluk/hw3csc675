﻿
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public Animator spin;
    public float forwardForce = 2000f;
    public float sidewayForce = 1f;
    public float jumpForce = 500f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);     

        if(Input.GetKey("d")){
            rb.AddForce(sidewayForce * Time.deltaTime, 0,0, ForceMode.VelocityChange);
        }

        if (Input.GetKey("a"))
        {
            rb.AddForce(-sidewayForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (Input.GetKeyDown("w"))
        {
            spin.SetTrigger("spin");
            rb.AddForce(0, jumpForce * Time.deltaTime, forwardForce * Time.deltaTime);
        }
        if (Input.GetKeyDown("z"))
        {
            FindObjectOfType<GameManager>().GoToNextLevel();
        }

        if (rb.position.y < -1f){
            FindObjectOfType<GameManager>().EndGame();
        }

    }
}
