using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayPhase : MonoBehaviour {

    GameManager gameManager;
    Text phaseText;

    private void Start()
    {
        phaseText = GetComponent<Text>();
        gameManager = GameManager.Instance;
    }

    void Update ()
    {
        phaseText.text = "Phase: " + gameManager.phaseKeeper;

	}
}
