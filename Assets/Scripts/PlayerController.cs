using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Camera cam;
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
        movement = actions.Player.Move.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        if(movement.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        if(movement.x > 0)
        {
            spriteRenderer.flipX = false;
        }
        
        rigidBody.linearVelocity = movement * movementSpeed;
        cam.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -100);
    }


}
