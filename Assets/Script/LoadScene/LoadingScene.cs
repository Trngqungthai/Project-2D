using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    public GameObject loaderUI;
    public Slider progressSlider;
    public Image image;

    public void LoadScene(string scene)
    {
        StartCoroutine(LoadScene_Coroutine(scene));
    }
    public IEnumerator LoadScene_Coroutine(string scene)
    {
        progressSlider.value = 0;
        loaderUI.SetActive(true);
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(scene);
        asyncOperation.allowSceneActivation = false;
        float progress = 0;
        while (!asyncOperation.isDone)
        {
            progress = Mathf.MoveTowards(progress, asyncOperation.progress, Time.deltaTime);
            asyncOperation.allowSceneActivation = true;
        }
        yield return null;
    }    
   
}
