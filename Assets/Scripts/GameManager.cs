using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
    public static event Action ResetTimer = delegate { };
    public static event Action IncreaseSpawnSpeed = delegate { };
    public static event Action Pause = delegate { };

    public static int currentRound;
    public static int maxRounds;

    private void Awake()
    {
        LifeManager.GameOver += doGameOver;
        RoundManager.RoundOver += doRoundOver;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentRound = 1;
        maxRounds = MenuManager.roundsSelected;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void doRoundOver()
    {
        // timer - 0:00, round is over
        // increase currentRound, check if the player finished every round
        currentRound++;
        if(currentRound > maxRounds)
        {
            currentRound = maxRounds;
            doGameOver();
        }
        // set new round timer
        ResetTimer();
        // pause game for 1 minute
        Pause();
        // increase spawn speed
        IncreaseSpawnSpeed();
    }

    public void doGameOver()
    {
        // player lost all lifes or every round has been completed
        SceneManager.LoadScene(2);
    }

    private void OnDestroy()
    {
        LifeManager.GameOver -= doGameOver;
    }
}
