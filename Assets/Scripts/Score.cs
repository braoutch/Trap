using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour {

    private float t = 0;
    private static UnityEngine.UI.Text texte;
    private static UnityEngine.UI.Text texte_H;

    // Use this for initialization
    void Start () {
        texte = GameObject.Find("Score").GetComponent<UnityEngine.UI.Text>();
        texte_H = GameObject.Find("Hscore").GetComponent<UnityEngine.UI.Text>();
        DisplayHighScore();
	}
	
	// Update is called once per frame
	void Update () {
        if (Moteur.start)
            texte.text = ((int)(Time.time - t)).ToString();
    }

    public static void EndGame()
    {
        if (int.Parse(texte.text) > PlayerPrefs.GetInt("Trap-HScore", 0))
        {
            PlayerPrefs.SetInt("Trap-HScore", int.Parse(texte.text));
            DisplayHighScore();
        }
    }

    public static void DisplayHighScore()
    {
        texte_H.text = PlayerPrefs.GetInt("Trap-HScore", 0).ToString();
    }

    internal void ResetThis()
    {
        t = Time.time;
    }
}
