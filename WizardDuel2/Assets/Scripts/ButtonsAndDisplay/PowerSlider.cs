using UnityEngine;
using UnityEngine.UI;

public class PowerSlider : MonoBehaviour
{
    Slider powerSlider;                                                         //reference to the slider
    SpellCalculator calcScript;                                                 //reference to the spell calculator to pass slider value for spell calculations

    void Start ()
    {
        powerSlider = this.GetComponent<Slider>();
        calcScript = GameObject.Find("Player1").GetComponentInChildren<SpellCalculator>();      //find the object for the owner player and in its children there should be a spell calculator
    }

    void Update ()
    {
        calcScript.powerValue = powerSlider.value;                              //update the calcscript
	}

    public void ResetPowerMeter()
    {
        powerSlider.value = 0;
    }
}
