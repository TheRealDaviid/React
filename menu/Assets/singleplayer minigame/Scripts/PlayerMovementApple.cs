using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO.Ports;

public class PlayerMovementApple : MonoBehaviour
{

    public Rigidbody rb;
    public float addForce = 20f;
    public float addForceSide = 20f;
    public string Direction = "X";
    private float maxField;
    public SerialPort sp = new SerialPort("COM9", 115200, Parity.None, 8, StopBits.One);
    public Camera cam;
    public static bool check = false;
    void Start()
    {
        //Open the serial port       
        sp.Open();
        Vector3 upperCorner = new Vector3(Screen.width, Screen.height, 0.0f);
        Vector3 targetWidth = cam.ScreenToWorldPoint(upperCorner); //Welt begrenzen so, dass gameobject nicht welt velässt
        maxField = targetWidth.x;
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
        if (rb.position.x >= maxField)
        {
            rb.position = new Vector3(maxField, 0, 0);
        }
        if (rb.position.x <= -maxField)
        {
            rb.position = new Vector3(-maxField, 0, 0);
        }
        if (Direction.ToString().Contains("R"))
        {
            //rb.AddForce(addForceSide * Time.deltaTime, 0, 0, ForceMode.Impulse);
            rb.position=new Vector3(rb.position.x+(float)0.3,0,0);
        }
        if (Direction.ToString().Contains("L"))
        {
            //rb.AddForce(-addForceSide * Time.deltaTime, 0, 0, ForceMode.Impulse);
            rb.position = new Vector3(rb.position.x - (float)0.3, 0, 0);
        }
        //if (Direction.ToString().Contains("X"))
        //{
        //    rb.position = new Vector3(0, 0, 0);
        //}
        if (Direction.ToString().Contains("S"))
        {
            check = true;
            SumScript.fragenCounter++;
            SumScript.UpdateScore();
            check = false;
        }
       

        sp.BaseStream.Flush();
    }
}