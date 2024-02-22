using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    private CinemachineVirtualCamera virtualCamera;
    private GameObject player;

    void Start()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
    }

    void Update()
    {
        if (player == null)
        {
            player = GameObject.FindWithTag("Player"); // Thay "Player" bằng tag của đối tượng player trong game của bạn.

            if (player != null)
            {
                virtualCamera.Follow = player.transform;
            }
        }
    }
}
