using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadNameMap : MonoBehaviour
{
    public GameObject UIName;

    public float delayTime = 2f; // Thời gian đợi trước khi ẩn UIName

    private void Start()
    {
        UIName.SetActive(true);
        StartCoroutine(HideUINameAfterDelay());
    }

    private IEnumerator HideUINameAfterDelay()
    {
        yield return new WaitForSeconds(delayTime);
        UIName.SetActive(false);
    }
}