using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMapPK : MonoBehaviour
{
    public string sceneName;
    public string sceneToUnHide1;
    public string sceneToUnHide2;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
            HideScene(sceneToUnHide1);
            HideScene(sceneToUnHide2);            
        }        
    }
    private void HideScene(string sceneName)
    {
        Scene scene = SceneManager.GetSceneByName(sceneName);

        if (scene.IsValid())
        {
            // Loop through all objects in the scene
            GameObject[] sceneObjects = scene.GetRootGameObjects();
            foreach (GameObject obj in sceneObjects)
            {
                // Deactivate the objects in the scene
                obj.SetActive(false);
            }
        }
    }      
}
