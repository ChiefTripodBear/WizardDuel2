using System;
using UnityEngine;
using UnityEngine.UI;

public class ElementButtonSelection : MonoBehaviour {

    public Sprite notSelected;
    public Sprite selected;
    public Button elementButton;                                                               //reference to the button on this gameobject
    public bool isSelected = false;
    public Element element;                                                         //reference to the buttons' linked element

    SpellCalculator calcScript;                                                     //reference to the relevant players spell calculator

    private void Start()
    {
        elementButton = gameObject.GetComponent<Button>();
        elementButton.image.sprite = notSelected;
        calcScript = GameObject.Find("Player1").GetComponentInChildren<SpellCalculator>();      //find the object for the owner player and in its children there should be a spell calculator
    }

    public void PressButton()
    {
        if (isSelected)
        {                                                                       //if element is selected, deselect button and change image
            UnSelectElement();
        }
        else
        {                                                                       //if the element isn't selected already
            SelectElement();
        }
    }

    void SelectElement()
    {
        if (calcScript.selectedElements_cnt < 2)
        {                                                                //if element isnt selected, check that selectedElements is less than 2 then select button and change image
            isSelected = !isSelected;
            calcScript.selectedElements_cnt++;
            elementButton.image.sprite = selected;
            calcScript.ListElement(element, true);                         //add button element to active element array in spell calculator
        }
                                                                                //if selectedElements = 2 or more, do nothing
    }

    void UnSelectElement()
    {
        isSelected = !isSelected;
        calcScript.selectedElements_cnt--;
        elementButton.image.sprite = notSelected;
        calcScript.ListElement(element, false);                              //remove button element to active element array in spell calculator
    }

    public void UnselectButtons()
    {                                                                           //run this each new phase to reset buttons and element array
        isSelected = false;
        elementButton.image.sprite = notSelected;
        calcScript.selectedElements_cnt = 0;
        calcScript.RemoveAllElements(element);                             //remove all elements to active element array in spell calculator
    }
}
