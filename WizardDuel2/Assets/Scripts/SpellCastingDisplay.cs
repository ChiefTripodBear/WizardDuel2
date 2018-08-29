using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellCastingDisplay : MonoBehaviour
{
    bool lastSpellCastFlag;
    GameManager gameManager;

    private void Awake()
    {
        this.gameObject.SetActive(true);
    }

    private void Start()
    {
        gameManager = GameManager.Instance;
    }

    private void Update()
    {
        if (!this.gameObject.activeInHierarchy && gameManager.spellcastingEnabled)
        {
            this.gameObject.SetActive(true);
        }
        else if (!this.gameObject.activeInHierarchy && !gameManager.spellcastingEnabled)
        {
            this.gameObject.SetActive(false);
        }
    }
}
