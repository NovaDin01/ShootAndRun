using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    public float rotationSpeed = 5.0f;
    private float yaw;
    private float pitch;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Получаем движение мыши
        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * rotationSpeed;

        // Обновляем углы вращения
        yaw += mouseX;
        pitch -= mouseY;

        // Ограничиваем угол по вертикали
        pitch = Mathf.Clamp(pitch, -10f, 10f);
        yaw = Mathf.Clamp(yaw, -130f, -50f);

        // Применяем вращение к камере
        transform.eulerAngles = new Vector3(pitch, yaw, 0);
    }
}
