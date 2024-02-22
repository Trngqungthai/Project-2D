using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemyPK : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            GameObject enemy = collision.gameObject;
            Debug.Log("Enemy: " + enemy.name);
            Destroy(enemy);
        }
    }
}
