using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum TargetColor {BLUE, RED};

public class Target : MonoBehaviour
{
    public static event Action TargetHitCorrectly = delegate { };
    public static event Action TargetHitIncorrectly = delegate { };
    public TargetColor color;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("HandRed"))
        {
            if(color == TargetColor.RED)
            {
                //add score
                TargetHitCorrectly();
            }
            else
            {
                //subtract a life and decrease multiplier
                TargetHitIncorrectly();
            }
            Hit();
        }
        else if (other.CompareTag("HandBlue"))
        {
            if (color == TargetColor.BLUE)
            {
                //add score
                TargetHitCorrectly();
            }
            else
            {
                //subtract a life and decrease multiplier
                TargetHitIncorrectly();
            }
            Hit();
        }
    }

    void Hit()
    {
        //destroy the target
        Destroy(gameObject);
    }
}
