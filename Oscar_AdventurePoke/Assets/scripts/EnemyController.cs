﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed; //speed of enemi
    Rigidbody2D rb2D;
    public bool isVertical;
    //waypoint values
    public GameObject wayPoints;
    public Vector2[] localNodes;
    //timer values
    float timer;
    int direction = 1;
    public float changeTime = 3.0f;

    Animator anim;

    bool broken = true;
    
   
    int currentNode;
    int nextNode;
    Vector2 Velocity;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>(); //get teh enemy's RigidBody  
        timer = changeTime; //set teh timer
        anim = GetComponent<Animator>();

        localNodes = new Vector2[wayPoints.transform.childCount];

        for (int i = 0; i <= wayPoints.transform.childCount - 1; ++i)
        {
            Transform child = wayPoints.transform.GetChild(i).transform;
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
        UpdateAnimations(wayPointDirection);
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


        Velocity = wayPointDirection.normalized * dist;

        rb2D.MovePosition(rb2D.position + Velocity);

       /*if (isVertical)
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
            */

        //rb2D.MovePosition(position);
    }

    void UpdateAnimations (Vector2 direction)
    {
        anim.SetFloat("Move X", direction.x);
        anim.SetFloat("Move Y", direction.y);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        PlayerController player = other.gameObject.GetComponent<PlayerController>();

        if (player !=null)
        {
            player.ChangeHealth(-1);
        }
    }

    public void Fix()
    {
        broken = false;
        rb2D.simulated = false;
        anim.SetBool("PAIN PLZHELP", true);
    }
}
