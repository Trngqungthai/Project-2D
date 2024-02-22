using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonUIPlayer : MonoBehaviour
{
    public Button buttonMenu;
    public Button buttonSound;
    public GameObject UIHideObject;
    public GameObject UIOnObject;
    private void Start()
    {
        UIHideObject.gameObject.SetActive(false);
        UIOnObject.gameObject.SetActive(true);
    }
    public void OnButton1Click()
    {
        UIHideObject.gameObject.SetActive(true);
        UIOnObject.gameObject.SetActive(false);
        buttonMenu.interactable = false;
        buttonSound.interactable = false;
    }
    public void OnButtonClick()
    {
        buttonMenu.interactable = true;
        buttonSound.interactable = true;
    }    
}
