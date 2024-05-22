using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartsManager : MonoBehaviour
{
    public GameObject buttons;
    [SerializeField] GameObject defaultPart;
    [SerializeField] GameObject[] parts;// All the parts of the Reductor  

    public Animator animator;
    public MouseController mouseController;

    private GameObject selectedPart;
    

    private Button selectedButton;
    private Button pressedButton;

    public Color selectedColor;
    public Color notSelectedColor;

    bool animationState = false;

    public void ExpandGears()
    {
        animator.SetTrigger("Interact");
        if(animationState == true)
        {
            if (selectedButton != null)
                ActiveButton(selectedButton, false);
            HideParts(parts[0], true);
            mouseController.SetNewPivot(defaultPart, 1f, -0.3f);
        }
        animationState = !animationState;
        buttons.SetActive(animationState);
    }
    public void SelectButton(GameObject bttn)
    {
        pressedButton = bttn.GetComponent<Button>();
    }
    public void SelectPart(GameObject current)
    {
        if(selectedPart == current)
        {
            ActiveButton(pressedButton, false);
            HideParts(current, true);
            mouseController.SetNewPivot(defaultPart, 1f, -0.3f);
            selectedPart = defaultPart;
        }
        else
        {
            if(selectedButton != null)
                ActiveButton(selectedButton, false);
            ActiveButton(pressedButton, true);
            HideParts(current, false);
            mouseController.SetNewPivot(current, 0.7f, 0);
            selectedButton = pressedButton;
            selectedPart = current;
        }

    }
    public void HideParts(GameObject current,bool state)
    {
        foreach (GameObject part in parts)
        {
            part.SetActive(state);
        }
        current.SetActive(true);
    }
    public void ActiveButton(Button current,bool state)
    {
        ColorBlock cb = current.colors;
        if (state)
        {
            cb.normalColor = selectedColor;
            cb.highlightedColor = selectedColor;
            cb.selectedColor = selectedColor;
            current.colors = cb;
        }
        else
        {
            cb.normalColor = notSelectedColor;
            cb.highlightedColor = notSelectedColor;
            cb.selectedColor = notSelectedColor;
            current.colors = cb;
        }
    }
}
