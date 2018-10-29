using UnityEngine;

public class EventTest : MonoBehaviour
{


    private void Update()
    {
        if (Input.GetKeyDown("q"))
        {
            EventManager.TriggerEvent("test");
        }
    }
}
