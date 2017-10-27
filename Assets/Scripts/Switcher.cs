using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switcher : MonoBehaviour {

    private bool selfStart = false;
    private float transitionTime;
    private float transitionTimeDecrease;
    private float transitionSpeed=1f;

    private float initialTime;
    private float lastTransitionTime;

    private int memory = 0;

    public TransitionCouleur transitionCouleur;
    public TransitionCommande transitionCommande;

    private List<bool[]> situations = new List<bool[]>();

    //On en est à combien de transitions?
    private int transitionNumber = 0;

	// Use this for initialization
	void Start () {
        transitionTime = 7f;
        transitionTimeDecrease = 0.95f;

        //Les différentes possibilités d'inversion des commandes
        situations.Add(new bool[3] { false, false, false });
        situations.Add(new bool[3] { false, true, false });
        situations.Add(new bool[3] { false, false, true });
        situations.Add(new bool[3] { false, true, true });
        situations.Add(new bool[3] { true, false, false });
        situations.Add(new bool[3] { true, true, false });
        situations.Add(new bool[3] { true, false, true });
        situations.Add(new bool[3] { true, true, true });
    }

// Update is called once per frame
void Update () {
        if (Moteur.start)
        {
            if (!selfStart)
            {
                selfStart = true;
                initialTime = Time.time;
                lastTransitionTime = Time.time+2;
            }

            if (Time.time - lastTransitionTime >= transitionTime)
            {
                Debug.Log("Let's make a transition");
                MakeTransition();
                lastTransitionTime = Time.time;
            }

        }
        else if (selfStart)
            ResetThis();
	}

    private void MakeTransition()
    {
        switch (transitionNumber)
        {
            case 0:
                int i = UnityEngine.Random.Range(1, 2);
                memory = i;
                transitionCouleur.Transite(transitionSpeed, situations[i]);
                transitionCommande.nextConfig = situations[i];
                break;

            case 1:
                transitionCouleur.Transite(transitionSpeed, situations[0]);
                transitionCommande.nextConfig = situations[0];
                break;

            case 2:
                if (memory == 1)
                {
                    transitionCouleur.Transite(transitionSpeed, situations[2]);
                    transitionCommande.nextConfig = situations[2];
                }

                else
                { 
                    transitionCouleur.Transite(transitionSpeed, situations[1]);
                    transitionCommande.nextConfig = situations[1];
                }
                break;

            case 3:
                transitionCouleur.Transite(transitionSpeed, situations[0]);
                transitionCommande.nextConfig = situations[0];
                break;

            case 4:
                transitionCouleur.Transite(transitionSpeed, situations[3]);
                transitionCommande.nextConfig = situations[3];
                break;
            case 5:
                transitionCouleur.Transite(transitionSpeed, situations[0]);
                transitionCommande.nextConfig = situations[0];
                break;

            case 6:
                transitionCouleur.Transite(transitionSpeed, situations[4]);
                transitionCommande.nextConfig = situations[4];
                break;

            case 7:
                transitionCouleur.Transite(transitionSpeed, situations[0]);
                transitionCommande.nextConfig = situations[0];
                break;

            case 8:
                int j = UnityEngine.Random.Range(1, 2);
                memory = j;
                transitionCouleur.Transite(transitionSpeed, situations[j]);
                transitionCommande.nextConfig = situations[j];
                break;

            case 9:
                if (memory == 1)
                {
                    transitionCouleur.Transite(transitionSpeed, situations[2]);
                    transitionCommande.nextConfig = situations[2];
                }

                else
                {
                    transitionCouleur.Transite(transitionSpeed, situations[1]);
                    transitionCommande.nextConfig = situations[1];
                }
                break;

            case 10:
                transitionCouleur.Transite(transitionSpeed, situations[3]);
                transitionCommande.nextConfig = situations[3];
                break;

            case 11:
                transitionCouleur.Transite(transitionSpeed, situations[7]);
                transitionCommande.nextConfig = situations[7];
                break;

            case 12:
                transitionCouleur.Transite(transitionSpeed, situations[0]);
                transitionCommande.nextConfig = situations[0];
                break;

            default:
                int k = UnityEngine.Random.Range(1, 7);
                transitionCouleur.Transite(transitionSpeed, situations[k]);
                transitionCommande.nextConfig = situations[k];
                break;
        }

        transitionNumber++;
        if (Moteur.EasyMode)
            if (transitionNumber >= 4)
                transitionNumber = 0;
    }

    private void ResetThis()
    {
        transitionNumber = 0;
        transitionCommande.nextConfig = new bool[3] { false, false, false };
        transitionCommande.Start();
        transitionCouleur.Start();
        transitionCouleur.StopAllCoroutines();
        lastTransitionTime = Time.time+2;
       
    }
}
