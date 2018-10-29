using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Events;

public class ElementListener : MonoBehaviour
{
    private UnityAction elementListener;                //this listener picks up events related to enabling button presses for elements
    string[] allElements;                        //an array of all elements in the game, to feed into events list
    string[] buttonToggle = new string[2] { "selected", "unselected" };     //array of button toggles, to feed into events list

    private void Awake()
    {
        allElements = Enum.GetNames(typeof(Element));

        foreach (string e in allElements)
        {
            foreach (string f in buttonToggle)
            {
            
}
        }

        elementListener = new UnityAction(SomeFunction);

    }

    private void OnEnable()
    {
        BeginListening();
    }

    private void OnDisable()
    {
        StopListening();
    }

    private void BeginListening()
    {
        foreach (string e in allElements)
        {
            foreach (string f in buttonToggle)
            {
                EventManager.StartListening((e + " " + f), elementListener);
            }
        }
    }

    private void StopListening()
    {
        foreach (string e in allElements)
        {
            foreach (string f in buttonToggle)
            {
                EventManager.StopListening((e + " " + f), elementListener);
            }
        }
    }

    void SomeFunction()
    {
        Debug.Log("Some Function was called");
    }
}
