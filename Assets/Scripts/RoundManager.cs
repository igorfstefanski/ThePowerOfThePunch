using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class RoundManager : MonoBehaviour
{
    public static event Action RoundOver = delegate { };

    private TextMeshProUGUI roundInfoText;

    readonly float ROUND_TIME = 180;
    float currentTime;
    bool isGamePaused;

    private void Awake()
    {
        GameManager.ResetTimer += ResetTimer;
        GameManager.Pause += Pause;
        PauseManager.UnPause += UnPause;
        roundInfoText = GetComponent<TextMeshProUGUI>();
    }

    // Start is called before the first frame update
    void Start()
    {
        ResetTimer();
        UnPause();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGamePaused)
        {
            currentTime -= Time.deltaTime;
            if (currentTime <= 0)
            {
                // timer - 0:00, round is over
                RoundOver();
            }

            // calculate minutes and seconds from current time
            float minutes = Mathf.FloorToInt(currentTime / 60);
            float seconds = Mathf.FloorToInt(currentTime % 60);

            roundInfoText.text = "ROUND " + GameManager.currentRound.ToString() + "/" + GameManager.maxRounds.ToString() + "\n" + String.Format("{0:0}:{1:00}", minutes, seconds);
        }
    }

    public void ResetTimer()
    {
        currentTime = ROUND_TIME;
    }

    public void Pause()
    {
        isGamePaused = true;
    }

    public void UnPause()
    {
        isGamePaused = false;
    }

    private void OnDestroy()
    {
        GameManager.ResetTimer -= ResetTimer;
        GameManager.Pause -= Pause;
        PauseManager.UnPause -= UnPause;
    }
}
