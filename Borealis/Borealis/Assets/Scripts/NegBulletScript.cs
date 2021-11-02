using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NegBulletScript : MonoBehaviour {

    public float BulletMaxPos;
    public float BulletSpeed;
    public Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {
        rb.velocity = transform.right * BulletSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        KillBullet();
    }

    void KillBullet()
    {
        if (gameObject.transform.position.x > BulletMaxPos)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
        if(collision.gameObject.tag == "KillBlock")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "BulletKiller")
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BulletKiller"))
        {
            Destroy(gameObject);
        }
    }
}
