
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement movement;
    public Vector3 stepup;
    public Vector3 stepup2;
    public bool call = new bool();
    void OnCollisionEnter (UnityEngine.Collision collisionInfo)
    {

        
        if (collisionInfo.collider.name.StartsWith("Floor"))
        {
            //Debug.Log("We hit an Obstacle");
            this.GetComponent<Rigidbody>().position += stepup;
           
        }
        if ( collisionInfo.collider.name.StartsWith("Cube"))
        {
            Debug.Log("steps");
            this.GetComponent<Rigidbody>().position += stepup;
        }
        //if (collisionInfo.collider.tag == "Finish")
        //{
        //    Debug.Log("We hit an Obstacle");
        //    movement.enabled = false;
        //}
    }
	
}
