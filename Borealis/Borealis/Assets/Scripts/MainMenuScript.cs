using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour {


    public string start;
    public string controls;
    public string quit;


    private void Awake()
    {
        Cursor.visible = true;

    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void startGame()
    {
        SceneManager.LoadScene(start);
    }

    public void showControls()
    {
        SceneManager.LoadScene(controls);
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
