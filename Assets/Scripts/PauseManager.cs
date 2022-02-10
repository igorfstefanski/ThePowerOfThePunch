using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class PauseManager : MonoBehaviour
{
    public static event Action UnPause = delegate { };

    private TextMeshProUGUI pauseText;

    readonly float PAUSE_TIME = 60;
    float currentTime;
    bool isGamePaused;

    private void Awake()
    {
        GameManager.Pause += Pause;
        pauseText = GetComponent<TextMeshProUGUI>();
    }

    // Start is called before the first frame update
    void Start()
    {
        currentTime = 0;
        isGamePaused = false;
        pauseText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGamePaused)
        {
            currentTime -= Time.deltaTime;
            if (currentTime <= 0)
            {
                // timer - 0:00, pause is over
                isGamePaused = false;
                pauseText.enabled = false;
                UnPause();
            }

            // calculate minutes and seconds from current time
            float minutes = Mathf.FloorToInt(currentTime / 60);
            float seconds = Mathf.FloorToInt(currentTime % 60);

            pauseText.text = "BREAK\n" + String.Format("{0:0}:{1:00}", minutes, seconds);
        }
    }

    public void Pause()
    {
        isGamePaused = true;
        ResetTimer();
        pauseText.enabled = true;
    }

    public void ResetTimer()
    {
        currentTime = PAUSE_TIME;
    }

    private void OnDestroy()
    {
        GameManager.Pause -= Pause;
    }
}
