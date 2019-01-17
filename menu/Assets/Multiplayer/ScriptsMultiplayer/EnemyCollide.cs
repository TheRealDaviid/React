using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollide : MonoBehaviour
{
    public LevelManager levelmanager;

    public Vector3 startPos;
    public Vector3 newPos;
    public Vector3 tempPos;
    // Start is called before the first frame update
    public SpriteRenderer r;
    public float speed = 10f;
    void Start()
    {
        levelmanager = FindObjectOfType<LevelManager>();

        startPos = transform.position;
        //Zufälliger speed
        speed = Random.Range(3f, 4f);

        tempPos = startPos;
        r = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
        newPos = startPos;
        newPos.x = newPos.x + Mathf.PingPong(Time.time * speed, 6) - 3;
        transform.position = newPos;

        if (newPos.x < tempPos.x)
        {
            r.flipX = false;
        }
        else
        {
            r.flipX = true;
        }

        tempPos = newPos;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player" )
        {
            levelmanager.respawnOrNot("Player");
            Debug.Log("Enemy Colide");

        }
        if (collision.gameObject.tag == "Player 2")
        {
            levelmanager.respawnOrNot("Player 2");
            Debug.Log("Enemy Colide");

        }
    }
}
