using UnityEngine;

public class DontDestroyPlayer : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            HideObject();
        }    
    }
    public void HideObject()
    {
        gameObject.SetActive(false);
    }
    public void ShowObject()
    {
        gameObject.SetActive(true);
    }
}