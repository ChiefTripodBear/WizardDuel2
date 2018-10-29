using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActiveSpellText : MonoBehaviour
{
    SpellCalculator spellCalc;
    Text thisText;


	// Use this for initialization
	void Start ()
    {
        spellCalc = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<SpellCalculator>();
        thisText = this.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (spellCalc.activeSpell != null)
        {
            thisText.text = spellCalc.activeSpell.ToString();
        }
        else
        {
            thisText.text = "No Spell";
        }
	}
}
