using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class LifeManager : MonoBehaviour
{
    public static event Action GameOver = delegate { };

    private TextMeshProUGUI lifesText;

    int NO_LIFES = 3;
    int lifes;

    private void Awake()
    {
        Target.TargetHitIncorrectly += DecreaseLifes;
        lifesText = GetComponent<TextMeshProUGUI>();
    }

    // Start is called before the first frame update
    void Start()
    {
        lifes = NO_LIFES;
    }

    // Update is called once per frame
    void Update()
    {
        lifesText.text = "LIFES\n" + lifes.ToString();
    }

    public void DecreaseLifes()
    {
        lifes--;
        if (lifes <= 0)
        {
            GameOver();
        }
    }

    private void OnDestroy()
    {
        Target.TargetHitIncorrectly -= DecreaseLifes;
    }
}
