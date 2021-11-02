using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player_Move_Proto : MonoBehaviour {

    public int playerSpeed = 10;
    private bool facingRight = true; //if facing right, go true, if left, go false
    public int playerJumpPower = 1250;
    private float moveX;
    public bool isGrounded;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        PlayerMove();

    }

    void PlayerMove()
    {
        //Controls
        moveX = Input.GetAxis("Horizontal"); //calls variable for getting the input from the x - axis
        if (Input.GetButtonDown("Jump") && (isGrounded == true)) //"Jump" by default is the Spacebar
        {
            Jump();
        }
        //Animation
        if (moveX != 0)
        {
            GetComponent<Animator>().SetBool("Position", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("Position", false);
        }
        //Player Direction
        if (moveX < 0.0f && facingRight == true)
        {
            FlipPlayer();
        }
        else if (moveX > 0.0f && facingRight == false)
        {
            FlipPlayer();
        }
        //Physics
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y); //the line of code that gets player to move left and right
    }

    void Jump()
    {
        //Jumping Code
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpPower);
        isGrounded = false;
        GetComponent<Animator>().SetBool("Elevation", true);
    }

    void FlipPlayer()
    {
        facingRight = !facingRight;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
        //The localScale is the variable that controls the direction of the sprite, so originally the head's scale was 0.5, after the player flips, it will be -0.5 and the sprite will flip
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("Player has collided with " + collision.collider.name);
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
            GetComponent<Animator>().SetBool("Elevation", false);
        }
    }

    /*
            if (collision.gameObject.tag == "Enemy") //&& collision.gameObject.tag != "HeadStomper"
        {
            SceneManager.LoadScene("Level1");
			//Debug.Log("Mans is dead");
        }
        if (collision.gameObject.tag == "KillBlock")
        {
            SceneManager.LoadScene("Level1");
        }   
    */

    /*
    void PlayerRaycast ()
    {
        RaycastHit2D hit = Physics2D.Raycast (transform.position, Vector2.down);
        if ((hit.distance > 0.09f) && (hit.collider.tag == "Enemy"))
        {
            Debug.Log("Touched Ground");
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * 50);
           
        }
    }
    */
}
