using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpeedManager : MonoBehaviour {

     public Player player;
     public CollideBox collideBox;


    private bool selfStart;

	// Use this for initialization
	void Start () {
        ResetThis();
	}
	
	// Update is called once per frame
	void Update () {
        if (Moteur.start)
        {
            if (!selfStart)
                selfStart = true;

            if (collideBox.vitesse < 15)
            {
                collideBox.vitesse *= 1.001f;
                player.vitesse = collideBox.vitesse * 0.015f;
            }
            else if (collideBox.vitesse < 20)
            {
                collideBox.vitesse *= 1.001f;
                player.vitesse *=1.00001f;
            }
        }
        else if (selfStart)
            ResetThis();
	}

    private void ResetThis()
    {
        collideBox.vitesse = 5f;
        selfStart = false;
    }
}
