using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellCastingContainer : MonoBehaviour
{
    GameManager gameManager;
    GameObject screenDisplayChild;

    private void Start()
    {
        gameManager = GameManager.Instance;
        screenDisplayChild = transform.GetChild(0).gameObject;
        screenDisplayChild.gameObject.SetActive(true);
    }

    private void Update()
    {
        if (gameManager.spellcastingEnabled)
        {
            screenDisplayChild.gameObject.SetActive(true);
        }
        else
        {
            screenDisplayChild.gameObject.SetActive(false);
        }
    }
}
