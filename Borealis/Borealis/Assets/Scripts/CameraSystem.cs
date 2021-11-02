using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSystem : MonoBehaviour {

    private GameObject player;
    public float xMin;
    public float xMax;
    public float yMin;
    public float yMax;

	// Use this for initialization
	void Start ()
    {
        player = GameObject.FindGameObjectWithTag ("Player"); //this allows us to interact with the object that the player is controlling.
	}
	
	// Update is called once per frame
	void LateUpdate ()
    {
        float x = Mathf.Clamp (player.transform.position.x, xMin, xMax); // the max and minimum value the camera can be in the x axis
        float y = Mathf.Clamp (player.transform.position.y, yMin, yMax); // the max and minimum value the camera can be in the y axis
        gameObject.transform.position = new Vector3(x, y, gameObject.transform.position.z); // moves the camera along with the player gameobject
    }
}
