using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Player player;



    public void MoveOnAxis(int dimension, float f)
    {
        if (Moteur.start)
        {
            if (dimension == 0)
                player.transform.Translate(new Vector3(0, 0, f * player.vitesse));

            if (dimension == 1)
                player.transform.Translate(new Vector3(f * player.vitesse, 0, 0));
        }
    }





    public void FilterInput()
    {

    }


}
