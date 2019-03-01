using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketController : MonoBehaviour
{
    public Camera cam;
    new Rigidbody2D rigidbody;
    private float maxField;
    // Start is called before the first frame update
    void Start()
    {
        if (cam == null)
        {
            cam = Camera.main; //if no camera exists, use the main camera of the scene
        }
        Vector3 upperCorner = new Vector3(Screen.width, Screen.height, 0.0f);
        Vector3 targetWidth = cam.ScreenToWorldPoint(upperCorner); //Welt begrenzen so, dass gameobject nicht welt velässt
        maxField = targetWidth.x;
        rigidbody = this.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 rawPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 targetPosition = new Vector3(rawPosition.x, 0.0f, 0.0f);
        float targetWidth = Mathf.Clamp(targetPosition.x, -maxField, maxField);
        targetPosition = new Vector3(targetWidth, targetPosition.y, targetPosition.z);
        rigidbody.MovePosition(targetPosition);
    }
}
