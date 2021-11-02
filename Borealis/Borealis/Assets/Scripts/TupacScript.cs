using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TupacScript : MonoBehaviour {

    public Transform firePoint;
    public GameObject bulletPrefab;
    public float Timer = 1f;
    public float WaitTimer = 3f;


	// Update is called once per frame
	void Update ()
    {
        Timer += Time.deltaTime;
        if (Timer > WaitTimer)
        {
            GetComponent<Animator>().SetBool("Aim", true);
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Timer = 0;
        }
        else if(Timer < WaitTimer - 1)
        {
            GetComponent<Animator>().SetBool("Aim", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "HeadStomper")
        {
            Destroy(gameObject);
        }
    }
}
