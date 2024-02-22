using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OutmapPK : MonoBehaviour
{
    public string sceneNameUnload;
    public string sceneToUnHide1;
    public string sceneToUnHide2;

    public void OnButtonOutScene()
    {
        DestroyEnemy();
        SceneManager.UnloadSceneAsync(sceneNameUnload);
        OnHideScene(sceneToUnHide1);
        OnHideScene(sceneToUnHide2);
    }
    private void OnHideScene(string nameScene)
    {
        Scene scene = SceneManager.GetSceneByName(nameScene);

        if (scene.IsValid())
        {
            // Loop through all objects in the scene
            GameObject[] sceneObjects = scene.GetRootGameObjects();
            foreach (GameObject obj in sceneObjects)
            {
                // Deactivate the objects in the scene
                obj.SetActive(true);
            }
        }
    }
    private void DestroyEnemy()
    {
        GameObject[] obs = GameObject.FindGameObjectsWithTag("ClonePrefab");
        foreach (GameObject ob in obs)
        {
            Destroy(ob);
        }
    }
}
