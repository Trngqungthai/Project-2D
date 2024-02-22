using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed;
    public Transform movePoint;
    public LayerMask obstacleLayer;

    private Vector2[] moveDirections = { Vector2.up, Vector2.right, Vector2.down, Vector2.left };
    private int currentMoveDirection;

    private bool isMovingRight = false;


    private void Start()
    {
        // Khởi tạo vị trí di chuyển ban đầu
        currentMoveDirection = Random.Range(0, moveDirections.Length);
        movePoint.position = transform.position;
        EnemyManager.aliveEnemies.Add(gameObject);
        int walkLayerIndex = LayerMask.NameToLayer("Walk");
        obstacleLayer = LayerMask.GetMask(LayerMask.LayerToName(walkLayerIndex));
    }
    private void Update()
    {
        // Di chuyển enemy
        transform.position = Vector2.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

        // Kiểm tra nếu enemy đã đến điểm di chuyển hiện tại
        if (Vector2.Distance(transform.position, movePoint.position) <= 0.05f)
        {
            // Chọn một hướng di chuyển mới ngẫu nhiên
            int randomDirection = Random.Range(0, moveDirections.Length);
            currentMoveDirection = (currentMoveDirection + randomDirection) % moveDirections.Length;

            // Tính toán vị trí điểm di chuyển mới
            Vector2 newMovePointPosition = (Vector2)transform.position + moveDirections[currentMoveDirection];
            RaycastHit2D hit = Physics2D.Raycast(newMovePointPosition, Vector2.zero, 0f, obstacleLayer);

            // Kiểm tra xem vị trí mới có bị chặn bởi vật cản không
            if (hit.collider == null)
            {
                movePoint.position = newMovePointPosition;

                // Thay đổi hướng di chuyển và flipX
                if (moveDirections[currentMoveDirection] == Vector2.right && !isMovingRight)
                {
                    Flip();
                }
                else if (moveDirections[currentMoveDirection] == Vector2.left && isMovingRight)
                {
                    Flip();
                }
            }
            else
            {
                // Nếu có chướng ngại vật, chọn hướng di chuyển khác
                int randomAvoidDirection = (randomDirection + 1) % moveDirections.Length;
                currentMoveDirection = (currentMoveDirection + randomAvoidDirection) % moveDirections.Length;

                // Tính toán vị trí điểm di chuyển né chướng ngại vật
                newMovePointPosition = (Vector2)transform.position + moveDirections[currentMoveDirection];
                movePoint.position = newMovePointPosition;
            }
        }
    }
    private void Flip()
    {
        isMovingRight = !isMovingRight;
        Vector3 enemyScale = transform.localScale;
        enemyScale.x *= -1;
        transform.localScale = enemyScale;
    }
}