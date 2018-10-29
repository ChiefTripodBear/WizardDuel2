using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellCalculator : MonoBehaviour
{
    SpellRecipes[] allRecipes;                                          //all spellrecipes
    SpellTypes[] allTypes;                                              //array of all Spell Types
    SpellTypes activeType;                                              //Hold the activeSpellType

    public SpellRecipes activeSpell;                                    //Hold the activeSpell
    public int selectedElements_cnt = 0;                                //holds from button scripts the number of selected elements (to limit selection to 2)
    public Element activeElements;                                      //the active element, updated by bitwise operators

    private void Start()
    {
        allTypes = Resources.LoadAll<SpellTypes>("");                   //Load all SpellTypes in the resources folder
        allRecipes = Resources.LoadAll<SpellRecipes>("");               //Load all SpellRecipes in the resources folder
    }

    //holds all methods for management of element buttons and element list
    #region ElementListManagement                                       
    public void ListElement(Element element, bool isAdding)             //this method is called from the element buttons to add the activated element to the array
    {
        if (!isAdding)
        {
            activeElements &= ~element;                  //use XOR to remove the passed in element from the active element
        }
        else
        {
            activeElements |= element;                                  //use OR to add the passed in element onto the active element
        }
    }

    public void RemoveAllElements(Element element)                      //this method is called from the element buttons to remove all activated elements to the array
    {
        activeElements = Element.None;
    }
    #endregion                                                          //all the code that relates to element array and button management 

    private void Update()
    {
        if (selectedElements_cnt == 0)
        {
            activeElements = Element.None;                              //if there are no elements selected, set active element and active spell to nothing
            activeSpell = null;
        }
        else
        {
            foreach (SpellRecipes sr in allRecipes)                         //for each recipe in the array of all recipes, find the one with the same enum as the activeelement enum 
            {
                if (Enum.Equals(sr.recipe, activeElements))
                {
                    activeSpell = sr;                                       //set the correct spell as the active spell
                }
            }
        }
    }
    
}
