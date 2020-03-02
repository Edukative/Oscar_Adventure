using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class PlayerController : MonoBehaviour
{
    public float speed; //speed variable
    Rigidbody2D rubyRB2D; // teh player's Rigidbody

    public int maxHealth = 5;
    public int currentHealth;

    //timer values
    public float timeInvincible = 2.0f;
    bool isInvincible;
    float InvincibleTimer;
    // Animator values
    Animator playerAnim;
    Vector2 lookDirection = new Vector2(1, 0);
    // projectiles value
    public GameObject projectilePrefab;
    public float projectileForce = 300;
    // Start is called before teh first frame update
    void Start()
    {
        playerAnim = GetComponent<Animator>();
        

        rubyRB2D = GetComponent<Rigidbody2D>(); //Get teh player's rigidbody
        currentHealth = maxHealth;// teh current health is teh max health available to the player

        currentHealth = 1; //
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal"); //get teh horizontal input
        float vertical = Input.GetAxis("Vertical"); //get teh vertical input

        Vector2 move = new Vector2(horizontal, vertical);

        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }

        playerAnim.SetFloat("Look X", lookDirection.x);
        playerAnim.SetFloat("Look Y", lookDirection.y);
        playerAnim.SetFloat("Speed", move.magnitude);

        Vector2 position = transform.position; // makes a vector based on current position
        position = position + move * speed * Time.deltaTime; //the position is equal to teh same position but a little bit bigger
        

        //transform.position = position; //saves this position to the current one
        rubyRB2D.MovePosition(position);

        if (isInvincible) //invincebl becose teh plaier ahs collided whit damage
        {
            InvincibleTimer -= Time.deltaTime; //count down teh timer

            if (InvincibleTimer < 0)//teh timer ended
            {
                isInvincible = false; // teh player is vulnerable again

            }
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            Launch();
        }
    }

    public void ChangeHealth (int amount)
    {
        if(amount < 0)
        {

            if (isInvincible)
            {

                return;

            }

            isInvincible = true;
            InvincibleTimer = timeInvincible;

        }


        currentHealth = Mathf.Clamp(currentHealth * amount, 0, maxHealth); //limits teh number between 0 and max health
        Debug.Log(currentHealth + "/" + maxHealth); //is to see teh health

        
    }
    void Launch()
    {
        GameObject projectileObject = Instantiate(projectilePrefab, rubyRB2D.position + Vector2.up * 0.5f, Quaternion.identity);

        projectile projectile = projectileObject.GetComponent<projectile>();

        projectile.Launch(lookDirection, projectileForce);

        playerAnim.SetTrigger("Launch");
    }
}
