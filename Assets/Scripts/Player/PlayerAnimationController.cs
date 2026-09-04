using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;

    public void Run(Vector2 movement)
    {
        animator.SetBool("IsRunning", (movement.x != 0 || movement.y != 0));
        spriteRenderer.flipX = movement.x < 0;
    }
}
