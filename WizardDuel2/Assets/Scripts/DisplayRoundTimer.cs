using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayRoundTimer : MonoBehaviour {

    GameManager gameManager;
    Text roundTimerText;

    private void Start()
    {
        roundTimerText = GetComponent<Text>();
        gameManager = GameManager.Instance;
    }

    void Update ()
    {
        roundTimerText.text = ((int)(gameManager.nextRoundChangeTimer - Time.fixedTime)).ToString();

	}
}
