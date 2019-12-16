using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed; //speed of enemi
    Rigidbody2D rb2D;
    public bool isVertical 

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>(); //get teh enemy's RigidBody  
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = rb2D.position; //get teh current position of teh enemy

        if (isVertical)
        {
            position.y = position.y + Time.deltaTime * speed;

        }
        else
        {
            position.x = position.x + Time.deltaTime * speed;
        }
            

        rb2D.MovePosition(position);
    }
}
