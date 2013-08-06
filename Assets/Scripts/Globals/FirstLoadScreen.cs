using UnityEngine;
using System.Collections;

public class FirstLoadScreen : MonoBehaviour {

	// Use this for initialization
	void Start () 
    {
        Application.LoadLevel("MainMenu");
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    void OnGUI()
    {
        GUI.Label(new Rect(Screen.width / 2 - 200 / 2, Screen.height / 2 - 50 / 2, 200, 50), "THIS IS THE FIRST LOAD SCREEN");
    }
}
