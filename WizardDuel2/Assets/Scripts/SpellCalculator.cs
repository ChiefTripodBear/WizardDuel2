using System;
using UnityEngine;
using UnityEngine.UI;

public class SpellCalculator : MonoBehaviour
{
    SpellRecipes[] allRecipes;                                          //all spellrecipes
    SpellTypes[] allTypes;                                              //array of all Spell Types
    SpellTypes activeType;                                              //Hold the activeSpellType
    public float powerValue;                                            //value from powerSlider

    public SpellRecipes activeSpell;                                    //Hold the activeSpell
    public SType selectedType;                                          //Spelltype selected by the buttons
    public int selectedElements_cnt = 0;                                //holds from button scripts the number of selected elements (to limit selection to 2)
    public Element activeElements;                                      //the active element, updated by bitwise operators

    #region CalculatorVariables
    public float force;                                                 //the force value of the active spell, the force of the active spell * forcemod of active type * power slider
    public float pierce;                                                //the pierce value of the pierce spell, the pierce of the active spell * pierceemod of active type * power slider
    public float toughness;                                             //the toughness value of the active spell, the toughness of the active spell * toughnessmod of active type * power slider
    public float resistance;                                            //the resist value of the active spell, the resist of the active spell * resistmod of active type * power slider
    public float spellCost;                                             //spell cost based on the active spell
    bool hasEffect;                                                     //does this spell have a secondary effect?
    bool effectSelf;                                                    //if the spell has a secondary effect, does it affect the caster? if not, it affects the opponent
    int effectDuration;                                                 //how many rounds does the effect last for?
    EffectStat effectStat;                                              //which stat does the effect affect?
    float effectValue;                                                  //whats the amount of the effect

    public float offensiveValues;                                       //the sum of the force and pierce as defined above
    public float defensiveValues;                                       //the sum of the toughness and resistance as defined above

    #endregion 

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
            activeElements &= ~element;                                 //use XOR to remove the passed in element from the active element
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

    private void SpellUpdate()
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
    #endregion                                                          //all the code that relates to element array and button management 
    //holds all methods for management of type buttons and active type
    #region TypeManagement

    public void TypeUpdate(SType type)                                  //pass in the active spell type from the button
    {
        selectedType = type;
        foreach (SpellTypes t in allTypes)
        {
            if (selectedType == t.stype)
            {
                activeType = t;
            }
        }
    }
    #endregion TypeManagement

    private void Update()
    {
        SpellUpdate();                                                  //held in the Element List Management region, this method updates the active spell
        CalculateSpellValues();

        //calculate 
    }

    void CalculateSpellValues()
    {
        //TODO: apply effect after spell applied
        if (powerValue != 0)
        {
            force = activeSpell._force * activeType._forceMod * powerValue;
            pierce = activeSpell._pierce * activeType._pierceMod * powerValue;
            toughness = activeSpell._toughness * activeType._toughnessMod * powerValue;
            resistance = activeSpell._resist * activeType._resistMod * powerValue;

            offensiveValues = force + pierce;                               //could refactor this in the future to group spelltypes into offensive/defensive groups if needed
            defensiveValues = toughness + resistance;

            spellCost = activeSpell._spellCost * powerValue;
        }
    }
}