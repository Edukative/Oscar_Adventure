using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("object that entred the trigger: " + other);

        PlayerController controller = other.GetComponent<PlayerController>();//get the player controller from the other thing collided with the trigger
        if (controller != null)//if the controller retrived is not empty
        {
            // ! the exclamation is a negation value
            controller.ChangeHealth(-1); // call the health funcion lose 1 to the health of the player
        }
    }
}
