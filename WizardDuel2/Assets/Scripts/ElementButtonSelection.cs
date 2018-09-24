﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElementButtonSelection : MonoBehaviour {

    public Sprite notSelected;
    public Sprite selected;
    public Button elementButton;
    public bool isSelected = false;
    public string elementName = null;

    private void Start()
    {
        elementButton.image.sprite = notSelected;
        //return the name of the element on the button
        elementName = elementButton.name.Substring(0, this.gameObject.name.IndexOf(" ", 0));
    }

    public void PressButton()
    {
        if (isSelected)
        { //if element is selected, deselect button and change image
            UnSelectElement();
        }
        else
        {//if the element isn't selected already
            SelectElement();
        }
    }

    void SelectElement()
    {
        if (SpellManager.Instance.selectedElements_cnt < 2)
        { //if element isnt selected, check that selectedElements is less than 2 then select button and change image
            isSelected = !isSelected;
            SpellManager.Instance.selectedElements_cnt++;
            elementButton.image.sprite = selected;
        }
        //if selectedElements = 2 or more, do nothing
    }

    void UnSelectElement()
    {
        isSelected = !isSelected;
        SpellManager.Instance.selectedElements_cnt--;
        elementButton.image.sprite = notSelected;
    }

    public void UnselectButtons()
    {
        isSelected = false;
        elementButton.image.sprite = notSelected;
        SpellManager.Instance.selectedElements_cnt = 0;
    }
}