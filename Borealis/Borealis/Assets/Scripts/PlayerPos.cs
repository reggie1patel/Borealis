using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPos : MonoBehaviour {

    private GameMaster gm;

    // Use this for initialization
    void Start ()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        transform.position = gm.lastCheckPointPos;
	}
	
	// Update is called once per frame
	void Update ()
    {
    
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (collision.gameObject.tag == "KillBlock")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (collision.gameObject.tag == "XGrave")
        {
            Destroy(gameObject);
            //unhide the GAME OVER sprite here, refer to EnemyAI script.
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("KillBlock"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (other.gameObject.tag == "FinishLevel1" && gameObject.transform.position.x > 160)
        {
            SceneManager.LoadScene("Level2");
        }
        if (other.gameObject.tag == "FinishLevel2" && gameObject.transform.position.x > 160)
        {
            SceneManager.LoadScene("Level3");
        }
        if (other.gameObject.tag == "FinishLevel3")
        {
            SceneManager.LoadScene("Final");
        }
    }
}
