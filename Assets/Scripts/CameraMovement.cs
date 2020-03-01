using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity = 10f;
    [SerializeField] private float yAxisClamp = 80f;
    private GameObject player;
    private float cameraRot = 0;

    private void Start()
    {
        player = transform.parent.gameObject;
    }
    
    private void Update()
    {
        Vector3 mouseInput = GetMouseInput();

        // Y axis rotation (Player)
        player.transform.Rotate(Vector3.up * mouseInput.x * mouseSensitivity);

        // X axis rotation (Camera)
        cameraRot += -mouseInput.y * mouseSensitivity;
        cameraRot = Mathf.Clamp(cameraRot, -yAxisClamp, yAxisClamp);
        transform.localEulerAngles = new Vector3(cameraRot, transform.localEulerAngles.y, 0);
    }

    private Vector3 GetMouseInput()
    {
        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");

        return new Vector3(x, y, 0);
    }
}
