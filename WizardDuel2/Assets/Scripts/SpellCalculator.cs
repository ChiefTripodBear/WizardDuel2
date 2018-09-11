using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellCalculator : MonoBehaviour
{
    GameManager gameManager;
    //a link to the buttons and a script reference to collect the bool from the button
    Button fireElement;
    ButtonSelection fire;
    Button waterElement;
    ButtonSelection water;
    Button airElement;
    ButtonSelection air;
    Button earthElement;
    ButtonSelection earth;

    //dictionary to hold the spellinputs
    Dictionary<string, bool> spellInput;

    SpellTypes selectedType;
    SpellRecipes selectedRecipe;

    //can i get the selected bool from the button and pass it into the recipe to get a spell ? 
    //then the same idea for the spell type button and power button allows me to calculate the spell stats

    private void Start()
    {
        gameManager = GameManager.Instance;
        fire = fireElement.GetComponent(typeof(ButtonSelection)) as ButtonSelection;
        water = waterElement.GetComponent(typeof(ButtonSelection)) as ButtonSelection;
        air = airElement.GetComponent(typeof(ButtonSelection)) as ButtonSelection;
        earth = earthElement.GetComponent(typeof(ButtonSelection)) as ButtonSelection;
    }

    private void Update()
    {
        if (gameManager.spellcastingEnabled)
        {
            spellInput.Add(fireElement.name, fire.isSelected);
            spellInput.Add(waterElement.name, water.isSelected);
            spellInput.Add(airElement.name, air.isSelected);
            spellInput.Add(earthElement.name, earth.isSelected);
            print(spellInput);
        }
    }

}
