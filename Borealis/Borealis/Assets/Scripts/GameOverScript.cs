using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScript : MonoBehaviour {

    public GameObject GameOver;

	// Use this for initialization
	void Start ()
    {
        GameOver.SetActive(false);
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameOver.SetActive(true);
        }
    }
}

