using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class frameUiClass : MonoBehaviour
{
    [SerializeField]
    private TMP_Text txtFrame, txtThrow1, txtThrow2, txtThrow3, txtTotal;
    [SerializeField]
    private bool isFinalFrame;

    int frameScore = 0;
    public void UpdateScore(int throwNumber, int score)
    {
        if (!isFinalFrame)
        {
            if (throwNumber == 1)
            {
                if (score == 10)
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
            else if (throwNumber == 2)
            {
                frameScore += score;
                if (frameScore == 10)
                {
                    txtThrow2.text = "/";
                }
                else
                {
                    txtThrow1.text = score.ToString();

                }
            }
        }
        else
        {
            if (throwNumber == 1)
            {
                if (score == 10)
                {
                    txtThrow1.text = "X";
                }
                else
                {
                    txtThrow1.text = score.ToString();
                    frameScore += score;
                }
            }
            else if (throwNumber == 2)
            {
                frameScore += score;
                if (frameScore == 10)
                {
                    txtThrow2.text = "/";
                }
                else
                {
                    txtThrow2.text = score.ToString();

                }
            }
            else if (throwNumber == 3)
            {
                //if (score == 10)
                //{
                //    txtThrow3.text = "x";
                //}
                //else
                //{
                //    txtThrow3.text = score.ToString();
                //}

                txtThrow3.text = score == 10? "X" : score.ToString();
            }
        }  
    }
    public void updateTotale(int total)
    {
        txtTotal.text = total.ToString();
    }
    public void SetFrame(int total)
    {
        txtFrame.text = total.ToString();
        txtThrow1.text = "";
        txtThrow2.text = "";
        txtTotal.text = "";

        if (isFinalFrame)
            txtThrow3.text = "";
        
    }
}
