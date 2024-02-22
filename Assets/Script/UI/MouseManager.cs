using UnityEngine;

public class MouseManager : MonoBehaviour
{
    public Texture2D defaultCursor; // Hình ảnh con trỏ chuột mặc định
    public Texture2D hoverCursor; // Hình ảnh con trỏ chuột khi di chuột vào
    public Texture2D clickCursor; // Hình ảnh con trỏ chuột khi nhấp chuột

    public Vector2 hotspot = Vector2.zero; // Điểm nóng của con trỏ chuột

    private void Start()
    {
        // Áp dụng hình ảnh con trỏ chuột mặc định khi bắt đầu trò chơi
        Cursor.SetCursor(defaultCursor, hotspot, CursorMode.Auto);
    }

    private void Update()
    {
        // Lấy vị trí của chuột trong hệ tọa độ màn hình
        Vector2 mousePosition = Input.mousePosition;

        // Kiểm tra nếu chuột nằm trong phạm vi một đối tượng nào đó (ví dụ: một nút)
        // và thay đổi hình ảnh con trỏ chuột tương ứng
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(mousePosition), Vector2.zero);
        if (hit.collider != null)
        {
            // Chuột nằm trong phạm vi đối tượng
            Cursor.SetCursor(hoverCursor, hotspot, CursorMode.Auto);
        }
        else
        {
            // Chuột không nằm trong phạm vi đối tượng
            Cursor.SetCursor(defaultCursor, hotspot, CursorMode.Auto);
        }

        // Kiểm tra nút chuột trái có được nhấn hay không
        if (Input.GetMouseButtonDown(0))
        {
            // Thay đổi hình ảnh con trỏ chuột khi nhấp chuột
            Cursor.SetCursor(clickCursor, hotspot, CursorMode.Auto);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            // Trả lại hình ảnh con trỏ chuột mặc định sau khi nhấp chuột
            Cursor.SetCursor(defaultCursor, hotspot, CursorMode.Auto);
        }
    }

    private void OnApplicationQuit()
    {
        // Đặt lại hình ảnh con trỏ chuột khi kết thúc trò chơi
        Cursor.SetCursor(defaultCursor, hotspot, CursorMode.Auto);
    }
}