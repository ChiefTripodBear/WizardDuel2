using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSelection : MonoBehaviour {

    public Sprite notSelected;
    public Sprite selected;
    public Button elementButton;
    public bool isSelected = false;

    private void Start()
    {
        elementButton.image.sprite = notSelected;
    }

    public void PressButton()
    {
        isSelected = !isSelected;
        ChangeImage();
    }

    void ChangeImage()
    {
        if (isSelected == false)
        {
            elementButton.image.sprite = notSelected;
        }
        else elementButton.image.sprite = selected;
    }
}
