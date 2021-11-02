using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMove : MonoBehaviour {


    public int EnemySpeed;
    public int XMoveDirection;
    private bool facingRight = true;
	
	// Update is called once per frame
	void Update ()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(XMoveDirection, 0));
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(XMoveDirection, 0) * EnemySpeed;

        if(hit.distance < 0.5f) //was 0.5f
        {
            Flip();         
        }
	}

    void Flip()
    {
        if (XMoveDirection > 0)
        {
            XMoveDirection = -1;
            FlipPlayer();
        }
        else
        {
            XMoveDirection = 1;
            FlipPlayer();
        }
    }

    
    void FlipPlayer()
    {
        facingRight = !facingRight;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
        //The localScale is the variable that controls the direction of the sprite, so originally the head's scale was 0.5, after the player flips, it will be -0.5 and the sprite will flip
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "HeadStomper")
        {
            Destroy(gameObject);
        }
    }

}
