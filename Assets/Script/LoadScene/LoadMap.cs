using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMap : MonoBehaviour
{
    public Object player;
    public void Start()
    {
        SceneManager.LoadScene("House", LoadSceneMode.Additive);
    }
}
