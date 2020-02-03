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

    Animator anim;
    
    public Vector2[] localNodes;
    int currentNode;
    int nextNode;
    Vector2 Velocity;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>(); //get teh enemy's RigidBody  
        timer = changeTime; //set teh timer
        anim = GetComponent<Animator>();

        localNodes = new Vector2[transform.childCount];

        for (int i = 0; i <= transform.childCount - 1; ++i)
        {
            Transform child = transform.GetChild(i).transform;
            localNodes[i] = new Vector2(child.transform.position.x, child.transform.position.y);
            Debug.Log("index " + i + "Transform" + localNodes[i]);

        }

        currentNode = 0;
        nextNode = 1;
    }

    // Update is called once per frame
    void Update()
    {

        /*timer -= Time.deltaTime;

        if (timer < 0)
        {
            direction = -direction;
            timer = changeTime;
        }

        Vector2 position = rb2D.position; //get teh current position of teh enemy

        */
        Vector2 wayPointDirection = localNodes[nextNode] - rb2D.position;
        float dist = speed * Time.deltaTime;


        if (wayPointDirection.sqrMagnitude < dist * dist)
        {
            dist = wayPointDirection.magnitude;
            currentNode = nextNode;
            nextNode += 1;
            if (nextNode >= localNodes.Length)
            {
                nextNode = 0;
            }
        }

        if (isVertical)
        {
            position.y = position.y + Time.deltaTime * speed * direction;

            anim.SetFloat("Move X", 0);
            anim.SetFloat("Move Y", direction);
        }
        else
        {
            position.x = position.x + Time.deltaTime * speed * direction;

            anim.SetFloat("Move Y", 0);
            anim.SetFloat("Move X", direction);
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
