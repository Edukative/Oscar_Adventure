using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed; //speed of enemi
    Rigidbody2D rb2D;
    public bool isVertical;

    //timer values
    float timer;
    int direction = 1;
    public float changeTime = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>(); //get teh enemy's RigidBody  
        timer = changeTime; //set timer
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            direction = -direction;
            timer = changeTime;
        }

        Vector2 position = rb2D.position; //get teh current position of teh enemy

        if (isVertical)
        {
            position.y = position.y + Time.deltaTime * speed * direction;

        }
        else
        {
            position.x = position.x + Time.deltaTime * speed * direction;
        }
            

        rb2D.MovePosition(position);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        PlayerController player = other.gameObject.GetComponent<PlayerController>();

        if (player !=null)
        {
            player.ChangeHealth(-1);
        }
    }
}
