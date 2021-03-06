﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2D : MonoBehaviour
{
   // public CharacterController2D controller;

    public KeyCode left;
    public KeyCode right;
    public KeyCode jump;

    public Animator animator;

    public Rigidbody2D player;
    float horizontalMove = 0f;
    private bool m_Grounded;
    private float m_JumpForce = 400f;

    

    public float runSpeed = 0f;
    public float jumpforce = 0f;
    private bool m_FacingRight = true;
     bool jump1 = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(player.velocity.y);
       
        animator.SetFloat("Speed", Mathf.Abs(runSpeed));
        
        horizontalMove = player.velocity.y;
        if (Input.GetKey(left))
        {
            runSpeed = 8f;
            player.velocity = new Vector2(-runSpeed, player.velocity.y);
            
            if (runSpeed > 0 && m_FacingRight)
            {
                // ... flip the player.
                Flip();
            }
           

        }
        else if (Input.GetKey(right))
        {
            runSpeed = 8f;
            player.velocity = new Vector2(runSpeed, player.velocity.y);
            
            if (-runSpeed < 0 && !m_FacingRight)
            {
                // ... flip the player.
                Flip();
            }
            
        }
        else 
        {
            runSpeed = 0f;
            player.velocity = new Vector2(runSpeed, player.velocity.y);
        }

        if (Input.GetKeyDown(jump))
        {
            player.velocity = new Vector2(player.velocity.x, jumpforce);
            if (m_Grounded && jump1)
            {
                runSpeed = 0f;
                // Add a vertical force to the player.
                m_Grounded = false;
                player.AddForce(new Vector2(runSpeed, jumpforce));
            }
        }
        
        //horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed; // A = -1 , D = 1 //InputManager Settings
        //Debug.Log(Input.GetAxisRaw("Horizontal"));
        //if (Input.GetButtonDown("Jump"))
        //{
        //    jump = true;
        //}
    }

    //void FixedUpdate()
    //{
    //    //Apply Update to Character
    //    controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump); //fixedDeltatime: amount of time elapsed function
    //    jump = false;
    //}

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
