using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    [Header("Movement")]
    public float moveSpeed = 6f;
    public float gravity = -20f;
    private Vector3 velocity;

    public CharacterController controller;

    [Header("Camera")]
    public Transform cameraTrans;
    public float mouseSensitivity = 2f;
    public bool invertY;

    float xRotation = 0f;

    [Header("Interaction")]
    public float interactRange = 3f;
    public LayerMask interactMask;

    [Header("Mask")]
    public bool isWearingMask = false;
    public GameObject maskUIOverlay;
    public bool hasMask = false;



    void Awake()
    {
        instance = this;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        HandleMovement();
        HandleMouseLook();
        HandleInteraction();
        HandleMaskToggle();
    }

    // --------------------

    void HandleMovement()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * moveSpeed * Time.deltaTime);

        if (controller.isGrounded && velocity.y < 0)
            velocity.y = -2f;

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    void HandleMouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * 100f * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * 100f * Time.deltaTime;

        if (invertY)
            mouseY = -mouseY;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        cameraTrans.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }

    void HandleInteraction()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;

            if (Physics.Raycast(cameraTrans.position, cameraTrans.forward, out hit, interactRange, interactMask))
            {
                InteractiveObject obj = hit.collider.GetComponent<InteractiveObject>();

                if (obj != null)
                {
                    obj.OnInteract();
                }
            }
        }
    }

    void HandleMaskToggle()
    {
        if (!hasMask) return;

        if (Input.GetKeyDown(KeyCode.F))
        {
            isWearingMask = !isWearingMask;

            if (maskUIOverlay != null)
                maskUIOverlay.SetActive(isWearingMask);
        }
    }

}
