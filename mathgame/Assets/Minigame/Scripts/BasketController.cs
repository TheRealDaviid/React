//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using System.IO.Ports;

//public class BasketController : MonoBehaviour
//{
//    public Camera cam;
//    new Rigidbody2D rigidbody;
//    private float maxField;
//    public string Direction = "X";

//    public SerialPort sp = new SerialPort("COM9", 115200, Parity.None, 8, StopBits.One);
//    void Start()
//    {
//        sp.Open();
//        if (cam == null)
//        {
//            cam = Camera.main; //if no camera exists, use the main camera of the scene
//        }
//        Vector3 upperCorner = new Vector3(Screen.width, Screen.height, 0.0f);
//        Vector3 targetWidth = cam.ScreenToWorldPoint(upperCorner); //Welt begrenzen so, dass gameobject nicht welt velässt
//        maxField = targetWidth.x;
//        rigidbody = this.gameObject.GetComponent<Rigidbody2D>();
//    }
   
//    void FixedUpdate()
//    {
//        Vector3 rawPosition=new Vector3(0.0f,0.0f,0.0f);
//        try
//        {
//            Direction = sp.ReadExisting().Substring(0, 1);
//        }
//        catch
//        {

//        }
//        //if (Direction == "R")
//        //{
//        //   rawPosition = cam.ScreenToWorldPoint(new Vector3(0.1f, 0.0f, 0.0f));
//        //}
//        //if(Direction=="L")
//        //{
//        //   rawPosition = cam.ScreenToWorldPoint(new Vector3(-0.01f, 0.0f, 0.0f));
//        //}
//        Vector3 targetPosition = new Vector3(rawPosition.x, 0.0f, 0.0f);
//        float targetWidth = Mathf.Clamp(targetPosition.x, -maxField, maxField);
//        //targetPosition = new Vector3(targetWidth, targetPosition.y, targetPosition.z);
//        rigidbody.MovePosition(targetPosition);
//    }
//}
