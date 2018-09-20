using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellManager : MonoBehaviour
{
    #region singleton setup
    private static SpellManager instance;

    public static SpellManager Instance
    {
        get
        {
            return instance;
        }

        set
        {
            instance = value;
        }
    }

    #endregion

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public int selectedElements_cnt = 0; //holds from button scripts the number of selected elements

    void Start ()
    {
	    
	}
	
	void Update ()
    {
		
	}

    void AddElement()
    {

    }

    void RemoveElement()
    {

    }
}

