using UnityEngine;

public class Movimiento3D : MonoBehaviour
{
    public float speed = 3f;
    public float gravity = -9.81f;

    private CharacterController controller;
    private Vector3 verticalSpeed; // Para acumular la caída

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Character Movement
        float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? 5f : 3f;

        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(moveX, 0, moveZ).normalized;

        if (direction.magnitude >= 0.1f)
        {
            controller.Move(direction * currentSpeed * Time.deltaTime);
        }

        // Gravity logic
        if (controller.isGrounded && verticalSpeed.y < 0)
        {
            verticalSpeed.y = -2f; // To always detect the floor
        }

        // Gravity aplication to vertical vector
        verticalSpeed.y += gravity * Time.deltaTime;

        // Moving controller down
        controller.Move(verticalSpeed * Time.deltaTime);
    }
}