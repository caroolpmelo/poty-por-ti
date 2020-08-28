using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private int score = 0;
    private int hiscore = 100; // min score

    [SerializeField]
    private Text scoreTxt;
    [SerializeField]
    private Text hiscoreTxt;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    void Start()
    {
        scoreTxt.text = "Score: " + score;
        hiscoreTxt.text = "Target: " + hiscore;
    }

    void Update()
    {
        if (score >= hiscore)
        {
            Debug.Log("VENCEU");
            AddHiscore();
        }
    }

    public void AddScore()
    {
        score += 10;
        scoreTxt.text = "Score: " + score;
    }

    private void AddHiscore()
    {
        hiscore += 100;
        hiscoreTxt.text = "Target: " + hiscore;
    }

    public static ScoreManager Instance { get; private set; }
}
