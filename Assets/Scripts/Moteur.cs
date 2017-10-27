using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Moteur : MonoBehaviour {

    public Player player;
    public CollideBox collideBox;
    private Vector2 x, a;
    private float r;
    private int life;
    private const int maxLife = 50;
    public static bool start = false;
    public static bool gameOver = false;

    public static bool EasyMode = true;



    // Update is called once per frame
    void Update()
    {
        if (gameOver)
            if (Input.GetKey(KeyCode.Space))
            {
                StartGame();
            }
        if (!start)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                StartGame();
            }
        }

        //Victoire ou défaite ?
        else
        {
            x = player.GetPlayerPosition();
            a = collideBox.GetColliderPosition();
            r = collideBox.GetColliderScale() / 2;

            if (Mathf.Pow(x.x - a.x, 2) + Mathf.Pow(x.y - a.y, 2) > Mathf.Pow(r, 2))
            {
                life--;
                if (life < 0)
                {
                    Debug.Log("Finish");
                    EndGame();
                    Score.EndGame();
                }
            }
            else
                life = maxLife;
        }
    }

    void StartGame()
    {
        gameOver = false;
        start = true;
        Time.timeScale = 1;
        life = maxLife;
        player.GetComponent<PlayerController>().enabled = true;
        collideBox.GetComponent<CollideBoxMover>().enabled = true;
        collideBox.ResetThis();
        player.ResetThis();
        Score score = gameObject.AddComponent<Score>();
    }

    void EndGame()
    {
        Debug.Log("Perdu !");
        StopAllCoroutines();
        start = false;
        gameOver = true;
        player.GetComponent<PlayerController>().enabled = false;
        collideBox.GetComponent<CollideBoxMover>().enabled = false;
        Time.timeScale = 0;
    }
}
