using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class CountScore : MonoBehaviour
{

    public Text Scoreboard;
    public GameObject Ball;
    public static bool canAddScore = true;
    private int Paddle1_Score = 0;
    private int Paddle2_Score = 0;

    // Start is called before the first frame update
    void Start()
    {
        Ball = GameObject.Find("Ball");
    }

    // Update is called once per frame
    void Update()
    {
        if (Ball.transform.position.x >= 20f && canAddScore)
        {
            canAddScore = false;
            Paddle1_Score++;

        }
        if (Ball.transform.position.x <= -20f && canAddScore)
        {
            canAddScore = false;
            Paddle2_Score++;
        }

        if (Paddle1_Score >= 7)
        {
            SceneManager.LoadScene(2);
        }
        if (Paddle2_Score >= 7)
        {
            SceneManager.LoadScene(3);
        }
        Scoreboard.text = Paddle1_Score.ToString() + " - " + Paddle2_Score;

    }
}
