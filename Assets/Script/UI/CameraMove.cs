using System.Collections;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float speed = 3.0f; // Tốc độ di chuyển của camera

    public Vector2 direction = Vector2.down; // Hướng di chuyển của camera
    public Vector2 direction2 = Vector2.right;

    public Vector2 direction3 = Vector2.up;
    public Vector2 direction4 = Vector2.left;
    private void Update()
    {
        MoveDown();
        StartCoroutine(MoveCoroutine());
        StopCoroutine(MoveCoroutine());
    }

    private IEnumerator MoveCoroutine()
    {
        MoveRight();
        yield return new WaitForSeconds(20f); 
    }
    private void MoveDown()
    {
        // Tính toán vị trí mới của camera dựa trên hướng di chuyển và tốc độ
        Vector3 newPosition = transform.position + new Vector3(direction.x, direction.y, 0) * speed * Time.deltaTime;
        // Cập nhật vị trí của camera
        transform.position = newPosition;
    }
    private void MoveRight()
    {
        Vector3 newPosition = transform.position + new Vector3(direction2.x, direction2.y, 0) * speed * Time.deltaTime;
        // Cập nhật vị trí của camera
        transform.position = newPosition;
    }    
    private void MoveUp()
    {
        Vector3 newPosition = transform.position + new Vector3(direction3.x, direction3.y, 0) * speed * Time.deltaTime;
        // Cập nhật vị trí của camera
        transform.position = newPosition;
    }
    private void MoveLeft()
    {
        Vector3 newPosition = transform.position + new Vector3(direction4.x, direction4.y, 0) * speed * Time.deltaTime;
        // Cập nhật vị trí của camera
        transform.position = newPosition;
    }    
}