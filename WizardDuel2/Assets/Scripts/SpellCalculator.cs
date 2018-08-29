using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellCalculator : MonoBehaviour
{
    GameManager gameManager;

    private void Awake()
    {
        gameManager = GameManager.Instance;

    }

    private void Update()
    {
        while (gameManager.spellcastingEnabled)
        {
            this.gameObject.SetActive(true);
        }
        this.gameObject.SetActive(false);
    }

}
