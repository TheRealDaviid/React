using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MController : MonoBehaviour
{
    public Camera cam;
    private float maxField;
    public GameObject apple;
    
    void Start()
    {
        if (cam == null)
        {
            cam = Camera.main; //if no camera exists, use the main camera of the scene
        }
        Vector3 upperCorner = new Vector3(Screen.width, Screen.height, 0.0f);
        Vector3 targetWidth = cam.ScreenToWorldPoint(upperCorner); //Welt begrenzen so, dass gameobject nicht welt velässt
        maxField = targetWidth.x;
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f);
            Vector3 spawnPosition = new Vector3(
              Random.Range(-maxField, maxField),
              transform.position.y,
              0.0f
              );
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(apple, spawnPosition, spawnRotation);
            yield return new WaitForSeconds(Random.Range(1.0f, 2.0f));
        }
    }
}
