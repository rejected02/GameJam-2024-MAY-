using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f;
    private CharacterController controller;
    private Transform camTransform;
    void Start()
    {
        controller = GetComponent<CharacterController>();
        camTransform = GetComponent<Transform>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 moveDirection = transform.forward * vertical + transform.right * horizontal;
        moveDirection = camTransform.forward * moveDirection.z + camTransform.right * moveDirection.x;
        controller.Move(moveDirection * speed * Time.deltaTime);
    }
}
