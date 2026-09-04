using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private PlayerAnimationController animate;

    [Header("Values")]
    [SerializeField] private float movementSpeed = 2f;

    private InputSystem_Actions actions;
    private Vector2 movement;

    private void Awake()
    {
        actions = new InputSystem_Actions();
    }

    private void OnEnable()
    {
        actions.Enable();
    }

    private void OnDisable()
    {
        actions.Disable();
    }

    private void Update()
    {
        movement = actions.Movement.Move.ReadValue<Vector2>();
        animate.Run(movement);
    }

    private void FixedUpdate()
    {
        rigidBody.linearVelocity = movement * movementSpeed;
    }

    
}
