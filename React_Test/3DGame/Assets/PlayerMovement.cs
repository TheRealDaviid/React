using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO.Ports;

public class PlayerMovement : MonoBehaviour {

    public Rigidbody rb;
    public float addForce = 2000f;
    public float addForceSide = 500f;
    public string Direction = "X";

    public SerialPort sp = new SerialPort("COM1", 115200, Parity.None, 8, StopBits.One);

    void Start () {
        //Open the serial port       
    sp.Open();
        //Set the datareceived event handler        
        //Open the Program function
        //rb.useGravity = false;
        //rb.AddForce(0, 200, 500);
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        rb.AddForce(0,0,addForce*Time.deltaTime);
        Direction = sp.ReadExisting();

        if (Direction.Contains("D"))
        {
            Debug.Log("Right");
            rb.AddForce(0, 0, -100 * Time.deltaTime, ForceMode.VelocityChange);
        }
        if (Direction.Contains("U"))
        {
            Debug.Log("Right");
            rb.AddForce(0, 0, 100*Time.deltaTime, ForceMode.VelocityChange);
        }
        if (Direction.Contains("R"))
        {
            Debug.Log("Right");
            rb.AddForce(addForceSide*Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (Direction.Contains("L"))
        {
            Debug.Log("Left");
            rb.AddForce(-addForceSide * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        sp.BaseStream.Flush();
    }
}