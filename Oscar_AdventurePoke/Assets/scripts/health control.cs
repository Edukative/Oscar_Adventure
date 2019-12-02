using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthcontrol : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("object that entred the trigger: " + other);

        PlayerController controller = other.GetComponent<PlayerController>();//get the player controller from the other thing collided with the trigger
        if (controller != null)//if the controller retrived is not empty
        {
            // ! the exclamation is a negation value
            controller.CangeHealth(1); // call the health funcion and add 1 to the health of the player
            Destroy(gameObject); // Destroys all the game object and this script too!
        }
    }
}
