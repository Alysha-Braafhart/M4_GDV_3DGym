using UnityEngine;
using UnityEngine.InputSystem;

public class Character : MonoBehaviour
{
    [SerializeField] private InputActionAsset input;
    [SerializeField] private string mapName;
    [SerializeField] private float walkSpeed = 5f;
    private InputAction moveAction;
    private InputAction jumpAction;
    private Animator animator;

    void Awake()
    {
        InputActionMap map = input.FindActionMap(mapName);
        moveAction = map.FindAction("Move");
        jumpAction = map.FindAction("Jump");
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveInput = moveAction.ReadValue<Vector2>();
        float speed = walkSpeed * moveInput.y;

        animator.SetFloat("Speed", speed);

        if (jumpAction.WasPressedThisFrame())
        {
             animator.SetTrigger("Jump");
        }
    }
}
