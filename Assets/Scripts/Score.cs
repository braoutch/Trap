using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour {

    private float t = 0;
    private UnityEngine.UI.Text texte;
    // Use this for initialization
    void Start () {
        texte = GameObject.Find("Score").GetComponent<UnityEngine.UI.Text>();
        t = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        if (Moteur.start)
            texte.text = ((int)(Time.time - t)).ToString();
    }

    public static void EndGame()
    {

    }
}
