using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionCommande : MonoBehaviour {


    //nextConfig is updated after the color transition, in TransitionCouleur.cs
    public bool[] nextConfig { get; set; }
    private bool[] currentConfig { get; set; }
    public PlayerController playerController;

    private float axisV { get; set; }
    private float axisH { get; set; }


    // Use this for initialization
    public void Start () {
        currentConfig = new bool[3] { false, false, false };
	}
	
	// Update is called once per frame
	void Update () {

        if (!currentConfig[0])
        {
            if (!currentConfig[2])
                axisH = GetAxis(0);
            else
                axisH = -GetAxis(0);

            if (!currentConfig[1])
                axisV = GetAxis(1);
            else
                axisV = -GetAxis(1);
        }
        else
        {
           if (!currentConfig[2])
                axisH = GetAxis(1);
            else
                axisH = -GetAxis(1);

            if (!currentConfig[1])
                axisV = GetAxis(0);
            else
                axisV = -GetAxis(0);
        }

        playerController.MoveOnAxis(0, axisH);
        playerController.MoveOnAxis(1, axisV);
	}

    public void Transite()
    {
        currentConfig = new bool[3]
        {
            nextConfig[0],
            nextConfig[1],
            nextConfig[2]
        };
    }

    public float GetAxis(int dimension)
    {
#if UNITY_ANDROID
        if (dimension == 0)
            return 3*Input.acceleration.y;
        //else
         //   return Input.acceleration.z;
        else
            return 3* Input.acceleration.x;


#else
        if (dimension == 1)
            return Input.GetAxis("Horizontal");
        else 
            return Input.GetAxis("Vertical");

#endif
    }






}
