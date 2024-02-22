using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPosition : MonoBehaviour
{
    private void Start()
    {
        // Kiểm tra xem có vị trí Player được lưu trong PlayerPrefs không
        if (PlayerPrefs.HasKey("PlayerPosX") && PlayerPrefs.HasKey("PlayerPosY"))
        {
            // Khôi phục lại vị trí của Player
            float playerPosX = PlayerPrefs.GetFloat("PlayerPosX") + 1f;
            float playerPosY = PlayerPrefs.GetFloat("PlayerPosY");
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.transform.position = new Vector2(playerPosX, playerPosY);

            // Xóa vị trí đã lưu trong PlayerPrefs
            PlayerPrefs.DeleteKey("PlayerPosX");
            PlayerPrefs.DeleteKey("PlayerPosY");
            PlayerPrefs.Save();
        }

    }
}
