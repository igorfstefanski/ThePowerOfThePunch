using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    private TextMeshProUGUI scoreText;

    readonly int TARGET_HIT_POINTS = 50;
    readonly int MAX_MULTIPLIER = 4;
    readonly int MIN_MULTIPLIER = 1;
    readonly float MULTIPLIER_UP = 0.2f;
    readonly float MULTIPLIER_DOWN = 0.4f;

    public static int score;
    float currentMultiplier;

    private void Awake()
    {
        Target.TargetHitCorrectly += AddPoints;
        Target.TargetHitIncorrectly += DecreaseMultiplier;
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        currentMultiplier = MIN_MULTIPLIER;
    }

    private void Update()
    {
        scoreText.text = "SCORE\n" + score.ToString() + "\nMULTIPLIER\nx " + currentMultiplier.ToString();
    }

    public void AddPoints()
    {
        float tempScore = score;
        tempScore += TARGET_HIT_POINTS * currentMultiplier;
        score = (int)tempScore;

        currentMultiplier += MULTIPLIER_UP;
        if (currentMultiplier >= MAX_MULTIPLIER)
        {
            currentMultiplier = MAX_MULTIPLIER;
        }
    }

    public void DecreaseMultiplier()
    {
        currentMultiplier -= MULTIPLIER_DOWN;
        if (currentMultiplier <= MIN_MULTIPLIER)
        {
            currentMultiplier = MIN_MULTIPLIER;
        }
    }

    private void OnDestroy()
    {
        Target.TargetHitCorrectly -= AddPoints;
        Target.TargetHitIncorrectly -= DecreaseMultiplier;
    }
}
