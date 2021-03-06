﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region singleton setup
    private static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            return instance;
        }

        set
        {
            instance = value;
        }
    }

    #endregion

    #region Round and Phase variables
    /// <summary>
    /// Round and Phase variables
    /// </summary>
    public int roundCounter;
    public enum Phase { cast1, peek, cast2, resolve, nextround };
    public Phase phaseKeeper;
    bool player1confirm = false;
    bool player2confirm = false;
    float roundTimer = 30f; //TODO: change this to a game setting later
    public float nextRoundChangeTimer;

    List<ElementButtonSelection> elementButtons;
    List<TypeButtonSelection> typeButtons;
    List<PowerSlider> powerSliders;
    #endregion

    public bool spellcastingEnabled = false;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
    }

    void Start()
    {
        //initialise round and phase
        roundCounter = 1;
        phaseKeeper = Phase.cast1;
        nextRoundChangeTimer = Time.fixedTime + roundTimer;

        //find all button selection objects and add them to a list
        elementButtons = new List<ElementButtonSelection>(FindObjectsOfType<ElementButtonSelection>());
        typeButtons = new List<TypeButtonSelection>(FindObjectsOfType<TypeButtonSelection>());
        powerSliders = new List<PowerSlider>(FindObjectsOfType<PowerSlider>());
    }

    void Update()
    {

        ProcessNextPhase();

        if (phaseKeeper == Phase.cast1)
        {
            spellcastingEnabled = true;
        }

        if (phaseKeeper == Phase.cast2)
        {
            spellcastingEnabled = true;
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

    //helper method to reset player confirmation buttons and rollover round
    void ProcessNextPhase()
    {
        if ((player1confirm && player2confirm) || (nextRoundChangeTimer < Time.fixedTime))
        {
            phaseKeeper++;
            if (phaseKeeper == Phase.nextround)
            {
                roundCounter++;
                phaseKeeper = Phase.cast1;
                //loop through our buttons and unselect all elements
                elementButtons.ForEach(elementButtons => elementButtons.UnselectButtons());
                typeButtons.ForEach(typeButtons => typeButtons.UnselectButtons());
                powerSliders.ForEach(powerSliders => powerSliders.ResetPowerMeter());
            }
            player1confirm = false;
            player2confirm = false;
            spellcastingEnabled = false;
            nextRoundChangeTimer = Time.fixedTime + roundTimer;
        }
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
