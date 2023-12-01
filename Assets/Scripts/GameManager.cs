using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Player_controler player_Controler;

    [SerializeField]
    private scoreManager scoreManager;

    [SerializeField]
    private UIManager UIManager;

    [SerializeField]
    private Pin[] pins;

    private bool isGamePlaying = false; 
    // Start is called before the first frame update
    void Start()
    {
        startGame();
    }

    public void startGame()
    {
        isGamePlaying = true;
        
        //Get First Throw
        player_Controler.StartThrow();
    } 
    // Update is called once per frame
    void Update()
    {
        //if (isGamePlaying == false && Input.GetKeyUp(KeyCode.X))
        //{
            //startGame();
        //}
    }

    public void SetNextThrow()
    {

        Invoke(nameof(nextThrow), 3.0f);

        

    }

    void nextThrow()
    {
        int fallenPins = CalculateFallenPins();
        scoreManager.SetFrameScore(fallenPins);
        if (scoreManager.currentFrame == 0)
        {
            UIManager.ShowGameOver(scoreManager.CalculateTotalScore());
            return;
        }
        //calculateFrame total for UI
        int frameTotal = 0;
        for (int i = 0; i < scoreManager.currentFrame-1; i++)
        {
            frameTotal += scoreManager.GetFrameScore()[i];
            UIManager.SetFrameTotal(i, frameTotal);
        }
            //Get the ball to the start position for throwing
            player_Controler.StartThrow();
        

    }
    public int CalculateFallenPins()
    {
        int count = 0;
        foreach (Pin pin in pins)
        {
            if (pin.isFallen)
            {
                count++;
                pin.gameObject.SetActive(false);
            }
        }
        
        Debug.Log("Total Fallen Pins" + count);
        return count;
    }

    public void ResetAllPins()
    {
        foreach(Pin pin in pins)
        {
            pin.ResetPin();
        }

        
    }

}
