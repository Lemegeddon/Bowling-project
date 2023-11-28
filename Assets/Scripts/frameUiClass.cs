using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class frameUiClass : MonoBehaviour
{
    [SerializeField]
    private TMP_Text txtFrame, txtThrow1, txtThrow2, txtThrow3, txtTotal;
    [SerializeField]
    private bool isFinalFrame;

    int frameScore = 0;
    public void UpdateScore(int throwNumber, int score)
    {
        if(throwNumber == 1)
        {
            if(score == 10)
            {
                txtThrow1.text = "";
                txtThrow2.text = "x";
            }
            else
            {
                txtThrow1.text = score.ToString();
                frameScore += score;
            }
        }
    }
}
