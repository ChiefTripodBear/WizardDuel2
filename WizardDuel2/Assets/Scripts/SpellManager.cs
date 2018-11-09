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
    }

    void Start ()
    {
	    
	}
	
	void Update ()
    {
		
	}
}

