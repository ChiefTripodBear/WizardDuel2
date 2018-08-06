using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    
    int roundCounter;
    enum Phase { cast1, peek, cast2, resolve, nextround };
    Phase phaseKeeper;

    bool player1confirm = false;
    bool player2confirm = false;
    float roundTimer = 10f; //TODO: change this to a game setting later
    float nextRoundChangeTimer;
    
    //TODO: Find text children and update    

    void Start()
    {
        roundCounter = 1;
        phaseKeeper = Phase.cast1;
        nextRoundChangeTimer = Time.fixedTime + roundTimer;
    }

    void Update()
    {
        if (phaseKeeper == Phase.cast1 || phaseKeeper == Phase.cast2)
        {
            if (nextRoundChangeTimer < Time.fixedTime)
            {
                NextPhase();
            }
        }

        if (player1confirm && player2confirm)
        {
            NextPhase();
        }

        if (phaseKeeper == Phase.cast1)
        {
            //enable spellcasting
        }

        if (phaseKeeper == Phase.cast2)
        {
            //enable spellcasting, but check against prior round spell data
        }

        if (phaseKeeper == Phase.peek)
        {
            //pick a random attribute from both players spellcasting and show the other
        }

        if (phaseKeeper == Phase.resolve)
        {
            //run spell calculations
            //apply changes back to players
        }
    }

    void NextPhase()
    {
        phaseKeeper++;
        if (phaseKeeper == Phase.nextround)
        {
            roundCounter++;
            phaseKeeper = Phase.cast1;
        }
        Debug.Log("Round is " + roundCounter);
        Debug.Log("Phase is " + phaseKeeper);
        player1confirm = false;
        player2confirm = false;
        nextRoundChangeTimer = Time.fixedTime + roundTimer;
    }

    public void Player1Confirm()
    {
        player1confirm = true;
    }

    public void Player2Confirm()
    {
        player2confirm = true;
    }
}
