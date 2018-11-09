using System;
using UnityEngine;
using UnityEngine.UI;

public class TypeButtonSelection : MonoBehaviour {

    public Sprite notSelected;
    public Sprite selected;
    public Button typeButton;                                                               //reference to the button on this gameobject
    public bool isSelected = false;
    public SType sType;                                                                        //reference to the buttons' linked element

    SpellCalculator calcScript;                                                               //reference to the relevant players spell calculator

    private void Start()
    {
        typeButton = gameObject.GetComponent<Button>();
        typeButton.image.sprite = notSelected;
        calcScript = GameObject.Find("Player1").GetComponentInChildren<SpellCalculator>();      //find the object for the owner player and in its children there should be a spell calculator
    }

    public void Update()
    {
        if (calcScript.selectedType != sType)                                                 //if selectedType isn't this button, turn it off
        {
            UnselectButtons();
        }
    }

    public void PressButton()
    {
        SelectType();
    }

    void SelectType()
    {
        isSelected = true;                                                                      //this button is selected
        typeButton.image.sprite = selected;
        calcScript.TypeUpdate(sType);                                                       //set the spelltype in the calculator to this button's type
    }

    public void UnselectButtons()
    {                                                                           //run this each new phase to reset buttons and element array
        isSelected = false;
        typeButton.image.sprite = notSelected;
    }
}

