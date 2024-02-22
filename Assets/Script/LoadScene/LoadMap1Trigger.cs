using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMap1Trigger : MonoBehaviour
{
    public string sceneName;
    public string unloadscene;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
            SceneManager.UnloadSceneAsync(unloadscene);
        }
    }
}
