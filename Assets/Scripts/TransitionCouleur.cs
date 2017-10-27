using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TransitionCouleur : MonoBehaviour {

    public Renderer[] sol = new Renderer[4];
    int i = 0;
    private List<bool[]> situations = new List<bool[]>();
    private Color red1, red2, blue1, blue2;
    public TransitionCommande transitionCommande;

	// Use this for initialization
	public void Start () {

        red1 = new Color(0.2f, 0.2f, 0.2f);
        red2 = new Color(0.8f, 0f, 0f);
        blue1 = new Color(0.3f, 0.3f, 0.3f);
        blue2 = new Color(0f, 0f,0.8f );

        sol[0].material.color = red1;
        sol[1].material.color = blue1;
        sol[2].material.color = red1;
        sol[3].material.color = blue1;

        //Les différentes possibilités d'inversion des commandes
        //situations.Add(new bool[3] { false, false, false });
        //situations.Add(new bool[3] { false, true,  false });
        //situations.Add(new bool[3] { false, false, true  });
        //situations.Add(new bool[3] { false, true,  true  });
        //situations.Add(new bool[3] { true,  false, false });
        //situations.Add(new bool[3] { true,  true,  false });
        //situations.Add(new bool[3] { true,  false, true  });
        //situations.Add(new bool[3] { true,  true,  true  });
    }


    private void Update()
    {

        //if (Input.GetKeyDown(KeyCode.KeypadEnter))
        //{
        //    Transite(1.0f, situations[i]);
        //    Debug.Log("Let's change colors with " +i);

        //    i++;
        //    if (i >= situations.Count)
        //        i = 0;

        //}
    }

    public void Transite(float speed, bool[] b)
    {
        //l'ordre des booléens
        bool InverseHV  = b[0]; //inversion des commandes
        bool reverseH   = b[1]; //inversion d'un axe
        bool reverseV   = b[2]; //inversion de l'autre axe

        if (!InverseHV && !reverseH && !reverseV)
            LaunchCoroutines(blue1, red1, speed);

        if (!InverseHV && reverseH && !reverseV)
            LaunchCoroutines(blue2, red1, speed);

        if (!InverseHV && !reverseH && reverseV)
            LaunchCoroutines(blue1, red2, speed);

        if (!InverseHV && reverseH && reverseV)
            LaunchCoroutines(blue2, red2, speed);

        if (InverseHV && !reverseH && !reverseV)
            LaunchCoroutines(red1, blue1, speed);

        if (InverseHV && reverseH && !reverseV)
            LaunchCoroutines(red2, blue1,speed);

        if (InverseHV && !reverseH && reverseV)
            LaunchCoroutines(red1, blue2, speed);

        if (InverseHV && reverseH && reverseV)
            LaunchCoroutines(red2,blue2, speed);
    }

    void LaunchCoroutines(Color color1, Color color2, float speed)
    {
        //color2 is vertical, color1 is horizontal
        Debug.Log("Changement de couleur");
        StartCoroutine(ChangeColors(0, color1, speed));
        StartCoroutine(ChangeColors(1, color2, speed));
        StartCoroutine(ChangeColors(2, color1, speed));
        StartCoroutine(ChangeColors(3, color2, speed));
    }


    IEnumerator ChangeColors(int index, Color newColor, float speed)  //0 for topleft
                                                                     //1 for topright
                                                                     //2 for botright
                                                                     //3 for botleft
    {
        Color oldColor = sol[index].material.color;
        sol[index].material.color = newColor;
        yield return new WaitForSeconds(0.55f * speed);
        sol[index].material.color = oldColor;
        yield return new WaitForSeconds(0.4f * speed);
        sol[index].material.color = newColor;
        yield return new WaitForSeconds(0.35f * speed);
        sol[index].material.color = oldColor;
        yield return new WaitForSeconds(0.25f * speed);
        sol[index].material.color = newColor;
        yield return new WaitForSeconds(0.20f * speed);
        sol[index].material.color = oldColor;
        yield return new WaitForSeconds(0.15f * speed);
        sol[index].material.color = newColor;
        yield return new WaitForSeconds(0.15f * speed);
        sol[index].material.color = oldColor;
        yield return new WaitForSeconds(0.15f * speed);
        sol[index].material.color = newColor;
        yield return new WaitForSeconds(0.15f * speed);
        sol[index].material.color = oldColor;
        yield return new WaitForSeconds(0.15f * speed);
        sol[index].material.color = newColor;
        yield return new WaitForSeconds(0.15f * speed);
        sol[index].material.color = oldColor;
        yield return new WaitForSeconds(0.15f * speed);
        sol[index].material.color = newColor;
        yield return new WaitForSeconds(0.15f * speed);
        sol[index].material.color = oldColor;
        yield return new WaitForSeconds(0.15f * speed);
        sol[index].material.color = newColor;
        if (index == 0)   //Pour le lancer qu'une seule fois
            transitionCommande.Transite();
    }

    void ChangeColors1(int index, Color newColor, float speed)
    {
        Color oldColor = sol[index].material.color;
        Gradient g;
        GradientColorKey[] gck;
        GradientAlphaKey[] gak;

        //Let's do the magic
        g = new Gradient();
        gck = new GradientColorKey[4];
        gck[0].color = oldColor;
        gck[0].time = 0.0F;
        gck[1].color = newColor;
        gck[1].time = 0.5F;
        gck[2].color = oldColor;
        gck[2].time = 0.7F;
        gck[3].color = newColor;
        gck[3].time = speed;

        gak = new GradientAlphaKey[2];
        gak[0].alpha = 1.0F;
        gak[0].time = 0.0F;
        gak[1].alpha = 1.0F;
        gak[1].time = speed;
        g.SetKeys(gck, gak);
    }
}
