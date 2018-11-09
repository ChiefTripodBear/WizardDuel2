using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActiveSpellText : MonoBehaviour
{
    SpellCalculator spellCalc;
    Text spellName;
    Text forceValue;
    Text pierceValue;
    Text toughnessValue;
    Text resistValue;
    Text offensiveTotal;
    Text defensiveTotal;
    Text spellCost;


	// Use this for initialization
	void Start ()
    {
        spellCalc = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<SpellCalculator>();
        spellName = gameObject.transform.Find("ActiveSpell").GetComponent<Text>();
        forceValue = gameObject.transform.Find("ForceValue").GetComponent<Text>();
        pierceValue = gameObject.transform.Find("PierceValue").GetComponent<Text>();
        toughnessValue = gameObject.transform.Find("ToughnessValue").GetComponent<Text>();
        resistValue = gameObject.transform.Find("ResistanceValue").GetComponent<Text>();
        offensiveTotal = gameObject.transform.Find("OffensiveTotal").GetComponent<Text>();
        defensiveTotal = gameObject.transform.Find("DefensiveTotal").GetComponent<Text>();
        spellCost = gameObject.transform.Find("SpellCost").GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (spellCalc.activeSpell != null)
        {
            spellName.text = spellCalc.activeSpell.ToString();
        }
        else
        {
            spellName.text = "No Active Spell";
        }

        forceValue.text = "Force: " + Math.Round(spellCalc.force, 2);
        pierceValue.text = "Pierce: " + Math.Round(spellCalc.pierce, 2);
        toughnessValue.text = "Toughness: " + Math.Round(spellCalc.toughness, 2);
        resistValue.text = "Resistance: " + Math.Round(spellCalc.resistance, 2);
        offensiveTotal.text = "Offensive Power: " + Math.Round(spellCalc.offensiveValues, 2);
        defensiveTotal.text = "Defensive Power: " + Math.Round(spellCalc.defensiveValues, 2);
        spellCost.text = "Spell Cost: " + Math.Round(spellCalc.spellCost, 2);
	}
}
