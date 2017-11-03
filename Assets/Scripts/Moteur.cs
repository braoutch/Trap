using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Moteur : MonoBehaviour {

    public Player player;
    public CollideBox collideBox;
    private Vector2 x, a;
    private float r;
    private float life;
    public float maxLife = 50;
    public static bool start = false;
    public static bool gameOver = false;
    private Score score;
    public static bool EasyMode = true;

    private void Awake()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        score = gameObject.GetComponent<Score>();
    }




    // Update is called once per frame
    void Update()
    {
#if UNITY_ANDROID
        if (gameOver)
            if (Input.touchCount >= 1)
                StartGame();

        if (!start)
        {
            if (Input.touchCount >= 1)
                StartGame();
        }
        else
            CheckForEnd();


#else
        if (gameOver)
            if (Input.GetKey(KeyCode.Space))
                StartGame();

        if (!start)
        {
            if (Input.GetKey(KeyCode.Space))
                StartGame();
        }
        else
            CheckForEnd();
#endif
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
        score.ResetThis();
    }

    void EndGame()
    {
        Debug.Log("Perdu !");
        StopAllCoroutines();
        start = false;
        gameOver = true;
        Score.EndGame();
        player.GetComponent<PlayerController>().enabled = false;
        collideBox.GetComponent<CollideBoxMover>().enabled = false;
        Time.timeScale = 0;
    }

    void CheckForEnd()
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
        {
            maxLife -= (maxLife - life) / 10f;
            life = maxLife;
        }
    }
}
