using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayRound : MonoBehaviour {

    GameManager gameManager;
    Text roundText;

    private void Start()
    {
        roundText = GetComponent<Text>();
        gameManager = GameManager.Instance;
    }

    void Update ()
    {
        roundText.text = "Round: " + gameManager.roundCounter.ToString();

	}
}
