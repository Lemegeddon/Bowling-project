using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreManager : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;


    private int totalScore;

    public int currentThrow { get; private set; }
    public int currentFrame { get; private set; }

    private int[] frames = new int[10];

    private bool isSpare  = false;
    private bool isStrike = false;

    private void Start()
    {
        ResetScore();
    } 
    //set value for our frame score after current throw ball
    public void SetFrameScore(int score)
    {
        //ball1
        if (currentThrow == 1)
        {
            frames[currentFrame - 1] += score;//Setting the right frame index and adding the score value frome the perameter passed 
            //Parallel process to check spare
            if (isSpare)
            {
                frames[currentFrame - 2] += score;
                isSpare = false;
            }
            //-----------------------------------------------------------
            if (score == 10)
            {
                if (currentFrame == 10)
                {
                    currentThrow++; //wait ball 2
                }
                else
                {
                    isStrike = true;
                    currentFrame++; //Move to next frame since full marks obtained 
                }
                //reset all Pins in GameManager
                gameManager.ResetAllPins();
            }
            else
            {
                currentThrow++; // wait Ball 2
            }

            return;
        }
        //Ball 2
        if(currentThrow == 2)
        {
            frames[currentFrame] += score;

            //Parrallel process to check strike 
            if (isStrike)
            {
                frames[currentFrame - 2] += frames[currentFrame - 1];
                isStrike = false;
            }
            //---------------------------------------
            if (frames[currentFrame - 1] == 10)
            {
               if(currentFrame == 10)
                {
                    currentThrow++;
                }
                else
                {
                    isSpare = true;
                    currentFrame++;
                    currentThrow = 1;

                }
               
            }
            else
            {
               if(currentFrame == 10)
                {
                    //End all throws 
                    currentThrow = 0;
                    currentThrow = 0;
                    return;
                }
                else
                {
                    currentFrame++;
                    currentThrow = 1;
                }

            }
            //Todo GameManager to reset all pins
            gameManager.ResetAllPins();

            return; 
        }

        if (currentThrow == 3 && currentFrame == 10)
        {
            frames[currentFrame - 1] += score;

            //End of all throws
            currentThrow = 0;
            currentFrame = 0;

            return;
        }
    }

    public int CalculateTotalScore()
    {
        totalScore = 0;
        foreach(var frame in frames)
        {
            totalScore += frame;
        }
        return totalScore;

    }
    private void ResetScore()
    {
        totalScore = 0;
        currentFrame = 1;
        currentThrow = 1;
        frames = new int[10];
    }
   
}
 