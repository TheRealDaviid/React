using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO.Ports;

public class PlayerMovement : MonoBehaviour {

    public Rigidbody rb;
    public float addForce = 2000f;
    public float addForceSide = 2000f;
    public string Direction = "X";

    public SerialPort sp = new SerialPort("COM5", 115200, Parity.None, 8, StopBits.One);

    void Start () {
        //Open the serial port       
        sp.Open();
        //Set the datareceived event handler        
        //Open the Program function
        //rb.useGravity = false;
        //rb.AddForce(0, 200, 500);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        try
        {
            Direction = sp.ReadExisting().Substring(0, 1);
        }
        catch
        {

        }
        if (Direction.ToString().Contains("D"))
        {
            rb.AddForce(0, 0, -20 * Time.deltaTime, ForceMode.VelocityChange);
        }
        if (Direction.ToString().Contains("U"))
        {
            rb.AddForce(0, 0, 20 * Time.deltaTime, ForceMode.VelocityChange);
        }
        if (Direction.ToString().Contains("R"))
        {
            rb.AddForce(addForceSide * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (Direction.ToString().Contains("L"))
        {
            rb.AddForce(-addForceSide * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (Direction.ToString().Contains("X"))
        {
            rb.AddForce(0, 0, 0, ForceMode.VelocityChange);
        }


        sp.BaseStream.Flush();
    }
}