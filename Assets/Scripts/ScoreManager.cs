using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private int score = 0;
    private int hiscore = 100; // min score

    [SerializeField]
    private Text scoreTxt;

    void Start()
    {
        scoreTxt.text = "Score: ";
    }

    void Update()
    {
        if (score >= hiscore)
        {
            Debug.Log("VENCEU");
        }
    }

    public void AddScore()
    {
        score += 10;
        scoreTxt.text = "Score: " + score;
    }
}
