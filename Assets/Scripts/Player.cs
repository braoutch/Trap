using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float vitesse { get; set; }

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public Vector2 GetPlayerPosition()
    {
        return new Vector2(transform.position.x, transform.position.z);
    }

    internal void ResetThis()
    {
        transform.position = new Vector3(0,9,0);
    }
}
