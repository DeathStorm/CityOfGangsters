using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    { 
        Vector3 playerPosition = gameObject.transform.position;

        if (Input.GetKeyDown(KeyCode.W)) {playerPosition.z += 5;}
        if (Input.GetKeyDown(KeyCode.S)) { playerPosition.z -= 5; }
        if (Input.GetKeyDown(KeyCode.D)) { playerPosition.x += 5; }
        if (Input.GetKeyDown(KeyCode.A)) { playerPosition.x -= 5; }

        gameObject.transform.position = playerPosition;

	}
}
