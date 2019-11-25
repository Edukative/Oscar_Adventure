using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthcontrol : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("object that entred the trigger: " + other);

        PlayerController controller = other.GetComponent<PlayerController>();//
    }
}
