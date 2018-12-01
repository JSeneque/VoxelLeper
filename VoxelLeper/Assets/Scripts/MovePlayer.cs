using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour {
    public Transform Player;

	// Use this for initialization
	void Start () {
        MoveTo();
	}
	
	// Update is called once per frame
	void Update () {
        MoveTo();
    }

    void MoveTo()
    {
        transform.position = new Vector3(Player.position.x, Player.position.y / 2.0f, Player.position.z);
        
    }

    
}
