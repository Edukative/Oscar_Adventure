using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed; //speed variable
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal"); //get the horizontal input
        float vertical = Input.GetAxis("Vertical"); //get the vertical input

        Vector2 position = transform.position; // makes a vector based on current position

        position.x = position.x + speed * horizontal * Time.deltaTime; //the position is equal to the same position but a little bit bigger
        position.y = position.y + speed * vertical * Time.deltaTime;

        transform.position = position; //saves this position to the current one

        Debug.Log(horizontal); //see what values are u sending when pressing the keys
        Debug.Log(vertical); //see what values are u sending when pressing the keys
    }
}
