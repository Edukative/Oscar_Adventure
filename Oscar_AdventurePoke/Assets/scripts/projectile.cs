﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    Rigidbody2D projectileRB2D;

    private void Awake()
    {
        projectileRB2D = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Launch (Vector2 direction, float force)
    {
        projectileRB2D.AddForce(direction * force);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("projectile Collision with " + collision.gameObject);
        Destroy(gameObject);
    }
}
