using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalScoreManager : MonoBehaviour
{
    private TextMeshProUGUI scoreText;
    int finalScore;

    private void Awake()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    // Start is called before the first frame update
    void Start()
    {
        finalScore = ScoreManager.score;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Your final score:\n" + finalScore.ToString();
    }
}
