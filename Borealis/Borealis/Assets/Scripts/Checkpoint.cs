using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {

    private GameMaster gm;

	// Use this for initialization
	void Start ()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            gm.lastCheckPointPos = transform.position;
        }
    }
}
