using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonInteraction : MonoBehaviour
{
    public Button button;
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
    }    

}
