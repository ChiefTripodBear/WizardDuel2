using UnityEngine;

public class GameManager : MonoBehaviour
{
    //set GameManager as a Singleton
    private static GameManager instance;
    
    public int roundCounter;
    public enum Phase { cast1, peek, cast2, resolve, nextround };
    public Phase phaseKeeper;

    bool player1confirm = false;
    bool player2confirm = false;
    float roundTimer = 10f; //TODO: change this to a game setting later
    public float nextRoundChangeTimer;

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

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        roundCounter = 1;
        phaseKeeper = Phase.cast1;
        nextRoundChangeTimer = Time.fixedTime + roundTimer;
    }

    void Update()
    {
        //rollover to next phase based on timer
        if (nextRoundChangeTimer < Time.fixedTime)
        {
            NextPhase();
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

    //helper method to reset player confirmation buttons and rollover round
    void NextPhase()
    {
        phaseKeeper++;
        if (phaseKeeper == Phase.nextround)
        {
            roundCounter++;
            phaseKeeper = Phase.cast1;
        }
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
