using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Player_controler player_Controler;

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
        SetNextThrow();
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
        CalculateFallenPins();
        //Get the ball to the start position for throwing

        player_Controler.StartThrow();

    }

    public void CalculateFallenPins()
    {
        int count = 0;
        foreach (Pin pin in pins)
        {
            if (pin.isFallen)
            {
                count++;
            }
        }
        
        Debug.Log("Total Fallen Pins" + count);

    }

}
