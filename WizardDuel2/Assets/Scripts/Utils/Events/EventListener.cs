using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventListener: MonoBehaviour
{
    private UnityAction someListener;

    private void Awake()
    {
        someListener = new UnityAction(SomeFunction);
    }

    private void OnEnable()
    {
        EventManager.StartListening("test", someListener);
    }

    private void OnDisable()
    {
        
    }

    void SomeFunction()
    {
        Debug.Log("Some Function was called");
    }

}
